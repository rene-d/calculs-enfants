// CalculsCE1 : programme d'entrainement au calcul - niveau CE1
// Copyright © 2011 René DEVICHI

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace CalculsCE1
{
    /// <summary>
    /// classe pour gérer la liste des enfants, avec leurs images
    /// </summary>
    class Enfants
    {
        static public List<Enfant> enfants;

        static Enfants()
        {
            Recharge();
        }
            
        /// <summary>
        /// charge ou recharge la liste des photos
        /// </summary>
        public static void Recharge()
        {
            enfants = new List<Enfant>();

            // 1. les photos ajoutées manuellement
            if (Properties.Settings.Default.Photos != null)
                enfants.AddRange(Properties.Settings.Default.Photos);

            // 2. les DLL de ressources de photos
            string dll;
            dll = Path.GetDirectoryName(Application.ExecutablePath);           
            dll = Path.Combine(dll, "CalculsCE1.Photos.dll");
            if (File.Exists(dll))
            {
                try
                {
                    Assembly asm = Assembly.LoadFile(dll);
                    Type type = asm.GetType("CalculsCE1.Photos");

                    ListDictionary builtin = (ListDictionary)type.GetMethod("Get").Invoke(null, null);
                    foreach (DictionaryEntry x in builtin)
                    {
                        enfants.Add(new Enfant(x.Key as string, x.Value as Image));
                    }
                }
                catch { }
            }
            
            // 3. les photos prédéfinies
            enfants.Add(new Enfant("Wall-E", Properties.Resources.wall_e));
            enfants.Add(new Enfant("Eve", Properties.Resources.eve));
        }

        /// <summary>
        /// initialise tous les enfants
        /// </summary>
        /// <param name="comboBox1">contrôle ComboBox pour afficher la liste</param>
        public static void Init(ComboBox comboBox1)
        {
            try
            {
                comboBox1.Items.Clear();

                //comboBox1.BeginUpdate();
                comboBox1.SelectedIndex = -1;

                foreach (var e in enfants)
                {
                    int i = comboBox1.Items.Add(e);

                    if (e.prenom == Properties.Settings.Default.Prénom && comboBox1.SelectedIndex == -1)
                    {
                        comboBox1.SelectedIndex = i;
                    }
                }
            }
            catch { }
            finally
            {
                //comboBox1.EndUpdate();
            }
        }

        /// <summary>
        /// sélectionne un enfant
        /// </summary>
        /// <param name="comboBox1">contrôle ComboBox de la liste des enfants</param>
        /// <param name="pictureBox1">contrôle pour afficher la photo</param>
        public static void Selecteur(ComboBox comboBox1, PictureBox pictureBox1)
        {
            try
            {
                if (comboBox1.SelectedItem == null)
                {
                    pictureBox1.Image = null;
                    return;
                }

                Enfant e = (Enfant)comboBox1.SelectedItem;

                if ((pictureBox1.Tag as string) == e.key)
                    return;

                pictureBox1.Tag = e.key;
                Properties.Settings.Default.Prénom = e.prenom;
                Historique.Add(e.prenom);
                pictureBox1.Image = e.image;
            }
            catch { }
        }

        /// <summary>
        /// ajout manuel d'un enfant (un seul possible)
        /// </summary>
        /// <param name="comboBox1"></param>
        public static void Ajout(ComboBox comboBox1)
        {
            FormEnfants frm = new FormEnfants();

            if (frm.ShowDialog() != DialogResult.OK)
                return;

            if (comboBox1 != null)
                Init(comboBox1);
        }
    }
}
