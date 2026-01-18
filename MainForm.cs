using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Microsoft.VisualBasic.FileIO;

namespace ImageDup
{
    public partial class MainForm : MetroForm
    {
        private string selectedFolderPath;
        private ImageComparisonService comparisonService;
        private List<ComparisonResult> comparisonResults;
        private bool isAnalyzing = false;
        private System.Threading.CancellationTokenSource cancellationTokenSource;

        public MainForm()
        {
            InitializeComponent();

            // Charger l'icône depuis les ressources embarquées
            try
            {
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                using (var stream = assembly.GetManifestResourceStream("ImageDup.ImageDup.ico"))
                {
                    if (stream != null)
                    {
                        this.Icon = new System.Drawing.Icon(stream);
                    }
                }
            }
            catch { }

            comparisonResults = new List<ComparisonResult>();

            dgvResults.CellFormatting += dgvResults_CellFormatting;

            // Activer Ctrl+A pour sélectionner tout le texte dans les TextBox
            txtImagePath1.KeyDown += TextBox_KeyDown;
            txtImagePath2.KeyDown += TextBox_KeyDown;

            // Activer la loupe sur les images
            pictureBox1.MouseClick += PictureBox_MouseClick;
            pictureBox2.MouseClick += PictureBox_MouseClick;

            // Définir le curseur loupe pour les PictureBox
            pictureBox1.Cursor = LoadCustomCursor(32651);
            pictureBox2.Cursor = LoadCustomCursor(32651);
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
                fbd.SelectedPath = AppDomain.CurrentDomain.BaseDirectory;

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    selectedFolderPath = fbd.SelectedPath;
                    lblSelectedFolder.Text = selectedFolderPath;
                    btnAnalyze.Enabled = true;

                    // Réinitialiser les résultats précédents
                    comparisonResults.Clear();
                    dgvResults.Rows.Clear();
                    ClearPreview();

                    // Réinitialiser la barre de progression et les messages
                    progressBar.Value = 0;
                    progressBar.Maximum = 100;
                    lblProgress.Text = "";
                }
            }
        }

        private async void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFolderPath))
                return;

            if (isAnalyzing)
            {
                MessageBox.Show("Une analyse est déjà en cours.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Initialiser le service si ce n'est pas encore fait
            if (comparisonService == null)
            {
                lblProgress.Text = "Initialisation du modèle...";
                this.Cursor = Cursors.WaitCursor;
                InitializeService();
                this.Cursor = Cursors.Default;

                if (comparisonService == null)
                {
                    lblProgress.Text = "";
                    return;
                }
            }

            // Désactiver certains contrôles pendant l'analyse
            isAnalyzing = true;
            cancellationTokenSource = new System.Threading.CancellationTokenSource();
            this.Cursor = Cursors.AppStarting; // Flèche avec sablier
            dgvResults.Cursor = Cursors.AppStarting;
            btnSelectFolder.Enabled = false;
            btnAnalyze.Enabled = false;
            btnCancelAnalysis.Enabled = true;
            dgvResults.Rows.Clear();
            comparisonResults.Clear();
            ClearPreview();

            try
            {
                // Récupérer tous les fichiers images
                lblProgress.Text = "Recherche des images...";
                var imageFiles = GetImageFiles(selectedFolderPath);

                if (imageFiles.Count == 0)
                {
                    MessageBox.Show("Aucune image n'a été trouvée dans le dossier sélectionné.",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblProgress.Text = "";
                    return;
                }

                if (imageFiles.Count < 2)
                {
                    MessageBox.Show("Au moins 2 images sont nécessaires pour effectuer une analyse.",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                lblProgress.Text = $"{imageFiles.Count} images trouvées. Analyse en cours...";

                // Calculer le nombre total de comparaisons
                int totalComparisons = (imageFiles.Count * (imageFiles.Count - 1)) / 2;
                progressBar.Maximum = totalComparisons;
                progressBar.Value = 0;

                int currentComparison = 0;
                object lockObj = new object();
                var startTime = DateTime.Now;

                // Comparer toutes les images 2 par 2 en parallèle pour plus de rapidité
                await Task.Run(() =>
                {
                    var comparisons = new List<(int i, int j)>();
                    for (int i = 0; i < imageFiles.Count - 1; i++)
                    {
                        for (int j = i + 1; j < imageFiles.Count; j++)
                        {
                            comparisons.Add((i, j));
                        }
                    }

                    Parallel.ForEach(comparisons, new ParallelOptions
                        {
                            MaxDegreeOfParallelism = Environment.ProcessorCount,
                            CancellationToken = cancellationTokenSource.Token
                        },
                        pair =>
                        {
                            if (cancellationTokenSource.Token.IsCancellationRequested)
                                return;

                            try
                            {
                                float similarity = comparisonService.CompareImages(
                                    imageFiles[pair.i], imageFiles[pair.j]);

                                var result = new ComparisonResult(imageFiles[pair.i], imageFiles[pair.j], similarity);

                                // Mettre à jour l'UI dans le thread principal
                                this.Invoke((MethodInvoker)delegate
                                {
                                    // Sauvegarder la sélection actuelle
                                    bool hadSelection = dgvResults.SelectedRows.Count > 0;
                                    int selectedIndex = hadSelection ? dgvResults.SelectedRows[0].Index : -1;

                                    // Désactiver temporairement l'événement pour éviter le clignotement
                                    dgvResults.SelectionChanged -= dgvResults_SelectionChanged;

                                    try
                                    {
                                        // Trouver la position d'insertion pour garder le tri par similarité décroissante
                                        int insertIndex = 0;
                                        for (int k = 0; k < comparisonResults.Count; k++)
                                        {
                                            if (result.SimilarityPercentage > comparisonResults[k].SimilarityPercentage)
                                            {
                                                insertIndex = k;
                                                break;
                                            }
                                            insertIndex = k + 1;
                                        }

                                        comparisonResults.Insert(insertIndex, result);

                                        // Insérer la ligne à la bonne position dans le DataGridView
                                        dgvResults.Rows.Insert(insertIndex,
                                            result.Image1Name,
                                            result.Image2Name,
                                            $"{result.SimilarityPercentage:F2} %"
                                        );
                                        dgvResults.Rows[insertIndex].Tag = result;

                                        // Gérer la sélection
                                        if (hadSelection)
                                        {
                                            // Ajuster l'index si une ligne a été insérée avant
                                            if (insertIndex <= selectedIndex)
                                                selectedIndex++;

                                            // Désélectionner la ligne nouvellement insérée
                                            dgvResults.Rows[insertIndex].Selected = false;

                                            // Restaurer la sélection de l'utilisateur
                                            if (selectedIndex < dgvResults.Rows.Count)
                                            {
                                                dgvResults.Rows[selectedIndex].Selected = true;
                                            }
                                        }
                                        else
                                        {
                                            // Pas de sélection: désélectionner la ligne insérée
                                            dgvResults.Rows[insertIndex].Selected = false;
                                        }
                                    }
                                    finally
                                    {
                                        // Réactiver l'événement
                                        dgvResults.SelectionChanged += dgvResults_SelectionChanged;
                                    }

                                    lock (lockObj)
                                    {
                                        currentComparison++;
                                        progressBar.Value = currentComparison;

                                        // Calculer le temps restant estimé
                                        var elapsed = (DateTime.Now - startTime).TotalSeconds;
                                        if (currentComparison > 0 && elapsed > 0)
                                        {
                                            double avgTimePerComparison = elapsed / currentComparison;
                                            int remaining = totalComparisons - currentComparison;
                                            double estimatedSecondsLeft = avgTimePerComparison * remaining;

                                            string timeLeft = "";
                                            if (estimatedSecondsLeft < 60)
                                                timeLeft = $"{(int)estimatedSecondsLeft} sec";
                                            else if (estimatedSecondsLeft < 3600)
                                                timeLeft = $"{(int)(estimatedSecondsLeft / 60)} min {(int)(estimatedSecondsLeft % 60)} sec";
                                            else
                                                timeLeft = $"{(int)(estimatedSecondsLeft / 3600)} heures {(int)((estimatedSecondsLeft % 3600) / 60)} min";

                                            lblProgress.Text = $"Analyse {currentComparison}/{totalComparisons} - Temps restant : {timeLeft}";
                                        }
                                        else
                                        {
                                            lblProgress.Text = $"Analyse {currentComparison}/{totalComparisons}...";
                                        }
                                    }
                                });
                            }
                            catch (Exception ex)
                            {
                                // Ignorer les erreurs de comparaison individuelles
                                System.Diagnostics.Debug.WriteLine($"Erreur lors de la comparaison : {ex.Message}");
                            }
                        });
                });

                lblProgress.Text = $"Analyse terminée : {comparisonResults.Count} résultats";
                progressBar.Value = progressBar.Maximum;
            }
            catch (OperationCanceledException)
            {
                lblProgress.Text = "Analyse annulée";
                progressBar.Value = 0;
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
                // Réactiver les contrôles et restaurer le curseur normal
                this.Cursor = Cursors.Default;
                dgvResults.Cursor = Cursors.Default;
                isAnalyzing = false;
                btnSelectFolder.Enabled = true;
                btnAnalyze.Enabled = true;
                btnCancelAnalysis.Enabled = false;
                cancellationTokenSource?.Dispose();
                cancellationTokenSource = null;
            }
        }

        private void btnCancelAnalysis_Click(object sender, EventArgs e)
        {
            if (cancellationTokenSource != null && !cancellationTokenSource.IsCancellationRequested)
            {
                cancellationTokenSource.Cancel();
                btnCancelAnalysis.Enabled = false;
                lblProgress.Text = "Annulation en cours...";
            }
        }

        private List<string> GetImageFiles(string folderPath)
        {
            var imageExtensions = new[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };
            var imageFiles = new List<string>();

            try
            {
                // Parcourir récursivement tous les sous-dossiers
                var allFiles = Directory.GetFiles(folderPath, "*.*", System.IO.SearchOption.AllDirectories);

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
            dgvResults.SuspendLayout();
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
            }

            dgvResults.ResumeLayout();

            // Désélectionner toutes les lignes
            dgvResults.ClearSelection();
        }

        private void dgvResults_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvResults.Rows.Count)
            {
                var row = dgvResults.Rows[e.RowIndex];
                var result = row.Tag as ComparisonResult;

                if (result != null)
                {
                    // Si une image a été supprimée, utiliser une couleur différente
                    if (result.IsImage1Deleted || result.IsImage2Deleted)
                    {
                        e.CellStyle.BackColor = Color.LightBlue;
                        e.CellStyle.SelectionBackColor = Color.LightSkyBlue;
                    }
                    else
                    {
                        // Colorer la ligne en fonction de la similarité (couleurs opaques pour éviter les problèmes de rendu)
                        Color rowColor = GetSimilarityColorOpaque(result.SimilarityPercentage);
                        e.CellStyle.BackColor = rowColor;

                        // Assombrir légèrement pour la sélection
                        Color selectionColor = Color.FromArgb(
                            Math.Max(0, rowColor.R - 40),
                            Math.Max(0, rowColor.G - 40),
                            Math.Max(0, rowColor.B - 40)
                        );
                        e.CellStyle.SelectionBackColor = selectionColor;
                    }

                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.SelectionForeColor = Color.Black;
                }
            }
        }

        private Color GetSimilarityColor(float similarity)
        {
            if (similarity >= 90) return Color.FromArgb(231, 76, 60);    // Rouge (très similaire)
            if (similarity >= 70) return Color.FromArgb(243, 156, 18);   // Orange
            if (similarity >= 50) return Color.FromArgb(241, 196, 15);   // Jaune
            return Color.FromArgb(149, 165, 166);                        // Gris
        }

        private Color GetSimilarityColorOpaque(float similarity)
        {
            if (similarity >= 90) return Color.FromArgb(200, 255, 200);  // Vert clair (doublons probables)
            if (similarity >= 70) return Color.FromArgb(255, 220, 150);  // Orange clair (attention)
            return Color.FromArgb(255, 180, 180);                        // Rouge clair (images différentes)
        }

        private void dgvResults_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvResults.SelectedRows.Count > 0)
            {
                var selectedRow = dgvResults.SelectedRows[0];
                var result = selectedRow.Tag as ComparisonResult;

                if (result != null)
                {
                    // Afficher les chemins complets des images
                    txtImagePath1.Text = result.Image1Path;
                    txtImagePath2.Text = result.Image2Path;
                    txtImagePath1.Visible = true;
                    txtImagePath2.Visible = true;

                    // Afficher les tailles des fichiers
                    lblSize1.Text = GetFileSize(result.Image1Path);
                    lblSize2.Text = GetFileSize(result.Image2Path);
                    lblSize1.Visible = true;
                    lblSize2.Visible = true;

                    // Afficher les noms de fichiers
                    lblFileName1.Text = Path.GetFileName(result.Image1Path);
                    lblFileName2.Text = Path.GetFileName(result.Image2Path);
                    lblFileName1.Visible = true;
                    lblFileName2.Visible = true;

                    // Afficher les images
                    LoadImageToPanel(pictureBox1, result.Image1Path);
                    LoadImageToPanel(pictureBox2, result.Image2Path);

                    // Activer/désactiver les boutons de suppression
                    btnDeleteImage1.Enabled = !result.IsImage1Deleted && File.Exists(result.Image1Path);
                    btnDeleteImage2.Enabled = !result.IsImage2Deleted && File.Exists(result.Image2Path);
                    btnDeleteImage1.Visible = true;
                    btnDeleteImage2.Visible = true;

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
                        // Créer une copie de l'image
                        var bitmap = new Bitmap(img);

                        // Corriger l'orientation selon les métadonnées EXIF
                        if (Array.IndexOf(img.PropertyIdList, 0x0112) > -1)
                        {
                            var orientation = (int)img.GetPropertyItem(0x0112).Value[0];
                            switch (orientation)
                            {
                                case 3: // Rotation 180°
                                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                    break;
                                case 6: // Rotation 90° horaire
                                    bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                    break;
                                case 8: // Rotation 90° anti-horaire
                                    bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                    break;
                            }
                        }

                        pictureBox.Image = bitmap;
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

            txtImagePath1.Text = "";
            txtImagePath2.Text = "";
            txtImagePath1.Visible = false;
            txtImagePath2.Visible = false;

            lblSize1.Text = "";
            lblSize2.Text = "";
            lblSize1.Visible = false;
            lblSize2.Visible = false;

            lblFileName1.Text = "";
            lblFileName2.Text = "";
            lblFileName1.Visible = false;
            lblFileName2.Visible = false;

            btnDeleteImage1.Enabled = false;
            btnDeleteImage2.Enabled = false;
            btnDeleteImage1.Visible = false;
            btnDeleteImage2.Visible = false;
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
                $"Êtes-vous sûr de vouloir supprimer le fichier ?\n\n{imageName}",
                "Confirmation de suppression",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

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

                    // Envoyer le fichier à la corbeille
                    FileSystem.DeleteFile(imagePath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);

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

                    // Forcer le rafraîchissement de la ligne
                    dgvResults.InvalidateRow(row.Index);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la suppression du fichier :\n{ex.Message}",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string GetFileSize(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    long sizeInBytes = fileInfo.Length;

                    if (sizeInBytes < 1024)
                        return $"{sizeInBytes} o";
                    else if (sizeInBytes < 1024 * 1024)
                        return $"{sizeInBytes / 1024.0:F1} Ko";
                    else
                        return $"{sizeInBytes / (1024.0 * 1024.0):F1} Mo";
                }
            }
            catch { }

            return "";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Libérer les ressources des images
            ClearPreview();
            base.OnFormClosing(e);
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private Cursor LoadCustomCursor(int cursorId)
        {
            try
            {
                // Créer un curseur loupe personnalisé avec contour blanc
                Bitmap bmp = new Bitmap(32, 32);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.Clear(Color.Transparent);

                    // Dessiner un contour blanc épais pour le contraste
                    using (Pen penWhite = new Pen(Color.White, 4))
                    {
                        // Cercle de la loupe blanc
                        g.DrawEllipse(penWhite, 4, 4, 16, 16);
                        // Manche de la loupe blanc
                        g.DrawLine(penWhite, 17, 17, 26, 26);
                    }

                    // Dessiner la loupe noire par dessus
                    using (Pen penBlack = new Pen(Color.Black, 2))
                    {
                        // Cercle de la loupe
                        g.DrawEllipse(penBlack, 4, 4, 16, 16);
                        // Manche de la loupe
                        g.DrawLine(penBlack, 17, 17, 26, 26);
                    }

                    // Signe + au centre pour indiquer le zoom
                    using (Pen penPlus = new Pen(Color.DodgerBlue, 2))
                    {
                        g.DrawLine(penPlus, 12, 9, 12, 15); // Ligne verticale
                        g.DrawLine(penPlus, 9, 12, 15, 12); // Ligne horizontale
                    }
                }

                // Convertir en curseur avec le hotspot au centre du cercle
                IntPtr hIcon = bmp.GetHicon();
                Cursor cursor = new Cursor(hIcon);
                return cursor;
            }
            catch { }
            return Cursors.Hand; // Fallback si le curseur personnalisé échoue
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb?.Image == null) return;

            // Créer une fenêtre de zoom avec style Metro
            var zoomForm = new MetroFramework.Forms.MetroForm
            {
                Text = "",
                Size = new Size(800, 600),
                StartPosition = FormStartPosition.CenterParent,
                KeyPreview = true,
                Resizable = true,
                MaximizeBox = true,
                MinimizeBox = false,
                DisplayHeader = false,
                ShowInTaskbar = false
            };

            PictureBox zoomPictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = (Image)pb.Image.Clone(),
                BackColor = Color.Black
            };

            // Fermer avec un clic
            zoomPictureBox.MouseClick += (s, ev) => zoomForm.Close();

            // Fermer avec la touche Escape
            zoomForm.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Escape)
                {
                    zoomForm.Close();
                }
            };

            zoomForm.Controls.Add(zoomPictureBox);
            zoomForm.ShowDialog(this);
            zoomPictureBox.Image?.Dispose();
        }
    }
}
