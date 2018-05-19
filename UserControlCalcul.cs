// CalculsCE1 : programme d'entrainement au calcul - niveau CE1
// Copyright © 2011 René DEVICHI

using System;
using System.Windows.Forms;

namespace CalculsCE1
{

    public enum ResultatCalcul
    {
        ErreurSaisie,
        Erreur,
        OK,
    }

    public interface IUserControlCalcul
    {
        /// <summary>
        ///  retourne le temps autorisé pour obtenir une étoile
        /// </summary>
        int Duree { get; }
        /// <summary>
        /// propose un nouveau calcul
        /// </summary>
        void Encore();
        /// <summary>
        /// vérifie le calcul
        /// </summary>
        /// <param name="resultat">description du calcul (l'opération par exemple)</param>
        /// <returns>OK ou une erreur</returns>
        ResultatCalcul Vérifie(out string resultat);

        /// <summary>
        /// permet de rediriger le bouton par défaut de la form vers la vérification du calcul
        /// </summary>
        IButtonControl AcceptButton { get; }
    }
}