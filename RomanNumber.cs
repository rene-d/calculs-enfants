// CalculsCE1 : programme d'entrainement au calcul - niveau CE1
// Copyright © 2011 René DEVICHI

using System;
using System.Drawing;
using System.Windows.Forms;

// partiellement inspiré de http://fr.wikipedia.org/wiki/Chiffres_romains
// et de http://www.moxlotus.alternatifs.eu/programmation-convertisseur.html

namespace CalculsCE1
{
    public class IllegalRomanNumeralException : ArgumentException
    {
        private String illegalRomanNumural;
        public String proposition { get; private set; }


        public IllegalRomanNumeralException(String illegalRomanNumural)
        {
            this.illegalRomanNumural = illegalRomanNumural;
        }

        public IllegalRomanNumeralException(String illegalRomanNumural, String proposition)
        {
            this.illegalRomanNumural = illegalRomanNumural;
            this.proposition = proposition;
        }

        public String getIllegalRomanNumber()
        {
            return this.illegalRomanNumural;
        }
    }


    public class RomanNumber
    {
        // Ensemble des <i>nombres romains élémentaires</i>.
        private static String[] BASIC_ROMAN_NUMBERS = { "M", "CM", "D", "CD",
			"C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        // Ensemble des correspondants numériques des <i>nombres romains élémentaires</i>.
        private static int[] BASIC_VALUES = { 1000, 900, 500, 400, 100, 90,
			50, 40, 10, 9, 5, 4, 1 };

        /// <summary>
        /// Valeur numérique du nombre romain
        /// </summary>
        public int Value { get; private set; }

        /// <summary>
        /// Valeur romaine du nombre romain
        /// </summary>
        public String RomanValue
        {
            get
            {
                romanString = "";
                int remainder = Value;
                for (int i = 0; i < BASIC_VALUES.Length; ++i)
                {
                    while (remainder >= BASIC_VALUES[i])
                    {
                        romanString += BASIC_ROMAN_NUMBERS[i];
                        remainder -= BASIC_VALUES[i];
                    }
                }
                return romanString;
            }
        }
        private string romanString; // backing field for roman property

        public override string ToString()
        {
            return RomanValue;
        }

        public static explicit operator int(RomanNumber r)
        {
            return r.Value;
        }


        /// <summary>
        /// Construit un nombre romain à partir d'un nombre
        /// </summary>
        /// <param name="value">Valeur numérique du nombre romain à construire</param>
        public RomanNumber(int value)
        {
            if (1 <= value && value <= 3999)
            {
                this.Value = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException(value.ToString(), "The value must be between 1 and 3999.");
            }
        }

        /// <summary>
        /// Construire un nombre romain selon un nombre romain
        /// </summary>
        /// <param name="s">Valeur romaine du nombre romain à construire</param>
        public RomanNumber(String s)
        {
            String r = s.ToUpper();

            // conversion romain -> numérique
            int index = 0;
            this.Value = 0;
            for (int i = 0; i < BASIC_ROMAN_NUMBERS.Length; i++)
            {
                while (string.Compare(r, index, BASIC_ROMAN_NUMBERS[i], 0, BASIC_ROMAN_NUMBERS[i].Length, true) == 0)
                {
                    this.Value += BASIC_VALUES[i];
                    index += BASIC_ROMAN_NUMBERS[i].Length;
                }
            }

            // Verify the input string is a valid roman number.
            RomanNumber verify;
            try
            {
                verify = new RomanNumber(this.Value);
            }
            catch (ArgumentOutOfRangeException /*e*/)
            {
                throw new IllegalRomanNumeralException(s);
            }

            if (verify.RomanValue == r)
            {
                this.romanString = r;
            }
            else
            {
                throw new IllegalRomanNumeralException(s, verify.RomanValue);
            }
        }
    }
}