// CalculsCE1 : programme d'entrainement au calcul - niveau CE1
// Copyright © 2011 René DEVICHI

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CalculsCE1
{
    public struct Enfant
    {
        public string prenom;
        public string fichier;

        /// <summary>
        /// photo de l'enfant, soit en ressources, soit chargée depuis un fichier
        /// </summary>
        internal Image image
        {
            get 
            {
                if (image_ == null && fichier != null)
                {
                    try
                    {
                        image_ = new Bitmap(fichier);
                    }
                    catch
                    {
                        // le fichier n'existe plus ou n'est pas une image valide
                        image_ = null;
                    }
                }
                return image_; 
            }
        }
        private Image image_;   // backing field

        /// <summary>
        /// l'image réduite 96x96 (les proportionnées conservées)
        /// </summary>
        internal Image thumbnail
        {
            get
            {
                if (thumbnail_ == null && image != null)
                {
                    int MaxWidth = 96;
                    int MaxHeight = 96;
                    int OffsetX = 0;
                    int OffsetY = 0;

                    //create a new Bitmap the size of the new image
                    Bitmap bmp = new Bitmap(MaxWidth, MaxHeight);

                    int NewHeight = image.Height * MaxWidth / image.Width;
                    int NewWidth = MaxWidth;

                    if (NewHeight > MaxHeight)
                    {
                        // Resize with height instead
                        NewWidth = image.Width * MaxHeight / image.Height;
                        NewHeight = MaxHeight;

                        OffsetX = (MaxWidth - NewWidth) / 2;
                    }
                    else
                    {
                        OffsetY = (MaxHeight - NewHeight) / 2;
                    }

                    //return img.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);


                    //create a new graphic from the Bitmap
                    Graphics graphic = Graphics.FromImage((Image)bmp);
                    graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    //draw the newly resized image
                    graphic.DrawImage(image, OffsetX, OffsetY, NewWidth, NewHeight);

                    thumbnail_ = bmp as Image;
                }                     
                return thumbnail_;
            }
        }
        private Image thumbnail_;   // backing field

        /// <summary>
        /// identifiant unique interne de l'enfant
        /// </summary>
        public string key;

        /// <summary>
        /// initialise un enfant à partir d'une photo en ressource
        /// </summary>
        /// <param name="image">image en ressource</param>
        /// <param name="prenom">prénom</param>
        public Enfant(string prenom, Image image)
        {
            this.prenom = prenom;
            this.fichier = null;
            this.image_ = image;
            this.thumbnail_ = null;
            this.key = Guid.NewGuid().ToString();
        }
        
        /// <summary>
        /// initialise un enfant à partir d'une photo sur le disque dur
        /// </summary>
        /// <param name="fichier">fichier</param>
        /// <param name="prenom">prénom</param>
        public Enfant(string prenom, string fichier)
        {
            this.prenom = prenom;
            this.fichier = fichier;
            this.image_ = null;
            this.thumbnail_ = null;
            this.key = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// surcharge de <seealso cref="ToString"/> pour afficher dans la ComboBox
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return prenom;
        }

        /// <summary>
        /// indique si l'image associée à l'enfant est en ressource
        /// </summary>
        public bool BuiltIn
        {
            get { return fichier == null && image_ != null; }
        }
         
    }        
}
