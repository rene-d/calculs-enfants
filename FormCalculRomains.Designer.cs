namespace CalculsCE1
{
    partial class FormCalculRomains
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCalculRomains));
            this.labelQuestion = new System.Windows.Forms.Label();
            this.labelTitre = new System.Windows.Forms.Label();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.textBoxL = new System.Windows.Forms.TextBox();
            this.ucResult = new CalculsCE1.UserControlResult();
            this.textBoxZ = new CalculsCE1.NumericBox();
            this.checkBoxDifficile = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelQuestion
            // 
            resources.ApplyResources(this.labelQuestion, "labelQuestion");
            this.labelQuestion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelQuestion.Name = "labelQuestion";
            // 
            // labelTitre
            // 
            resources.ApplyResources(this.labelTitre, "labelTitre");
            this.labelTitre.Name = "labelTitre";
            // 
            // buttonCheck
            // 
            this.buttonCheck.Image = global::CalculsCE1.Properties.Resources._112_Tick_Green_32x32_72;
            resources.ApplyResources(this.buttonCheck, "buttonCheck");
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // textBoxL
            // 
            resources.ApplyResources(this.textBoxL, "textBoxL");
            this.textBoxL.Name = "textBoxL";
            this.textBoxL.ReadOnly = true;
            // 
            // ucResult
            // 
            resources.ApplyResources(this.ucResult, "ucResult");
            this.ucResult.Name = "ucResult";
            // 
            // textBoxZ
            // 
            resources.ApplyResources(this.textBoxZ, "textBoxZ");
            this.textBoxZ.Name = "textBoxZ";
            // 
            // checkBoxDifficile
            // 
            resources.ApplyResources(this.checkBoxDifficile, "checkBoxDifficile");
            this.checkBoxDifficile.Name = "checkBoxDifficile";
            this.checkBoxDifficile.UseVisualStyleBackColor = true;
            this.checkBoxDifficile.CheckedChanged += new System.EventHandler(this.checkBoxDifficile_CheckedChanged);
            // 
            // FormCalculRomains
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxDifficile);
            this.Controls.Add(this.textBoxL);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.ucResult);
            this.Controls.Add(this.textBoxZ);
            this.Controls.Add(this.labelTitre);
            this.Controls.Add(this.labelQuestion);
            this.Name = "FormCalculRomains";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelQuestion;
        private NumericBox textBoxZ;
        private UserControlResult ucResult;
        private System.Windows.Forms.Label labelTitre;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.TextBox textBoxL;
        private System.Windows.Forms.CheckBox checkBoxDifficile;

    }
}