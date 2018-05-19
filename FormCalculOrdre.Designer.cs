namespace CalculsCE1
{
    partial class FormCalculOrdre
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
            this.ucResult = new CalculsCE1.UserControlResult();
            this.ucCalcul = new CalculsCE1.UserControlOrdre();
            this.SuspendLayout();
            // 
            // ucResult
            // 
            this.ucResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucResult.Location = new System.Drawing.Point(0, 266);
            this.ucResult.Name = "ucResult";
            this.ucResult.Size = new System.Drawing.Size(822, 247);
            this.ucResult.TabIndex = 1;
            // 
            // ucCalcul
            // 
            this.ucCalcul.BackColor = System.Drawing.SystemColors.Control;
            this.ucCalcul.Location = new System.Drawing.Point(0, 0);
            this.ucCalcul.Name = "ucCalcul";
            this.ucCalcul.Size = new System.Drawing.Size(810, 260);
            this.ucCalcul.TabIndex = 0;
            this.ucCalcul.CheckResponse += new System.EventHandler(this.ucCalcul_CheckResponse);
            this.ucCalcul.AlgoChanged += new System.EventHandler(this.ucCalcul_AlgoChanged);
            // 
            // FormCalculOrdre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 513);
            this.Controls.Add(this.ucResult);
            this.Controls.Add(this.ucCalcul);
            this.Name = "FormCalculOrdre";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormCalculOrdre_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControlOrdre ucCalcul;
        private UserControlResult ucResult;

    }
}