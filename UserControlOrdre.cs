// CalculsCE1 : programme d'entrainement au calcul - niveau CE1
// Copyright © 2011 René DEVICHI

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CalculsCE1
{
    public partial class UserControlOrdre : UserControl, IUserControlCalcul
    {
        public event EventHandler CheckResponse;
        public event EventHandler AlgoChanged;

        public IButtonControl AcceptButton
        {
            get { return buttonCheck; }
        }

        public int Duree
        {
            get { return 60; }
        }


        private Label[] labels;
        private NumericBox[] boxes;
        private Label[] signes;
        private Random rand = new Random();
        private int N = 3;

        Font font;

        int[] x;
        bool croissant;


        class ordre : IComparer<int>
        {
            bool croissant;
            public ordre(bool croissant)
            {
                this.croissant = croissant;
            }

            public int Compare(int x, int y)
            {
                if (croissant) 
                    return x - y; 
                else 
                    return y - x;
            }
        }

        public UserControlOrdre()
        {
            InitializeComponent();
        }


        private void InitControls(Point A, Size B)
        {
            this.SuspendLayout();

            if (labels != null)
            {
                foreach (Control c in labels) Controls.Remove(c);
            }
            if (boxes != null)
            {
                foreach (Control c in boxes) Controls.Remove(c);
            }
            if (signes != null)
            {
                foreach (Control c in signes) Controls.Remove(c);
            }


            font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            labels = new Label[N];
            boxes = new NumericBox[N];
            signes = new Label[N - 1];

            int dx = 58 + 32;

            for (int i = 0; i < N; ++i)
            {
                Label l = new Label();

                l.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                l.Font = font;
                l.ForeColor = System.Drawing.SystemColors.GrayText;
                l.Location = new System.Drawing.Point(A.X + dx * i, A.Y);
                l.Size = new System.Drawing.Size(58, 47);
                l.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelN_MouseDown);

                labels[i] = l;
                this.Controls.Add(l);


                NumericBox b = new NumericBox();

                b.MaxLength = 2;
                b.AllowDrop = true;
                b.Font = font;
                b.Location = new System.Drawing.Point(A.X + dx * i, A.Y + B.Height - 47);
                b.Size = new System.Drawing.Size(58, 47);
                b.TabIndex = i;
                b.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxZ_DragDrop);
                b.DragOver += new System.Windows.Forms.DragEventHandler(this.textBoxZ_DragOver);

                boxes[i] = b;
                this.Controls.Add(b);

                if (i > 0)
                {
                    Label signe = new Label();
                    signe.Font = font;
                    signe.Location = new System.Drawing.Point(A.X + 58 + dx * (i - 1), A.Y + B.Height - 47 + 3);
                    signe.Size = new System.Drawing.Size(32, 39);
                    signe.Text = "<";
                    signes[i - 1] = signe;
                    this.Controls.Add(signe);
                }
            }

            //panel1.Hide();
            Controls.Remove(panel1);
            Controls.Add(panel1);

            this.ResumeLayout();

            Encore();
        }



        private void textBoxZ_DragDrop(object sender, DragEventArgs e)
        {
            Label x = e.Data.GetData(typeof(Label)) as Label;
            (sender as TextBox).Text = x.Text;
        }

        private void textBoxZ_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void labelN_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Label).DoDragDrop(sender, DragDropEffects.Move);
        }


        private void buttonCheck_Click(object sender, EventArgs e)
        {
            CheckResponse(sender, e);
        }


        public ResultatCalcul Vérifie(out string resultat)
        {
            int[] x_triés = new int[N];
            int[] z = new int[N];
            int[] z_triés = new int[N];

            try
            {
                for (int i = 0; i < N; ++i)
                {
                    z[i] = boxes[i].Integer;
                }
            }
            catch
            {
                resultat = "";
                return ResultatCalcul.ErreurSaisie;            
            }

            
            x.CopyTo(x_triés, 0);
            Array.Sort(x_triés, new ordre(croissant));

            z.CopyTo(z_triés, 0);
            Array.Sort(z_triés, new ordre(croissant));

            for (int i = 0; i < N; ++i)
            {
                if (x_triés[i] != z_triés[i])
                {
                    resultat = "ERREUR DE NOMBRE";
                    return ResultatCalcul.Erreur;
                }
            }

            for (int i = 0; i < N; ++i)
            {
                if (x_triés[i] != z[i])
                {
                    resultat = "ERREUR DE TRI";
                    return ResultatCalcul.Erreur;
                }
            }

            resultat = "OK";
            return ResultatCalcul.OK;
        }


        public void Init(int N)
        {
            if (N < 3 || N > 8) return;

            this.N = N;
            panel1.Location = new Point(11, 111);
            panel1.Size = new Size(688, 136);

            int n = N * 58 + (N - 1) * 32;

            panel1.Location = new Point(panel1.Location.X + (panel1.Size.Width - n) / 2, panel1.Location.Y);
            panel1.Size = new Size(n, 136);

            InitControls(panel1.Location, panel1.Size);

            panel1.Location = panel1.Location - new Size(2, 2);
            panel1.Size = panel1.Size + new Size(4, 4);

            checkBox1_Click(null, null);
            AlgoChanged(null, null);
        }


        private void check(int n, string signe, string ordre)
        {
            checkBox1.Checked = (n == 1);
            checkBox2.Checked = (n == 2);

            for (int i = 0; i < N - 1; ++i)
            {
                signes[i].Text = signe;
            }

            labelQuestion.Text = string.Format("Trie les nombres par ordre {0} :", ordre);

            boxes[0].Focus();
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            check(1, "≤", checkBox1.Text);
            croissant = true;

        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            check(2, "≥", checkBox2.Text);
            croissant = false;
        }

        private void buttonErase_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < N; ++i)
            {
                boxes[i].Text = "";
            }

            boxes[0].Focus();
        }


        public void Encore()
        {
            buttonErase_Click(null, null);

            x = new int[N];

            //TODO
            for (int i = 0; i < N; ++i)
            {
                x[i] = rand.Next(1, 99);
            }

            for (int i = 0; i < N; ++i)
            {
                labels[i].Text = x[i].ToString();
            }            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Init((int)numericUpDown1.Value);
        }

        private void UserControlOrdre_Load(object sender, EventArgs e)
        {
            this.Text = "Ordre croissant et décroissant";
        }       
    }
}