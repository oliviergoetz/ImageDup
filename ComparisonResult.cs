using System;

namespace ImageDup
{
    /// <summary>
    /// Représente le résultat d'une comparaison entre deux images
    /// </summary>
    public class ComparisonResult
    {
        public string Image1Path { get; set; }
        public string Image2Path { get; set; }
        public float SimilarityPercentage { get; set; }
        public bool IsImage1Deleted { get; set; }
        public bool IsImage2Deleted { get; set; }

        public ComparisonResult(string image1Path, string image2Path, float similarity)
        {
            Image1Path = image1Path;
            Image2Path = image2Path;
            SimilarityPercentage = similarity;
            IsImage1Deleted = false;
            IsImage2Deleted = false;
        }

        public string Image1Name => System.IO.Path.GetFileName(Image1Path);
        public string Image2Name => System.IO.Path.GetFileName(Image2Path);
    }
}
