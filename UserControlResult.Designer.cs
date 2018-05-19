namespace CalculsCE1
{
    partial class UserControlResult
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBoxStar = new System.Windows.Forms.PictureBox();
            this.buttonAjoutEnfant = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxPrenom = new System.Windows.Forms.ComboBox();
            this.listBoxHistorique = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabelSucces = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelErreurs = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelHeure = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelBravo = new System.Windows.Forms.Label();
            this.pictureBoxPhoto = new System.Windows.Forms.PictureBox();
            this.timerEncore = new System.Windows.Forms.Timer(this.components);
            this.timerHeure = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timerProgressBar = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStar)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxStar
            // 
            this.pictureBoxStar.Image = global::CalculsCE1.Properties.Resources.étoile;
            this.pictureBoxStar.Location = new System.Drawing.Point(516, 29);
            this.pictureBoxStar.Name = "pictureBoxStar";
            this.pictureBoxStar.Size = new System.Drawing.Size(96, 96);
            this.pictureBoxStar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxStar.TabIndex = 24;
            this.pictureBoxStar.TabStop = false;
            this.pictureBoxStar.Visible = false;
            // 
            // buttonAjoutEnfant
            // 
            this.buttonAjoutEnfant.Image = global::CalculsCE1.Properties.Resources.signe_plus;
            this.buttonAjoutEnfant.Location = new System.Drawing.Point(182, 175);
            this.buttonAjoutEnfant.Name = "buttonAjoutEnfant";
            this.buttonAjoutEnfant.Size = new System.Drawing.Size(34, 32);
            this.buttonAjoutEnfant.TabIndex = 23;
            this.buttonAjoutEnfant.UseVisualStyleBackColor = true;
            this.buttonAjoutEnfant.Click += new System.EventHandler(this.buttonAjoutEnfant_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 24);
            this.label6.TabIndex = 22;
            this.label6.Text = "Prénom :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(668, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Historique :";
            // 
            // comboBoxPrenom
            // 
            this.comboBoxPrenom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPrenom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPrenom.FormattingEnabled = true;
            this.comboBoxPrenom.Location = new System.Drawing.Point(10, 175);
            this.comboBoxPrenom.Name = "comboBoxPrenom";
            this.comboBoxPrenom.Size = new System.Drawing.Size(166, 32);
            this.comboBoxPrenom.TabIndex = 20;
            this.comboBoxPrenom.SelectedIndexChanged += new System.EventHandler(this.comboBoxPrenom_SelectedIndexChanged);
            // 
            // listBoxHistorique
            // 
            this.listBoxHistorique.FormattingEnabled = true;
            this.listBoxHistorique.Location = new System.Drawing.Point(671, 102);
            this.listBoxHistorique.Name = "listBoxHistorique";
            this.listBoxHistorique.Size = new System.Drawing.Size(124, 108);
            this.listBoxHistorique.TabIndex = 19;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabelSucces,
            this.toolStripStatusLabelErreurs,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelHeure});
            this.statusStrip1.Location = new System.Drawing.Point(0, 217);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(808, 30);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.MarqueeAnimationSpeed = 0;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(400, 24);
            this.toolStripProgressBar1.Step = 100;
            // 
            // toolStripStatusLabelSucces
            // 
            this.toolStripStatusLabelSucces.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelSucces.ForeColor = System.Drawing.Color.LimeGreen;
            this.toolStripStatusLabelSucces.Name = "toolStripStatusLabelSucces";
            this.toolStripStatusLabelSucces.Size = new System.Drawing.Size(67, 25);
            this.toolStripStatusLabelSucces.Text = "succès";
            // 
            // toolStripStatusLabelErreurs
            // 
            this.toolStripStatusLabelErreurs.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelErreurs.ForeColor = System.Drawing.Color.OrangeRed;
            this.toolStripStatusLabelErreurs.Name = "toolStripStatusLabelErreurs";
            this.toolStripStatusLabelErreurs.Size = new System.Drawing.Size(72, 25);
            this.toolStripStatusLabelErreurs.Text = "erreurs";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(165, 25);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabelHeure
            // 
            this.toolStripStatusLabelHeure.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelHeure.Image = global::CalculsCE1.Properties.Resources.clock;
            this.toolStripStatusLabelHeure.Name = "toolStripStatusLabelHeure";
            this.toolStripStatusLabelHeure.Size = new System.Drawing.Size(87, 25);
            this.toolStripStatusLabelHeure.Text = "Heure";
            // 
            // labelBravo
            // 
            this.labelBravo.AutoSize = true;
            this.labelBravo.Font = new System.Drawing.Font("Monotype Corsiva", 48F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBravo.ForeColor = System.Drawing.Color.Red;
            this.labelBravo.Location = new System.Drawing.Point(38, 46);
            this.labelBravo.Name = "labelBravo";
            this.labelBravo.Size = new System.Drawing.Size(261, 79);
            this.labelBravo.TabIndex = 17;
            this.labelBravo.Text = "BRAVO !";
            this.labelBravo.Visible = false;
            // 
            // pictureBoxPhoto
            // 
            this.pictureBoxPhoto.Location = new System.Drawing.Point(320, 4);
            this.pictureBoxPhoto.Name = "pictureBoxPhoto";
            this.pictureBoxPhoto.Size = new System.Drawing.Size(165, 207);
            this.pictureBoxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPhoto.TabIndex = 16;
            this.pictureBoxPhoto.TabStop = false;
            // 
            // timerEncore
            // 
            this.timerEncore.Tick += new System.EventHandler(this.timerEncore_Tick);
            // 
            // timerHeure
            // 
            this.timerHeure.Tick += new System.EventHandler(this.timerHeure_Tick);
            // 
            // timerProgressBar
            // 
            this.timerProgressBar.Tick += new System.EventHandler(this.timerProgressBar_Tick);
            // 
            // UserControlResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxStar);
            this.Controls.Add(this.buttonAjoutEnfant);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxPrenom);
            this.Controls.Add(this.listBoxHistorique);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.labelBravo);
            this.Controls.Add(this.pictureBoxPhoto);
            this.Name = "UserControlResult";
            this.Size = new System.Drawing.Size(808, 247);
            this.Load += new System.EventHandler(this.UserControlResult_Load);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.UserControlResult_ControlRemoved);
            this.Resize += new System.EventHandler(this.UserControlResult_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStar)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxStar;
        private System.Windows.Forms.Button buttonAjoutEnfant;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxPrenom;
        private System.Windows.Forms.ListBox listBoxHistorique;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSucces;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelErreurs;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelHeure;
        private System.Windows.Forms.Label labelBravo;
        private System.Windows.Forms.PictureBox pictureBoxPhoto;
        private System.Windows.Forms.Timer timerEncore;
        private System.Windows.Forms.Timer timerHeure;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timerProgressBar;

    }
}
