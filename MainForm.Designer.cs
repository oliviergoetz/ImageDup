namespace ImageDup
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new MetroFramework.Controls.MetroLabel();
            this.btnSelectFolder = new MetroFramework.Controls.MetroButton();
            this.lblSelectedFolder = new MetroFramework.Controls.MetroLabel();
            this.btnAnalyze = new MetroFramework.Controls.MetroButton();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new MetroFramework.Controls.MetroLabel();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.colImage1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImage2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSimilarity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelPreview = new MetroFramework.Controls.MetroPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnDeleteImage1 = new MetroFramework.Controls.MetroButton();
            this.btnDeleteImage2 = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.panelPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTitle.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTitle.Location = new System.Drawing.Point(20, 60);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(760, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ImageDup - Détection automatique de doublons";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.UseStyleColors = true;
            //
            // btnSelectFolder
            //
            this.btnSelectFolder.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnSelectFolder.Location = new System.Drawing.Point(20, 110);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(200, 40);
            this.btnSelectFolder.TabIndex = 1;
            this.btnSelectFolder.Text = "Sélectionner un dossier";
            this.btnSelectFolder.UseSelectable = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            //
            // lblSelectedFolder
            //
            this.lblSelectedFolder.Location = new System.Drawing.Point(240, 110);
            this.lblSelectedFolder.Name = "lblSelectedFolder";
            this.lblSelectedFolder.Size = new System.Drawing.Size(540, 40);
            this.lblSelectedFolder.TabIndex = 2;
            this.lblSelectedFolder.Text = "Aucun dossier sélectionné";
            this.lblSelectedFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // btnAnalyze
            //
            this.btnAnalyze.Enabled = false;
            this.btnAnalyze.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnAnalyze.FontWeight = MetroFramework.MetroButtonWeight.Bold;
            this.btnAnalyze.Highlight = true;
            this.btnAnalyze.Location = new System.Drawing.Point(20, 165);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(200, 50);
            this.btnAnalyze.TabIndex = 3;
            this.btnAnalyze.Text = "Analyser";
            this.btnAnalyze.UseSelectable = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            //
            // progressBar
            //
            this.progressBar.Location = new System.Drawing.Point(240, 165);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(540, 30);
            this.progressBar.TabIndex = 4;
            //
            // lblProgress
            //
            this.lblProgress.Location = new System.Drawing.Point(240, 195);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(540, 20);
            this.lblProgress.TabIndex = 5;
            this.lblProgress.Text = "";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            //
            // dgvResults
            //
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImage1,
            this.colImage2,
            this.colSimilarity});
            this.dgvResults.Location = new System.Drawing.Point(20, 230);
            this.dgvResults.MultiSelect = false;
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(760, 250);
            this.dgvResults.TabIndex = 6;
            this.dgvResults.SelectionChanged += new System.EventHandler(this.dgvResults_SelectionChanged);
            //
            // colImage1
            //
            this.colImage1.HeaderText = "Image 1";
            this.colImage1.Name = "colImage1";
            this.colImage1.ReadOnly = true;
            //
            // colImage2
            //
            this.colImage2.HeaderText = "Image 2";
            this.colImage2.Name = "colImage2";
            this.colImage2.ReadOnly = true;
            //
            // colSimilarity
            //
            this.colSimilarity.HeaderText = "Similarité (%)";
            this.colSimilarity.Name = "colSimilarity";
            this.colSimilarity.ReadOnly = true;
            //
            // panelPreview
            //
            this.panelPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPreview.Controls.Add(this.btnDeleteImage2);
            this.panelPreview.Controls.Add(this.btnDeleteImage1);
            this.panelPreview.Controls.Add(this.pictureBox2);
            this.panelPreview.Controls.Add(this.pictureBox1);
            this.panelPreview.HorizontalScrollbarBarColor = true;
            this.panelPreview.HorizontalScrollbarHighlightOnWheel = false;
            this.panelPreview.HorizontalScrollbarSize = 10;
            this.panelPreview.Location = new System.Drawing.Point(20, 495);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(760, 280);
            this.panelPreview.TabIndex = 7;
            this.panelPreview.VerticalScrollbarBarColor = true;
            this.panelPreview.VerticalScrollbarHighlightOnWheel = false;
            this.panelPreview.VerticalScrollbarSize = 10;
            //
            // pictureBox1
            //
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(15, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 210);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            //
            // pictureBox2
            //
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(385, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(350, 210);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            //
            // btnDeleteImage1
            //
            this.btnDeleteImage1.Enabled = false;
            this.btnDeleteImage1.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnDeleteImage1.Location = new System.Drawing.Point(115, 235);
            this.btnDeleteImage1.Name = "btnDeleteImage1";
            this.btnDeleteImage1.Size = new System.Drawing.Size(150, 30);
            this.btnDeleteImage1.TabIndex = 2;
            this.btnDeleteImage1.Text = "🗑️ Supprimer";
            this.btnDeleteImage1.UseSelectable = true;
            this.btnDeleteImage1.Click += new System.EventHandler(this.btnDeleteImage1_Click);
            //
            // btnDeleteImage2
            //
            this.btnDeleteImage2.Enabled = false;
            this.btnDeleteImage2.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnDeleteImage2.Location = new System.Drawing.Point(485, 235);
            this.btnDeleteImage2.Name = "btnDeleteImage2";
            this.btnDeleteImage2.Size = new System.Drawing.Size(150, 30);
            this.btnDeleteImage2.TabIndex = 3;
            this.btnDeleteImage2.Text = "🗑️ Supprimer";
            this.btnDeleteImage2.UseSelectable = true;
            this.btnDeleteImage2.Click += new System.EventHandler(this.btnDeleteImage2_Click);
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 795);
            this.Controls.Add(this.panelPreview);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.lblSelectedFolder);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.lblTitle);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.Text = "ImageDup - Détection de doublons";
            this.Theme = MetroFramework.MetroThemeStyle.Light;
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.panelPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblTitle;
        private MetroFramework.Controls.MetroButton btnSelectFolder;
        private MetroFramework.Controls.MetroLabel lblSelectedFolder;
        private MetroFramework.Controls.MetroButton btnAnalyze;
        private System.Windows.Forms.ProgressBar progressBar;
        private MetroFramework.Controls.MetroLabel lblProgress;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImage1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSimilarity;
        private MetroFramework.Controls.MetroPanel panelPreview;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private MetroFramework.Controls.MetroButton btnDeleteImage1;
        private MetroFramework.Controls.MetroButton btnDeleteImage2;
    }
}
