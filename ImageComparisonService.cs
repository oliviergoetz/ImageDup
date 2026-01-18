using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Numerics.Tensors;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace ImageDup
{
    /// <summary>
    /// Service pour comparer deux images en utilisant le modèle ONNX CLIP
    /// </summary>
    public class ImageComparisonService : IDisposable
    {
        private readonly string modelPath;
        private readonly InferenceSession session;
        private readonly System.Collections.Concurrent.ConcurrentDictionary<string, float[]> embeddingCache;

        public ImageComparisonService(string modelPath)
        {
            if (!File.Exists(modelPath))
                throw new FileNotFoundException("Le fichier du modèle ONNX est introuvable.", modelPath);

            this.modelPath = modelPath;
            this.session = new InferenceSession(modelPath);
            this.embeddingCache = new System.Collections.Concurrent.ConcurrentDictionary<string, float[]>();
        }

        public void Dispose()
        {
            session?.Dispose();
        }

        /// <summary>
        /// Compare deux images et retourne un score de similarité en pourcentage (0-100)
        /// </summary>
        public float CompareImages(string imagePath1, string imagePath2)
        {
            if (!File.Exists(imagePath1))
                throw new FileNotFoundException("L'image 1 est introuvable.", imagePath1);

            if (!File.Exists(imagePath2))
                throw new FileNotFoundException("L'image 2 est introuvable.", imagePath2);

            var embedding1 = GetImageEmbedding(imagePath1);
            var embedding2 = GetImageEmbedding(imagePath2);

            return CosineSimilarity(embedding1, embedding2) * 100;
        }

        /// <summary>
        /// Obtient l'embedding d'une image (avec cache)
        /// </summary>
        private float[] GetImageEmbedding(string imagePath)
        {
            return embeddingCache.GetOrAdd(imagePath, path =>
            {
                var tensor = PreprocessImage(path);

                // Placeholders texte (seq_len = 77 pour CLIP)
                var inputIds = new DenseTensor<long>(new int[] { 1, 77 });
                var attentionMask = new DenseTensor<long>(new int[] { 1, 77 });

                var inputs = new[]
                {
                    NamedOnnxValue.CreateFromTensor("pixel_values", tensor),
                    NamedOnnxValue.CreateFromTensor("input_ids", inputIds),
                    NamedOnnxValue.CreateFromTensor("attention_mask", attentionMask)
                };

                // Demande au modèle de donner son vecteur de représentation (embedding) de l'image
                using (var results = session.Run(inputs))
                {
                    return results
                        .First(x => x.Name == "image_embeds")
                        .AsTensor<float>()
                        .ToArray();
                }
            });
        }

        /// <summary>
        /// Transforme une image en tenseur [1,3,224,224] normalisé, prêt à être passé dans le modèle CLIP ONNX
        /// </summary>
        private DenseTensor<float> PreprocessImage(string imagePath)
        {
            // Charger l'image depuis le fichier
            using (var originalImage = (Bitmap)System.Drawing.Image.FromFile(imagePath))
            {
                // Redimensionner l'image en 224x224 pixels (taille attendue par CLIP ViT-B/32)
                using (var resizedImage = new Bitmap(224, 224))
                {
                    using (var graphics = Graphics.FromImage(resizedImage))
                    {
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.DrawImage(originalImage, 0, 0, 224, 224);
                    }

                    // Créer le tenseur de sortie au format attendu par ONNX : [batch, channels, height, width]
                    var tensor = new DenseTensor<float>(new[] { 1, 3, 224, 224 });

                    // Moyenne et écart-type spécifiques au modèle CLIP
                    float[] mean = { 0.48145466f, 0.4578275f, 0.40821073f };
                    float[] std = { 0.26862954f, 0.26130258f, 0.27577711f };

                    // Remplir le tenseur avec les pixels normalisés en utilisant LockBits (beaucoup plus rapide)
                    BitmapData bmpData = resizedImage.LockBits(
                        new Rectangle(0, 0, 224, 224),
                        ImageLockMode.ReadOnly,
                        PixelFormat.Format24bppRgb);

                    try
                    {
                        unsafe
                        {
                            byte* ptr = (byte*)bmpData.Scan0;
                            int stride = bmpData.Stride;

                            for (int y = 0; y < 224; y++)
                            {
                                byte* row = ptr + (y * stride);
                                for (int x = 0; x < 224; x++)
                                {
                                    int offset = x * 3;
                                    byte b = row[offset];
                                    byte g = row[offset + 1];
                                    byte r = row[offset + 2];

                                    // Normaliser chaque canal : (valeur/255 - moyenne) / écart-type
                                    tensor[0, 0, y, x] = (r / 255f - mean[0]) / std[0]; // Rouge
                                    tensor[0, 1, y, x] = (g / 255f - mean[1]) / std[1]; // Vert
                                    tensor[0, 2, y, x] = (b / 255f - mean[2]) / std[2]; // Bleu
                                }
                            }
                        }
                    }
                    finally
                    {
                        resizedImage.UnlockBits(bmpData);
                    }

                    return tensor;
                }
            }
        }

        /// <summary>
        /// Calcule un score indiquant à quel point deux vecteurs pointent dans la même direction (leur similarité)
        /// </summary>
        private float CosineSimilarity(float[] a, float[] b)
        {
            float dot = 0, magA = 0, magB = 0;
            for (int i = 0; i < a.Length; i++)
            {
                dot += a[i] * b[i];
                magA += a[i] * a[i];
                magB += b[i] * b[i];
            }
            return dot / ((float)Math.Sqrt(magA) * (float)Math.Sqrt(magB));
        }
    }
}
