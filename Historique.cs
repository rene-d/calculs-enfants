// CalculsCE1 : programme d'entrainement au calcul - niveau CE1
// Copyright © 2011 René DEVICHI

using System.Collections.Specialized;
using System.Windows.Forms;

namespace CalculsCE1
{
    sealed class Historique
    {
        static ListBox listBox1 = null;

        /// <summary>
        /// positionne un contrôle ListBox pour afficher les ajouts
        /// </summary>
        /// <param name="lb"></param>
        public static void SetListBox(ListBox lb)
        {
            listBox1 = lb;
        }

        /// <summary>
        /// ajoute un message dans l'historique
        /// </summary>
        /// <param name="s">message à ajouter</param>
        /// <remarks>uniquement 200 messages au maximum</remarks>
        public static void Add(string s)
        {
            if (listBox1 != null)
            {
                try
                {
                    int i = listBox1.Items.Add(s);
                    listBox1.TopIndex = i;
                }
                catch { }
            }

            if (Properties.Settings.Default.Historique == null)
                Properties.Settings.Default.Historique = new StringCollection();

            while (Properties.Settings.Default.Historique.Count > 200)
                Properties.Settings.Default.Historique.RemoveAt(0);

            Properties.Settings.Default.Historique.Add(s);
        }

    }
}
