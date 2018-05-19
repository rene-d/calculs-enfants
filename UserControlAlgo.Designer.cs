namespace CalculsCE1
{
    partial class UserControlAlgo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxNiveaux = new System.Windows.Forms.ComboBox();
            this.labelOper2 = new System.Windows.Forms.Label();
            this.labelOper = new System.Windows.Forms.Label();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.labelQuestion = new System.Windows.Forms.Label();
            this.labelTitre = new System.Windows.Forms.Label();
            this.textBoxZ = new CalculsCE1.NumericBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxNiveaux);
            this.panel1.Location = new System.Drawing.Point(676, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(125, 71);
            this.panel1.TabIndex = 23;
            // 
            // comboBoxNiveaux
            // 
            this.comboBoxNiveaux.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNiveaux.FormattingEnabled = true;
            this.comboBoxNiveaux.Location = new System.Drawing.Point(0, 50);
            this.comboBoxNiveaux.Name = "comboBoxNiveaux";
            this.comboBoxNiveaux.Size = new System.Drawing.Size(125, 21);
            this.comboBoxNiveaux.TabIndex = 0;
            this.comboBoxNiveaux.SelectedIndexChanged += new System.EventHandler(this.comboBoxNiveaux_SelectedIndexChanged);
            // 
            // labelOper2
            // 
            this.labelOper2.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOper2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.labelOper2.Location = new System.Drawing.Point(442, 137);
            this.labelOper2.Name = "labelOper2";
            this.labelOper2.Size = new System.Drawing.Size(74, 108);
            this.labelOper2.TabIndex = 21;
            this.labelOper2.Text = "=";
            this.labelOper2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelOper
            // 
            this.labelOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOper.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.labelOper.Location = new System.Drawing.Point(191, 137);
            this.labelOper.Name = "labelOper";
            this.labelOper.Size = new System.Drawing.Size(84, 108);
            this.labelOper.TabIndex = 22;
            this.labelOper.Text = "×";
            this.labelOper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonCheck
            // 
            this.buttonCheck.Image = global::CalculsCE1.Properties.Resources.validation;
            this.buttonCheck.Location = new System.Drawing.Point(714, 134);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(88, 116);
            this.buttonCheck.TabIndex = 20;
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(517, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 29);
            this.label3.TabIndex = 15;
            this.label3.Text = "Je tape le résultat ici :";
            // 
            // textBoxY
            // 
            this.textBoxY.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxY.Location = new System.Drawing.Point(279, 137);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.ReadOnly = true;
            this.textBoxY.Size = new System.Drawing.Size(158, 116);
            this.textBoxY.TabIndex = 18;
            this.textBoxY.Text = "Y";
            this.textBoxY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxX
            // 
            this.textBoxX.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxX.Location = new System.Drawing.Point(16, 134);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.ReadOnly = true;
            this.textBoxX.Size = new System.Drawing.Size(169, 116);
            this.textBoxX.TabIndex = 17;
            this.textBoxX.Text = "X";
            this.textBoxX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuestion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelQuestion.Location = new System.Drawing.Point(11, 102);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(105, 29);
            this.labelQuestion.TabIndex = 16;
            this.labelQuestion.Text = "question";
            // 
            // labelTitre
            // 
            this.labelTitre.AutoSize = true;
            this.labelTitre.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitre.Location = new System.Drawing.Point(8, 6);
            this.labelTitre.Name = "labelTitre";
            this.labelTitre.Size = new System.Drawing.Size(98, 45);
            this.labelTitre.TabIndex = 14;
            this.labelTitre.Text = "titre";
            // 
            // textBoxZ
            // 
            this.textBoxZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxZ.Location = new System.Drawing.Point(522, 134);
            this.textBoxZ.Name = "textBoxZ";
            this.textBoxZ.Size = new System.Drawing.Size(175, 116);
            this.textBoxZ.TabIndex = 0;
            this.textBoxZ.TextChanged += new System.EventHandler(this.textBoxZ_TextChanged);
            // 
            // UserControlAlgo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.textBoxZ);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.labelQuestion);
            this.Controls.Add(this.labelTitre);
            this.Controls.Add(this.labelOper);
            this.Controls.Add(this.labelOper2);
            this.Name = "UserControlAlgo";
            this.Size = new System.Drawing.Size(810, 260);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxNiveaux;
        private System.Windows.Forms.Label labelOper2;
        private System.Windows.Forms.Label labelOper;
        private System.Windows.Forms.Button buttonCheck;
        private NumericBox textBoxZ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.Label labelTitre;
    }
}
