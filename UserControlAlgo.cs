// CalculsCE1 : programme d'entrainement au calcul - niveau CE1
// Copyright © 2011 René DEVICHI

using System;
using System.Drawing;
using System.Windows.Forms;

namespace CalculsCE1
{
    public partial class UserControlAlgo : UserControl, IUserControlCalcul
    {
        public event EventHandler CheckResponse;
        public event EventHandler AlgoChanged;

        public IButtonControl AcceptButton
        {
            get { return buttonCheck; }
        }

        public int Duree
        { 
            get { return algo.duree; } 
        }
     
        algo algo
        {
            get
            {
                return algo_;
            }

            set
            {
                algo_ = value;

                labelTitre.Text = value.titre;

                labelOper2.Text = value.oper2;

                labelOper.Visible = textBoxY.Visible = labelOper2.Visible = !value.unaire;

                //toolStripProgressBar1.Maximum = 1000 * value.duree;

                if (!value.unaire)
                {
                    labelOper.Text = value.oper;
                }

                if (value.niveaux <= 1)
                {
                    comboBoxNiveaux.Visible = false;
                }
                else
                {
                    comboBoxNiveaux.BeginUpdate();
                    comboBoxNiveaux.Items.Clear();
                    comboBoxNiveaux.Items.AddRange(value.difficultes);
                    comboBoxNiveaux.Visible = true;
                    comboBoxNiveaux.SelectedIndex = value.niveau;
                    comboBoxNiveaux.EndUpdate();
                }

                // le niveau initial est fixé par l'algo, cependant on force l'affectation
                // pour appeler la callback OnChangeNiveau()
                value.niveau = value.niveau;                

                labelQuestion.Text = value.question;

                AlgoChanged(null, null);
            }
        }
        private algo algo_; // backing field


        // liste des algos supportés
        private algo[] algos = null;

        // les boutons pour choisir l'algo
        RadioButton[] radioButtons;


        public UserControlAlgo()
        {
            InitializeComponent();
        }

        public void Init(algo[] algos)
        {
            // doit être défini avant
            this.algos = algos;

            if (algos.Length > 1)
            {
                radioButtons = new RadioButton[algos.Length];

                for (int i = 0; i < algos.Length; ++i)
                {
                    RadioButton rb = new RadioButton();

                    rb.AutoSize = true;
                    rb.Location = new System.Drawing.Point(3, 23 * (i) + 3);
                    rb.Size = new System.Drawing.Size(85, 17);
                    rb.TabStop = true;
                    rb.Text = algos[i].nom;
                    rb.UseVisualStyleBackColor = true;
                    rb.Tag = algos[i];
                    rb.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);

                    radioButtons[i] = rb;
                }

                panel1.Controls.AddRange(this.radioButtons);

                this.radioButtons[0].Checked = true;
            }
            else
            {
                // forcément algos.Length == 1
                algo = algos[0];

                comboBoxNiveaux.Location = new Point(0, 0);
            }

            //this.Text = algos.Aggregate("Les ", (s, x) => s += x.nom + ", ");

            string s = "Les ";
            for (int i = 0; i < algos.Length - 2; ++i)
                s += algos[i].nom + ", ";

            if (algos.Length >= 2)
                s += algos[algos.Length - 2].nom + " et les ";

            s += algos[algos.Length - 1].nom;

            this.Text = s;
        }

        public void Encore()
        {
            algo.encore();

            buttonCheck.Enabled = false;
            textBoxX.Text = algo.x.ToString();
            textBoxY.Text = algo.y.ToString();
            textBoxZ.Text = "";
            textBoxZ.Focus();
        }

        public ResultatCalcul Vérifie(out string resultat)
        {
            int z;
            if (!int.TryParse(textBoxZ.Text, out z))
            {
                // peu probable avec la NumericBox

                FormErreur.Show("TU DOIS ENTRER UN NOMBRE !");
                //MessageBox.Show("TU DOIS ENTRER UN NOMBRE !", "Calculs CE1", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBoxZ.Focus();
                resultat = "";
                return ResultatCalcul.ErreurSaisie;
            }

            bool ok = algo.vérifie(z, out resultat);

            if (!ok)
            {
                FormErreur.Show(resultat);
                textBoxZ.Focus();
            }
            else
            {
                buttonCheck.Enabled = false;
            }

            return ok ? ResultatCalcul.OK : ResultatCalcul.Erreur;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                algo = (sender as RadioButton).Tag as algo;
            }
        }

        private void comboBoxNiveaux_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (algo.niveau != comboBoxNiveaux.SelectedIndex)
            {
                algo.niveau = comboBoxNiveaux.SelectedIndex;
                labelQuestion.Text = algo.question;

                AlgoChanged(null, null);
            }
        }
        
        private void textBoxZ_TextChanged(object sender, EventArgs e)
        {
            buttonCheck.Enabled = textBoxZ.Text != string.Empty;
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            CheckResponse(sender, e);
        }          
    }
}
