namespace CalculsCE1
{
    partial class FormCalculAlgo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCalculAlgo));
            this.ucCalcul = new CalculsCE1.UserControlAlgo();
            this.ucResult = new CalculsCE1.UserControlResult();
            this.SuspendLayout();
            // 
            // userControl11
            // 
            this.ucCalcul.BackColor = System.Drawing.SystemColors.Control;
            this.ucCalcul.Location = new System.Drawing.Point(0, 0);
            this.ucCalcul.Name = "userControl11";
            this.ucCalcul.Size = new System.Drawing.Size(810, 261);
            this.ucCalcul.TabIndex = 0;
            this.ucCalcul.CheckResponse += new System.EventHandler(this.ucCalcul_CheckResponse);
            this.ucCalcul.AlgoChanged += new System.EventHandler(this.ucCalcul_AlgoChanged);
            // 
            // userControl12
            // 
            this.ucResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucResult.Location = new System.Drawing.Point(0, 296);
            this.ucResult.Name = "userControl12";
            this.ucResult.Size = new System.Drawing.Size(810, 247);
            this.ucResult.TabIndex = 1;            
            // 
            // FormAlgo2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 543);
            this.Controls.Add(this.ucResult);
            this.Controls.Add(this.ucCalcul);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FormAlgo2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Les x, y et z";
            this.Load += new System.EventHandler(this.FormCalculAlgo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControlAlgo ucCalcul;
        private UserControlResult ucResult;
    }
}

