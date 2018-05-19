// CalculsCE1 : programme d'entrainement au calcul - niveau CE1
// Copyright © 2011 René DEVICHI

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Deployment.Application;

namespace CalculsCE1
{
    public partial class FormEnfants : Form
    {
        // la liste d'images pour le ListView
        ImageList il;

        public FormEnfants()
        {
            InitializeComponent();
        }

        private void FormEnfants_Load(object sender, EventArgs e)
        {
            //toolStripSeparator1.Visible = false;
            //toolStripButtonDownload.Visible = false;

            toolStripSeparator1.Visible = true;
            toolStripButtonDownload.Visible = true;
            toolStripButtonDownload.Enabled = ApplicationDeployment.IsNetworkDeployed                 
                && !ApplicationDeployment.CurrentDeployment.IsFileGroupDownloaded("Famille");

            listView1.Items.Clear();

            il = new ImageList();
            il.ImageSize = new Size(96, 96);
            il.ColorDepth = ColorDepth.Depth32Bit;
            
            listView1.LargeImageList = il;
            listView1.Sorting = SortOrder.None;
            listView1.LabelEdit = true;

            foreach (var i in Enfants.enfants)
            {
                il.Images.Add(i.key, i.thumbnail);

                ListViewItem lvi = new ListViewItem(i.prenom);
                lvi.ImageKey = i.key;
                lvi.Tag = i;

                if (i.BuiltIn)
                {
                    lvi.Font = new Font(listView1.Font, FontStyle.Italic);
                }

                listView1.Items.Add(lvi);
            }
        }

        private void FormEnfants_FormClosing(object sender, FormClosingEventArgs e)
        {
            //TODO mémoriser la taille de la fenêtre
        }

        private void toolStripButtonAjout_Click(object sender, EventArgs e)
        {               
            InputBoxResult ibr = InputBox.Show("Entrez le prénom de l'enfant à ajouter :", "Ajout d'un prénom");

            ibr.Text = ibr.Text.Trim();
            if (ibr.ReturnCode != DialogResult.OK || ibr.Text == "")
                return;

            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Choisir la photo (au format 35x45 si possible) de " + ibr.Text;
            ofd.Filter = "Tout format d'image|*.png;*.jpg;*.jpeg;*.gif;*.bmp;*.tiff;*.tif|Tous les fichiers|*";
            ofd.RestoreDirectory = true;
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            Enfant ef = new Enfant(ibr.Text, ofd.FileName);
            
            il.Images.Add(ef.key, ef.thumbnail);

            ListViewItem lvi = new ListViewItem(ibr.Text);
            lvi.ImageKey = ef.key;
            lvi.Tag = ef;

            listView1.Items.Add(lvi);
        }


        private void toolStripButtonOk_Click(object sender, EventArgs e)
        {
            List<Enfant> enfants = new List<Enfant>();
            int nb = 0;

            foreach (ListViewItem i in listView1.Items)
            {
                Enfant ef = (Enfant)(i.Tag);

                ef.prenom = i.Text;

                enfants.Add(ef);
                if (! ef.BuiltIn) ++nb;
            }

            Properties.Settings.Default.Photos = new Enfant[nb];

            nb = 0;
            foreach (var ef in enfants)
            {
                if (!ef.BuiltIn)
                {
                    Properties.Settings.Default.Photos[nb] = ef;
                    ++nb;
                }
            }

            Properties.Settings.Default.Save();
            Enfants.enfants = enfants;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void toolStripButtonSuppression_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem i in listView1.SelectedItems)
            {
                Enfant ef = (Enfant)(i.Tag);

                if (!ef.BuiltIn)
                    listView1.Items.Remove(i);
            }            
        }
        
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count  == 0) return;
            Properties.Settings.Default.Prénom = listView1.SelectedItems[0].Text;

            toolStripButtonOk_Click(null, null);
        }

        private void toolStripButtonDownload_Click(object sender, EventArgs e)
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                InputBoxResult ibr = InputBox.Show("Entrez le nom du groupe de photos:", "Vérification");

                if (ibr.ReturnCode != System.Windows.Forms.DialogResult.OK)
                    return;

                // ne faisons pas trop compliqué...
                if (ibr.Text.ToLower() != "barbaggio")
                    return;
                
                //ApplicationDeployment.CurrentDeployment.DownloadFileGroup("Famille");                
                FormDownload.Download("Famille", false);

                if (Properties.Settings.Default.PhotosSupp == null)
                {
                    Properties.Settings.Default.PhotosSupp = new System.Collections.Specialized.StringCollection();
                }
                Properties.Settings.Default.PhotosSupp.Add("Famille");
                Properties.Settings.Default.Save();

                Enfants.Recharge();
                FormEnfants_Load(null, null);       // recharge le listView
            }
        }

        private void FormEnfants_KeyUp(object sender, KeyEventArgs e)
        {
            /*if (e.Control && e.KeyCode == Keys.F7)
            {
                toolStripSeparator1.Visible = true;
                toolStripButtonDownload.Visible = true;

                toolStripButtonDownload.Enabled = ApplicationDeployment.IsNetworkDeployed;
            }*/
        }
    }
}
