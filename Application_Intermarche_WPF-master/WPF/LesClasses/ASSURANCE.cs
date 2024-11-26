using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    public class ASSURANCE
    {
        private int numAssurance;
        private string descriptionAssurance;
        private int prixAssurance;


        public int NumAssurance
        {
            get
            {
                return numAssurance;
            }

            set
            {
                if (value <= 0) { throw new ArgumentOutOfRangeException("Attention le numéro d'assurance doit etre supérieur à 0"); }
                numAssurance = value;
            }
        }

        public string DescriptionAssurance
        {
            get
            {
                return descriptionAssurance;
            }

            set
            {
                if(string.IsNullOrEmpty(value)) { throw new ArgumentNullException("ATTENTION, la description d'assurance ne doit pas etre ni nulle ni vide !"); }
                descriptionAssurance = value;
            }
        }

        public int PrixAssurance
        {
            get
            {
                return this.prixAssurance;
            }

            set
            {
                this.prixAssurance = value;
            }
        }
        public ASSURANCE(int numAssurance, string descriptionAssurance, int prixAssurance1)
        {
            NumAssurance = numAssurance;
            DescriptionAssurance = descriptionAssurance;
            PrixAssurance = prixAssurance;
        }


    }
    
}
