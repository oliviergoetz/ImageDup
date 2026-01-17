using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace ImageDup
{
    public partial class MainForm : MetroForm
    {
        private string selectedFolderPath;
        private ImageComparisonService comparisonService;
        private List<ComparisonResult> comparisonResults;
        private bool isAnalyzing = false;

        public MainForm()
        {
            InitializeComponent();
            InitializeService();
            comparisonResults = new List<ComparisonResult>();
        }

        private void InitializeService()
        {
            try
            {
                string modelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "openai.clip-vit-base-patch32.onnx");
                comparisonService = new ImageComparisonService(modelPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'initialisation du modèle ONNX :\n{ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Sélectionner le dossier contenant les images à analyser";
                fbd.ShowNewFolderButton = false;

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    selectedFolderPath = fbd.SelectedPath;
                    lblSelectedFolder.Text = selectedFolderPath;
                    btnAnalyze.Enabled = true;

                    // Réinitialiser les résultats précédents
                    comparisonResults.Clear();
                    dgvResults.Rows.Clear();
                    ClearPreview();
                }
            }
        }

        private async void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFolderPath) || comparisonService == null)
                return;

            if (isAnalyzing)
            {
                MessageBox.Show("Une analyse est déjà en cours.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Désactiver les contrôles pendant l'analyse
            isAnalyzing = true;
            btnSelectFolder.Enabled = false;
            btnAnalyze.Enabled = false;
            dgvResults.Rows.Clear();
            comparisonResults.Clear();
            ClearPreview();

            try
            {
                // Récupérer tous les fichiers images
                lblProgress.Text = "Recherche des images...";
                var imageFiles = GetImageFiles(selectedFolderPath);

                if (imageFiles.Count < 2)
                {
                    MessageBox.Show("Au moins 2 images sont nécessaires pour effectuer une comparaison.",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                lblProgress.Text = $"{imageFiles.Count} images trouvées. Analyse en cours...";

                // Calculer le nombre total de comparaisons
                int totalComparisons = (imageFiles.Count * (imageFiles.Count - 1)) / 2;
                progressBar.Maximum = totalComparisons;
                progressBar.Value = 0;

                int currentComparison = 0;

                // Comparer toutes les images 2 par 2
                await Task.Run(() =>
                {
                    for (int i = 0; i < imageFiles.Count - 1; i++)
                    {
                        for (int j = i + 1; j < imageFiles.Count; j++)
                        {
                            try
                            {
                                float similarity = comparisonService.CompareImages(
                                    imageFiles[i], imageFiles[j]);

                                var result = new ComparisonResult(imageFiles[i], imageFiles[j], similarity);

                                // Mettre à jour l'UI dans le thread principal
                                this.Invoke((MethodInvoker)delegate
                                {
                                    comparisonResults.Add(result);
                                    currentComparison++;
                                    progressBar.Value = currentComparison;
                                    lblProgress.Text = $"Comparaison {currentComparison}/{totalComparisons}...";
                                });
                            }
                            catch (Exception ex)
                            {
                                // Ignorer les erreurs de comparaison individuelles
                                System.Diagnostics.Debug.WriteLine($"Erreur lors de la comparaison : {ex.Message}");
                            }
                        }
                    }
                });

                // Trier les résultats par similarité décroissante
                comparisonResults = comparisonResults.OrderByDescending(r => r.SimilarityPercentage).ToList();

                // Afficher les résultats dans le DataGridView
                DisplayResults();

                lblProgress.Text = $"Analyse terminée ! {comparisonResults.Count} comparaisons effectuées.";
                progressBar.Value = progressBar.Maximum;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'analyse :\n{ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblProgress.Text = "";
                progressBar.Value = 0;
            }
            finally
            {
                // Réactiver les contrôles
                isAnalyzing = false;
                btnSelectFolder.Enabled = true;
                btnAnalyze.Enabled = true;
            }
        }

        private List<string> GetImageFiles(string folderPath)
        {
            var imageExtensions = new[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };
            var imageFiles = new List<string>();

            try
            {
                // Parcourir récursivement tous les sous-dossiers
                var allFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

                foreach (var file in allFiles)
                {
                    if (imageExtensions.Contains(Path.GetExtension(file).ToLower()))
                    {
                        imageFiles.Add(file);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la lecture du dossier :\n{ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return imageFiles;
        }

        private void DisplayResults()
        {
            dgvResults.Rows.Clear();

            foreach (var result in comparisonResults)
            {
                int rowIndex = dgvResults.Rows.Add(
                    result.Image1Name,
                    result.Image2Name,
                    $"{result.SimilarityPercentage:F2} %"
                );

                // Stocker l'objet ComparisonResult dans la propriété Tag de la ligne
                dgvResults.Rows[rowIndex].Tag = result;

                // Colorer la ligne en fonction de la similarité
                Color rowColor = GetSimilarityColor(result.SimilarityPercentage);
                dgvResults.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(30, rowColor);
            }
        }

        private Color GetSimilarityColor(float similarity)
        {
            if (similarity >= 90) return Color.FromArgb(231, 76, 60);    // Rouge (très similaire)
            if (similarity >= 70) return Color.FromArgb(243, 156, 18);   // Orange
            if (similarity >= 50) return Color.FromArgb(241, 196, 15);   // Jaune
            return Color.FromArgb(149, 165, 166);                        // Gris
        }

        private void dgvResults_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvResults.SelectedRows.Count > 0)
            {
                var selectedRow = dgvResults.SelectedRows[0];
                var result = selectedRow.Tag as ComparisonResult;

                if (result != null)
                {
                    // Afficher les images
                    LoadImageToPanel(pictureBox1, result.Image1Path);
                    LoadImageToPanel(pictureBox2, result.Image2Path);

                    // Activer/désactiver les boutons de suppression
                    btnDeleteImage1.Enabled = !result.IsImage1Deleted && File.Exists(result.Image1Path);
                    btnDeleteImage2.Enabled = !result.IsImage2Deleted && File.Exists(result.Image2Path);

                    // Marquer la ligne si une image a été supprimée
                    if (result.IsImage1Deleted || result.IsImage2Deleted)
                    {
                        selectedRow.DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                }
            }
            else
            {
                ClearPreview();
            }
        }

        private void LoadImageToPanel(PictureBox pictureBox, string imagePath)
        {
            try
            {
                // Libérer l'ancienne image si elle existe
                if (pictureBox.Image != null)
                {
                    pictureBox.Image.Dispose();
                    pictureBox.Image = null;
                }

                // Charger l'image depuis le fichier
                if (File.Exists(imagePath))
                {
                    using (var img = Image.FromFile(imagePath))
                    {
                        pictureBox.Image = new Bitmap(img);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement de l'image :\n{ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearPreview()
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }

            if (pictureBox2.Image != null)
            {
                pictureBox2.Image.Dispose();
                pictureBox2.Image = null;
            }

            btnDeleteImage1.Enabled = false;
            btnDeleteImage2.Enabled = false;
        }

        private void btnDeleteImage1_Click(object sender, EventArgs e)
        {
            if (dgvResults.SelectedRows.Count > 0)
            {
                var selectedRow = dgvResults.SelectedRows[0];
                var result = selectedRow.Tag as ComparisonResult;

                if (result != null)
                {
                    DeleteImage(result, true, selectedRow);
                }
            }
        }

        private void btnDeleteImage2_Click(object sender, EventArgs e)
        {
            if (dgvResults.SelectedRows.Count > 0)
            {
                var selectedRow = dgvResults.SelectedRows[0];
                var result = selectedRow.Tag as ComparisonResult;

                if (result != null)
                {
                    DeleteImage(result, false, selectedRow);
                }
            }
        }

        private void DeleteImage(ComparisonResult result, bool isImage1, DataGridViewRow row)
        {
            string imagePath = isImage1 ? result.Image1Path : result.Image2Path;
            string imageName = Path.GetFileName(imagePath);

            var confirmResult = MessageBox.Show(
                $"Êtes-vous sûr de vouloir supprimer définitivement le fichier ?\n\n{imageName}",
                "Confirmation de suppression",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    // Libérer l'image avant de la supprimer
                    if (isImage1)
                    {
                        if (pictureBox1.Image != null)
                        {
                            pictureBox1.Image.Dispose();
                            pictureBox1.Image = null;
                        }
                    }
                    else
                    {
                        if (pictureBox2.Image != null)
                        {
                            pictureBox2.Image.Dispose();
                            pictureBox2.Image = null;
                        }
                    }

                    // Supprimer le fichier
                    File.Delete(imagePath);

                    // Marquer comme supprimé
                    if (isImage1)
                    {
                        result.IsImage1Deleted = true;
                        btnDeleteImage1.Enabled = false;
                    }
                    else
                    {
                        result.IsImage2Deleted = true;
                        btnDeleteImage2.Enabled = false;
                    }

                    // Marquer la ligne en bleu
                    row.DefaultCellStyle.BackColor = Color.LightBlue;

                    MessageBox.Show("Fichier supprimé avec succès.",
                        "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la suppression du fichier :\n{ex.Message}",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Libérer les ressources des images
            ClearPreview();
            base.OnFormClosing(e);
        }
    }
}
