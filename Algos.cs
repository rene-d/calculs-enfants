// CalculsCE1 : programme d'entrainement au calcul - niveau CE1
// Copyright © 2011 René DEVICHI

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculsCE1
{
    /// <summary>
    /// implémentation d'un algorithme de calcul
    /// </summary>
    abstract public class algo
    {
        // les labels
        public string nom { get; protected set; }
        public string titre { get { return string.Format("J'apprends les {0}", nom.ToUpperInvariant()); } }
        public string question { get; protected set; }
        public string oper { get; protected set; }
        public string oper2 { get; protected set; }

        public int duree { get; protected set; }

        /// <summary>
        /// gestion des niveaux de difficultés
        /// voir aussi <seealso cref="niveau"/>
        /// </summary>
        public string[] difficultes { get; protected set; }

        private int niveau_ = 0;
        /// <summary>
        /// niveau de difficulté: index du tableau <see cref="difficultes"/>
        /// </summary>
        public int niveau
        {
            get { return niveau_; }
            set
            {
                if (value >= 0 && value < niveaux)
                {
                    niveau_ = value;
                    if (OnChangeNiveau != null)
                    {
                        OnChangeNiveau(this, EventArgs.Empty);
                    }
                }
            }
        }
        
        protected EventHandler OnChangeNiveau;

        /// <summary>
        /// retourne le nombre de niveaux de difficulté
        /// </summary>
        public int niveaux
        {
            get { return (difficultes == null) ? 0 : difficultes.Length; }
        }

        // les valeurs de l'algo
        /// <summary>
        /// première valeur de la formule
        /// </summary>
        public int x { get; protected set; }
        /// <summary>
        /// deuxième valeur de la formule, uniquement si <see cref="unaire"/> est False
        /// </summary>        
        public int y { get; protected set; }
        /// <summary>
        /// indique une opération unaire (avec une seule valeur)
        /// </summary>
        public bool unaire { get; protected set; }

        // choix des valeurs et test du résultat
        /// <summary>
        /// doit implémenter l'algorithme de calcul: propose les valeurs <see cref="x"/> et <see cref="y"/>
        /// </summary>
        protected abstract void suivant();
        /// <summary>
        /// vérifie la formule en fonction des valeurs <see cref="x"/> et <see cref="y"/> courantes
        /// </summary>
        /// <param name="z">valeur saisie par l'enfant</param>
        protected abstract bool valide(int z);

        /// <summary>
        /// cherche une opération à proposer à l'enfant, de manière à ne pas proposer les mêmes valeurs
        /// que précédemment
        /// voir aussi la méthode abstraite <seealso cref="suivant()"/>
        /// </summary>
        public void encore()
        {
            int ox = x, oy = y;
            int n = 0;

            do
            {
                suivant();
                ++n;            // contrôle la boucle infinie, sait-on jamais...
            } while (x == ox && y == oy && n <= 10);
        }

        /// <summary>
        /// vérifie le calcul de l'enfant
        /// voir aussi la méthode abstraite <seealso cref="valide"/>
        /// </summary>
        /// <param name="z">valeur entrée par l'enfant</param>
        /// <param name="message">message d'erreur ou formule complète</param>
        /// <returns>True si le calcul est bon, False sinon</returns>
        public bool vérifie(int z, out string message)
        {
            bool ok = valide(z);

            if (ok) 
                message = equation(z);
            else
                message = equation("ERREUR !");
                
            return ok;
        }

        protected virtual string equation(object resultat)
        {
            return string.Format("{0} {1} {2} {3} {4}", x, oper, y, oper2, resultat);
        }

        // le générateur d'aléa
        protected Random rand = new Random();

        protected algo()
        {
            unaire = false;
            oper2 = "=";
            duree = 6;          // 6 secondes par défaut pour les calculs            
        }
    }

    /// <summary>
    /// implémente l'algorithme addition
    /// deux niveaux de difficultés (0..50 + 0..50) et (0..5) + (0..5)
    /// </summary>
    class addition : algo
    {
        public addition()
        {
            nom = "Additions";
            question = "Que vaut la somme suivante :";
            oper = "+";

            difficultes = new string[] { "Facile", "Normal", "Difficile" };

            this.OnChangeNiveau +=
               (object sender, EventArgs e) =>
               {
                   duree = 6 + niveau * 2;                   
               };

            niveau = 1;
        }

        protected override void suivant()
        {
            switch (niveau)
            {
                case 0:
                    // facile
                    x = rand.Next(0, 5);
                    y = rand.Next(0, 5);
                    break;

                case 1:
                    // normal
                    x = rand.Next(10, 30);
                    y = rand.Next(0, 30);
                    break;

                case 2:
                    // difficile
                    x = rand.Next(10, 100);
                    y = rand.Next(0, 100);
                    break;
            }
        }

        protected override bool valide(int z)
        {
            return z == x + y;
        }
    }

    /// <summary>
    /// implémente l'algorithme soustraction
    /// </summary>
    class soustraction : algo
    {        
        public soustraction()
        {
            nom = "Soustractions";
            question = "Que vaut la différence suivante :";
            oper = "-";
        }

        protected override void suivant()
        {
            if (niveau == 1)
            {
                // normal
                x = rand.Next(10, 100);
                y = rand.Next(0, 10);
            }
            else
            {
                // facile
                x = rand.Next(5, 10);
                y = rand.Next(0, 5);                
            }
        }

        protected override bool valide(int z)
        {
            return z == x - y;
        }
    }

    /// <summary>
    /// implémente l'algorithme multiplication avec possibilité de choisir sa table (entre 2 et 10)
    /// </summary>
    class multiplication : algo
    {
        public multiplication()
        {
            nom = "Multiplications";
            question = "Que vaut le produit suivant :";
            oper = "×";

            difficultes = new string[] 
            { 
                "Par défaut",       // 0
                "Table de 2",       // 1
                "Table de 3",       // 2
                "Table de 4",
                "Table de 5",
                "Table de 6",
                "Table de 7",
                "Table de 8",
                "Table de 9",
                "Table de 10",      // 9
                "Table de 11",
                "Table de 12",      // 11
            };

            this.OnChangeNiveau +=
               (object sender, EventArgs e) =>
               {
                   if (niveau == 0)
                       duree = 10;
                   else
                       duree = 6;
               };
        }

        protected override void suivant()
        {
            x = rand.Next(1, 10);

            if (niveau == 0)
            {
                // difficulté "Par défaut"
                y = rand.Next(1, 10);
            }
            else 
            {
                y = niveau + 1;
            }
        }

        protected override bool valide(int z)
        {
            return z == x * y;
        }
    }

    /// <summary>
    /// implémente l'algorithme cas particulier de la multiplication: × 2
    /// </summary>
    class doubles : algo
    {
        public doubles()
        {
            nom = "Doubles";
            question = "Quel est le double de :";
            oper = "×";
            unaire = true;
            y = 2;
        }

        protected override void suivant()
        {
            x = rand.Next(1, 20);
        }

        protected override bool valide(int z)
        {
            return z == x * 2;
        }
    }

    /// <summary>
    /// implémente l'algorithme cas particulier de la division: ÷ 2
    /// </summary>
    class moitiés : algo
    {
        public moitiés()
        {
            nom = "Moitiés";
            question = "Quelle est la moitié de :";
            oper = "÷";
            unaire = true;
            y = 2;
        }

        protected override void suivant()
        {
            x = rand.Next(1, 10) * 2;
        }

        protected override bool valide(int z)
        {
            return z == x / 2;
        }
    }

    /// <summary>
    /// implémente l'algorithme carré (entre 1 et 10)
    /// </summary>
    class carrés : algo
    {
        public carrés()
        {
            nom = "Carrés";
            question = "Quel est le carré de :";
            unaire = true;
        }

        protected override void suivant()
        {
            x = rand.Next(1, 10);
        }

        protected override bool valide(int z)
        {
            return z == x * x;
        }

        protected override string equation(object resultat)
        {
            return string.Format("{0} ² = {1}", x, resultat);
        }
    }

    /// <summary>
    /// implémente l'algorithme racine carrée (d'un nombre entre 1 et 10)
    /// </summary>
    class racines : algo
    {
        public racines()
        {
            nom = "Racines Carrées";
            question = "Quelle est la racine carrée de :";
            unaire = true;
        }

        protected override void suivant()
        {
            x = rand.Next(1, 10);
            x = x * x;
        }

        protected override bool valide(int z)
        {
            return z * z == x;
        }

        protected override string equation(object resultat)
        {
            return string.Format("√ {0} = {1}", x, resultat);
        }
    }

    /// <summary>
    /// implémenente une autre forme de soustraction, sur le modèle des exercices du livret de math CE1:
    /// 13 c'est 8 + ...
    /// autre présentation de 13-8
    /// </summary>
    class N_plus_c_est : algo
    {
        public N_plus_c_est()
        {
            nom = string.Format("Soustractions");
            question = "?, c'est :";
            oper = "=";
            oper2 = "+";

            difficultes = new string[] 
            { 
                "10, c'est...",             // niveau = 0
                "11, c'est...",
                "12, c'est...",
                "13, c'est...",
                "14, c'est...",
                "15, c'est...",
                "16, c'est...",
                "17, c'est...",
                "18, c'est...",
                "19, c'est...",
                "20, c'est...",             // niveau = 10
                "100, c'est ...",           // niveau = 11
            };

            this.OnChangeNiveau +=
                (object sender, EventArgs e) =>
                {
                    question = string.Format("{0}, c'est...", 10 + niveau);
                };
        }

        protected override void suivant()
        {
            if (niveau <= 10)
            {
                x = 10 + niveau;
                y = rand.Next(1, x - 1);
            }
            else
            {
                x = 100;
                y = rand.Next(1, 10) * 10;
            }
        }

        protected override bool valide(int z)
        {
            return x == y + z;
        }
    }


    /// <summary>
    /// implémenente une forme de division, sur le modèle des exercices du livret de math CE1:
    /// 35 c'est 7 x ...
    /// </summary>
    class N_fois_c_est : algo
    {
        public N_fois_c_est()
        {
            nom = string.Format("Divisions");
            question = "?, c'est :";
            oper = "=";
            oper2 = "×";

            difficultes = new string[9];

            // niveau 0 => table de 2
            // niveau 8 => table de 10

            for (int i = 2; i <= 10; ++i)
                difficultes[i - 2] = string.Format("X, c'est {0} × ...", i);

            this.OnChangeNiveau +=
                (object sender, EventArgs e) =>
                {
                    question = string.Format("Division par {0} :", 2 + niveau);
                    duree = (niveau + 2) <= 5 ? 8 : 10;
                };
        }

        protected override void suivant()
        {
            y = 2 + niveau;
            x = y * rand.Next(1, 10);
        }

        protected override bool valide(int z)
        {
            return x == y * z;
        }
    }
}
