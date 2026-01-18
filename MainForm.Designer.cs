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
            this.btnDeleteImage1 = new MetroFramework.Controls.MetroButton();
            this.btnDeleteImage2 = new MetroFramework.Controls.MetroButton();
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
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(302, 148);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(472, 31);
            this.progressBar.TabIndex = 4;
            // 
            // lblProgress
            // 
            this.lblProgress.Location = new System.Drawing.Point(320, 178);
            this.lblProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(453, 25);
            this.lblProgress.TabIndex = 5;
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
            this.pictureBox1.Location = new System.Drawing.Point(13, 47);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(346, 186);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(380, 47);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(346, 186);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // txtImagePath1
            // 
            this.txtImagePath1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtImagePath1.Location = new System.Drawing.Point(13, 8);
            this.txtImagePath1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtImagePath1.Name = "txtImagePath1";
            this.txtImagePath1.ReadOnly = true;
            this.txtImagePath1.Size = new System.Drawing.Size(346, 25);
            this.txtImagePath1.TabIndex = 4;
            this.txtImagePath1.Visible = false;
            // 
            // txtImagePath2
            // 
            this.txtImagePath2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtImagePath2.Location = new System.Drawing.Point(380, 8);
            this.txtImagePath2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtImagePath2.Name = "txtImagePath2";
            this.txtImagePath2.ReadOnly = true;
            this.txtImagePath2.Size = new System.Drawing.Size(346, 25);
            this.txtImagePath2.TabIndex = 5;
            this.txtImagePath2.Visible = false;
            // 
            // btnDeleteImage1
            // 
            this.btnDeleteImage1.Enabled = false;
            this.btnDeleteImage1.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnDeleteImage1.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnDeleteImage1.Location = new System.Drawing.Point(87, 242);
            this.btnDeleteImage1.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteImage1.Name = "btnDeleteImage1";
            this.btnDeleteImage1.Size = new System.Drawing.Size(200, 37);
            this.btnDeleteImage1.TabIndex = 2;
            this.btnDeleteImage1.Text = "🗑️ Supprimer";
            this.btnDeleteImage1.UseSelectable = true;
            this.btnDeleteImage1.Visible = false;
            this.btnDeleteImage1.Click += new System.EventHandler(this.btnDeleteImage1_Click);
            // 
            // btnDeleteImage2
            // 
            this.btnDeleteImage2.Enabled = false;
            this.btnDeleteImage2.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnDeleteImage2.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnDeleteImage2.Location = new System.Drawing.Point(453, 242);
            this.btnDeleteImage2.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteImage2.Name = "btnDeleteImage2";
            this.btnDeleteImage2.Size = new System.Drawing.Size(200, 37);
            this.btnDeleteImage2.TabIndex = 3;
            this.btnDeleteImage2.Text = "🗑️ Supprimer";
            this.btnDeleteImage2.UseSelectable = true;
            this.btnDeleteImage2.Visible = false;
            this.btnDeleteImage2.Click += new System.EventHandler(this.btnDeleteImage2_Click);
            // 
            // panelPreview
            // 
            this.panelPreview.Controls.Add(this.btnDeleteImage2);
            this.panelPreview.Controls.Add(this.btnDeleteImage1);
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
            this.panelPreview.Size = new System.Drawing.Size(746, 295);
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
        private MetroFramework.Controls.MetroButton btnDeleteImage1;
        private MetroFramework.Controls.MetroButton btnDeleteImage2;
        private MetroFramework.Controls.MetroPanel panelPreview;
    }
}
