namespace CalculsCE1
{
    partial class FormCalculProblemes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCalculProblemes));
            this.labelQuestion = new System.Windows.Forms.Label();
            this.textBoxP1 = new System.Windows.Forms.RichTextBox();
            this.textBoxP2 = new System.Windows.Forms.RichTextBox();
            this.labelTitre = new System.Windows.Forms.Label();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxDifficile = new System.Windows.Forms.CheckBox();
            this.ucResult = new CalculsCE1.UserControlResult();
            this.textBoxZ1 = new CalculsCE1.NumericBox();
            this.textBoxZ2 = new CalculsCE1.NumericBox();
            this.SuspendLayout();
            // 
            // labelQuestion
            // 
            resources.ApplyResources(this.labelQuestion, "labelQuestion");
            this.labelQuestion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelQuestion.Name = "labelQuestion";
            // 
            // textBoxP1
            // 
            resources.ApplyResources(this.textBoxP1, "textBoxP1");
            this.textBoxP1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxP1.DetectUrls = false;
            this.textBoxP1.Name = "textBoxP1";
            this.textBoxP1.ReadOnly = true;
            // 
            // textBoxP2
            // 
            resources.ApplyResources(this.textBoxP2, "textBoxP2");
            this.textBoxP2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxP2.DetectUrls = false;
            this.textBoxP2.Name = "textBoxP2";
            this.textBoxP2.ReadOnly = true;
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
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(223)))));
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label3.Name = "label3";
            // 
            // checkBoxDifficile
            // 
            resources.ApplyResources(this.checkBoxDifficile, "checkBoxDifficile");
            this.checkBoxDifficile.Name = "checkBoxDifficile";
            this.checkBoxDifficile.UseVisualStyleBackColor = true;
            this.checkBoxDifficile.CheckedChanged += new System.EventHandler(this.checkBoxDifficile_CheckedChanged);
            // 
            // ucResult
            // 
            resources.ApplyResources(this.ucResult, "ucResult");
            this.ucResult.Name = "ucResult";
            // 
            // textBoxZ1
            // 
            resources.ApplyResources(this.textBoxZ1, "textBoxZ1");
            this.textBoxZ1.Name = "textBoxZ1";
            // 
            // textBoxZ2
            // 
            resources.ApplyResources(this.textBoxZ2, "textBoxZ2");
            this.textBoxZ2.Name = "textBoxZ2";
            // 
            // FormCalculProblemes
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxDifficile);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.ucResult);
            this.Controls.Add(this.textBoxZ1);
            this.Controls.Add(this.textBoxZ2);
            this.Controls.Add(this.textBoxP2);
            this.Controls.Add(this.textBoxP1);
            this.Controls.Add(this.labelTitre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelQuestion);
            this.Name = "FormCalculProblemes";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.RichTextBox textBoxP1;
        private System.Windows.Forms.RichTextBox textBoxP2;
        private NumericBox textBoxZ2;
        private UserControlResult ucResult;
        private System.Windows.Forms.Label labelTitre;
        private System.Windows.Forms.Button buttonCheck;
        private NumericBox textBoxZ1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxDifficile;

    }
}