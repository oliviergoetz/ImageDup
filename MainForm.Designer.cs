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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new MetroFramework.Controls.MetroLabel();
            this.btnSelectFolder = new MetroFramework.Controls.MetroButton();
            this.lblSelectedFolder = new MetroFramework.Controls.MetroLabel();
            this.btnAnalyze = new MetroFramework.Controls.MetroButton();
            this.lblImageCount = new MetroFramework.Controls.MetroLabel();
            this.btnCancelAnalysis = new MetroFramework.Controls.MetroButton();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new MetroFramework.Controls.MetroLabel();
            this.dgvResults = new MetroFramework.Controls.MetroGrid();
            this.colImage1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImage2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSimilarity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblVersion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtImagePath1 = new System.Windows.Forms.TextBox();
            this.txtImagePath2 = new System.Windows.Forms.TextBox();
            this.lblSize1 = new System.Windows.Forms.Label();
            this.lblSize2 = new System.Windows.Forms.Label();
            this.btnDeleteImage1 = new MetroFramework.Controls.MetroButton();
            this.btnDeleteImage2 = new MetroFramework.Controls.MetroButton();
            this.lblFileName1 = new System.Windows.Forms.Label();
            this.lblFileName2 = new System.Windows.Forms.Label();
            this.panelPreview = new MetroFramework.Controls.MetroPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelPreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTitle.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTitle.Location = new System.Drawing.Point(20, 60);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(560, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ImageDup - Détection automatique de doublons";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.UseStyleColors = true;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnSelectFolder.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnSelectFolder.Location = new System.Drawing.Point(27, 86);
            this.btnSelectFolder.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(267, 31);
            this.btnSelectFolder.TabIndex = 1;
            this.btnSelectFolder.Text = "Sélectionner un dossier";
            this.btnSelectFolder.UseSelectable = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // lblSelectedFolder
            // 
            this.lblSelectedFolder.Location = new System.Drawing.Point(302, 86);
            this.lblSelectedFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectedFolder.Name = "lblSelectedFolder";
            this.lblSelectedFolder.Size = new System.Drawing.Size(472, 31);
            this.lblSelectedFolder.TabIndex = 2;
            this.lblSelectedFolder.Text = "Aucun dossier sélectionné";
            this.lblSelectedFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Enabled = false;
            this.btnAnalyze.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnAnalyze.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnAnalyze.Highlight = true;
            this.btnAnalyze.Location = new System.Drawing.Point(27, 148);
            this.btnAnalyze.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(267, 31);
            this.btnAnalyze.TabIndex = 3;
            this.btnAnalyze.Text = "Analyser";
            this.btnAnalyze.UseSelectable = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            //
            // lblImageCount
            //
            this.lblImageCount.Location = new System.Drawing.Point(27, 183);
            this.lblImageCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImageCount.Name = "lblImageCount";
            this.lblImageCount.Size = new System.Drawing.Size(267, 23);
            this.lblImageCount.TabIndex = 99;
            this.lblImageCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnCancelAnalysis
            //
            this.btnCancelAnalysis.Enabled = false;
            this.btnCancelAnalysis.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnCancelAnalysis.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnCancelAnalysis.Location = new System.Drawing.Point(688, 148);
            this.btnCancelAnalysis.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelAnalysis.Name = "btnCancelAnalysis";
            this.btnCancelAnalysis.Size = new System.Drawing.Size(86, 31);
            this.btnCancelAnalysis.TabIndex = 4;
            this.btnCancelAnalysis.Text = "Annuler";
            this.btnCancelAnalysis.UseSelectable = true;
            this.btnCancelAnalysis.Click += new System.EventHandler(this.btnCancelAnalysis_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(302, 148);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(379, 31);
            this.progressBar.TabIndex = 5;
            // 
            // lblProgress
            // 
            this.lblProgress.Location = new System.Drawing.Point(302, 183);
            this.lblProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(379, 25);
            this.lblProgress.TabIndex = 6;
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AllowUserToOrderColumns = true;
            this.dgvResults.AllowUserToResizeRows = false;
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResults.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvResults.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImage1,
            this.colImage2,
            this.colSimilarity});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResults.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvResults.EnableHeadersVisualStyles = false;
            this.dgvResults.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvResults.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvResults.Location = new System.Drawing.Point(27, 215);
            this.dgvResults.Margin = new System.Windows.Forms.Padding(4);
            this.dgvResults.MultiSelect = false;
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResults.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.RowHeadersWidth = 51;
            this.dgvResults.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvResults.RowTemplate.Height = 24;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(747, 234);
            this.dgvResults.TabIndex = 6;
            this.dgvResults.SelectionChanged += new System.EventHandler(this.dgvResults_SelectionChanged);
            // 
            // colImage1
            // 
            this.colImage1.HeaderText = "Image 1";
            this.colImage1.MinimumWidth = 6;
            this.colImage1.Name = "colImage1";
            this.colImage1.ReadOnly = true;
            // 
            // colImage2
            // 
            this.colImage2.HeaderText = "Image 2";
            this.colImage2.MinimumWidth = 6;
            this.colImage2.Name = "colImage2";
            this.colImage2.ReadOnly = true;
            // 
            // colSimilarity
            // 
            this.colSimilarity.HeaderText = "Similarité (%)";
            this.colSimilarity.MinimumWidth = 6;
            this.colSimilarity.Name = "colSimilarity";
            this.colSimilarity.ReadOnly = true;
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblVersion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVersion.Location = new System.Drawing.Point(5, 769);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(127, 22);
            this.lblVersion.TabIndex = 8;
            this.lblVersion.Text = "ImageDup v1.0.0";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 41);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(346, 238);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(380, 41);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(346, 238);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // txtImagePath1
            // 
            this.txtImagePath1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtImagePath1.Location = new System.Drawing.Point(47, 10);
            this.txtImagePath1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtImagePath1.Name = "txtImagePath1";
            this.txtImagePath1.ReadOnly = true;
            this.txtImagePath1.Size = new System.Drawing.Size(240, 25);
            this.txtImagePath1.TabIndex = 4;
            this.txtImagePath1.Visible = false;
            // 
            // txtImagePath2
            // 
            this.txtImagePath2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtImagePath2.Location = new System.Drawing.Point(414, 10);
            this.txtImagePath2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtImagePath2.Name = "txtImagePath2";
            this.txtImagePath2.ReadOnly = true;
            this.txtImagePath2.Size = new System.Drawing.Size(240, 25);
            this.txtImagePath2.TabIndex = 5;
            this.txtImagePath2.Visible = false;
            // 
            // lblSize1
            // 
            this.lblSize1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblSize1.ForeColor = System.Drawing.Color.DimGray;
            this.lblSize1.Location = new System.Drawing.Point(290, 10);
            this.lblSize1.Name = "lblSize1";
            this.lblSize1.Size = new System.Drawing.Size(69, 22);
            this.lblSize1.TabIndex = 6;
            this.lblSize1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSize1.Visible = false;
            // 
            // lblSize2
            // 
            this.lblSize2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblSize2.ForeColor = System.Drawing.Color.DimGray;
            this.lblSize2.Location = new System.Drawing.Point(657, 10);
            this.lblSize2.Name = "lblSize2";
            this.lblSize2.Size = new System.Drawing.Size(69, 22);
            this.lblSize2.TabIndex = 7;
            this.lblSize2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSize2.Visible = false;
            // 
            // btnDeleteImage1
            // 
            this.btnDeleteImage1.Enabled = false;
            this.btnDeleteImage1.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnDeleteImage1.Location = new System.Drawing.Point(13, 10);
            this.btnDeleteImage1.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteImage1.Name = "btnDeleteImage1";
            this.btnDeleteImage1.Size = new System.Drawing.Size(30, 27);
            this.btnDeleteImage1.TabIndex = 2;
            this.btnDeleteImage1.Text = "🗑️";
            this.btnDeleteImage1.UseSelectable = true;
            this.btnDeleteImage1.Visible = false;
            this.btnDeleteImage1.Click += new System.EventHandler(this.btnDeleteImage1_Click);
            // 
            // btnDeleteImage2
            // 
            this.btnDeleteImage2.Enabled = false;
            this.btnDeleteImage2.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnDeleteImage2.Location = new System.Drawing.Point(380, 10);
            this.btnDeleteImage2.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteImage2.Name = "btnDeleteImage2";
            this.btnDeleteImage2.Size = new System.Drawing.Size(30, 27);
            this.btnDeleteImage2.TabIndex = 3;
            this.btnDeleteImage2.Text = "🗑️";
            this.btnDeleteImage2.UseSelectable = true;
            this.btnDeleteImage2.Visible = false;
            this.btnDeleteImage2.Click += new System.EventHandler(this.btnDeleteImage2_Click);
            // 
            // lblFileName1
            // 
            this.lblFileName1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblFileName1.ForeColor = System.Drawing.Color.Gray;
            this.lblFileName1.Location = new System.Drawing.Point(13, 280);
            this.lblFileName1.Name = "lblFileName1";
            this.lblFileName1.Size = new System.Drawing.Size(346, 20);
            this.lblFileName1.TabIndex = 8;
            this.lblFileName1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblFileName1.Visible = false;
            // 
            // lblFileName2
            // 
            this.lblFileName2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblFileName2.ForeColor = System.Drawing.Color.Gray;
            this.lblFileName2.Location = new System.Drawing.Point(380, 280);
            this.lblFileName2.Name = "lblFileName2";
            this.lblFileName2.Size = new System.Drawing.Size(346, 20);
            this.lblFileName2.TabIndex = 9;
            this.lblFileName2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblFileName2.Visible = false;
            // 
            // panelPreview
            // 
            this.panelPreview.Controls.Add(this.lblFileName2);
            this.panelPreview.Controls.Add(this.lblFileName1);
            this.panelPreview.Controls.Add(this.btnDeleteImage2);
            this.panelPreview.Controls.Add(this.btnDeleteImage1);
            this.panelPreview.Controls.Add(this.lblSize2);
            this.panelPreview.Controls.Add(this.lblSize1);
            this.panelPreview.Controls.Add(this.txtImagePath2);
            this.panelPreview.Controls.Add(this.txtImagePath1);
            this.panelPreview.Controls.Add(this.pictureBox2);
            this.panelPreview.Controls.Add(this.pictureBox1);
            this.panelPreview.HorizontalScrollbarBarColor = true;
            this.panelPreview.HorizontalScrollbarHighlightOnWheel = false;
            this.panelPreview.HorizontalScrollbarSize = 12;
            this.panelPreview.Location = new System.Drawing.Point(27, 462);
            this.panelPreview.Margin = new System.Windows.Forms.Padding(4);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(746, 310);
            this.panelPreview.TabIndex = 7;
            this.panelPreview.VerticalScrollbarBarColor = true;
            this.panelPreview.VerticalScrollbarHighlightOnWheel = false;
            this.panelPreview.VerticalScrollbarSize = 13;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 794);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.panelPreview);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnCancelAnalysis);
            this.Controls.Add(this.lblImageCount);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.lblSelectedFolder);
            this.Controls.Add(this.btnSelectFolder);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Resizable = false;
            this.Text = "Détection de doublons d\'images";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelPreview.ResumeLayout(false);
            this.panelPreview.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblTitle;
        private MetroFramework.Controls.MetroButton btnSelectFolder;
        private MetroFramework.Controls.MetroLabel lblSelectedFolder;
        private MetroFramework.Controls.MetroButton btnAnalyze;
        private MetroFramework.Controls.MetroLabel lblImageCount;
        private MetroFramework.Controls.MetroButton btnCancelAnalysis;
        private System.Windows.Forms.ProgressBar progressBar;
        private MetroFramework.Controls.MetroLabel lblProgress;
        private MetroFramework.Controls.MetroGrid dgvResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImage1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSimilarity;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtImagePath1;
        private System.Windows.Forms.TextBox txtImagePath2;
        private System.Windows.Forms.Label lblSize1;
        private System.Windows.Forms.Label lblSize2;
        private MetroFramework.Controls.MetroButton btnDeleteImage1;
        private MetroFramework.Controls.MetroButton btnDeleteImage2;
        private System.Windows.Forms.Label lblFileName1;
        private System.Windows.Forms.Label lblFileName2;
        private MetroFramework.Controls.MetroPanel panelPreview;
    }
}
