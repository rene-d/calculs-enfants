// CalculsCE1 : programme d'entrainement au calcul - niveau CE1
// Copyright © 2011 René DEVICHI

using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace CalculsCE1
{
    public partial class FormHistorique : Form
    {
        public FormHistorique()
        {
            InitializeComponent();
        }

        private void FormHistorique_Load(object sender, EventArgs e)
        {
            foreach (var s in Properties.Settings.Default.Historique)
                listBox1.Items.Add(s);

            listBox1.TopIndex = listBox1.Items.Count - 1;
        }


        public void send()
        {            
            Uri uriString = new Uri("http://serveur.home/enfants/scores.php");

            WebClient request = new WebClient();

            NameValueCollection data = new NameValueCollection();

            data.Add("source", "CalculsCE1");
            data.Add("user", Environment.UserName);
            data.Add("machine", Environment.MachineName);
            data.Add("data", "test");

            StringCollection sc = Properties.Settings.Default.Historique;

            request.UploadProgressChanged += UploadProgress;

            byte[] responseArray = request.UploadValues(uriString, "POST", data);

            string s = Encoding.ASCII.GetString(responseArray);
            MessageBox.Show(s);
        }

        private void UploadProgress(object sender, UploadProgressChangedEventArgs e)
        {
        }
    }
}
