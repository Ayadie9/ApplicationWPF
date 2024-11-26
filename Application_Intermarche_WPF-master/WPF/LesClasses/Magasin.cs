using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WPF
{
    public class Magasin
    {
        private int numMagasin;
        private string nomMagasin;
        private string adresseRueMagasin;
        private string adresseCpMagasin;
        private string adresseVilleMagasin;
        private string horaireMagasin;


        public int NumMagasin
        {
            get
            {
                return numMagasin;
            }
            
            set
            {
                if (value <= 0) { throw new ArgumentException("Le numéro de magasin doit etre supérieur à 0");}
                numMagasin = value;
            }
        }

        public string NomMagasin
        {
            get
            {
                return nomMagasin;
            }

            set
            {
                if(string.IsNullOrEmpty(nomMagasin)) { throw new ArgumentException("ATTENTION, le nom du magasin ne doit pas etre ni nulle ni vide"); }
                nomMagasin = value;
            }
        }

        public string AdresseRueMagasin
        {
            get
            {
                return adresseRueMagasin;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("L'adresse de la rue du client ne doit pas etre ni nulle ni vide");
                }
                adresseRueMagasin = value;
            }
        }

        public string AdresseCpMagasin
        {
            get
            {
                return adresseCpMagasin;
            }

            set
            {

                Match m = Regex.Match(value, "^[0-9]{5}$");
                if (!m.Success)
                    throw new ArgumentException("Attention, le code postal doit etre constitué de 5 chiffres");

                adresseCpMagasin = value;
            }
        }

        public string AdresseVilleMagasin
        {
            get
            {
                return adresseVilleMagasin;
            }

            set
            {
                if (string.IsNullOrEmpty(value)) { throw new ArgumentNullException("ATTENTION, la valeur ne doit pas etre ni nulle ni vide !"); }
                adresseVilleMagasin = value;
            }
        }

        public string HoraireMagasin
        {
            get
            {
                return this.horaireMagasin;
            }

            set
            {
                this.horaireMagasin = value;
            }
        }


        public Magasin(int numMagasin, string nomMagasin, string adresseRueMagasin, string adresseCpMagasin, string adresseVilleMagasin, string horaireMagasin)
        {
            NumMagasin = numMagasin;
            NomMagasin = nomMagasin;
            AdresseRueMagasin = adresseRueMagasin;
            AdresseCpMagasin = adresseCpMagasin;
            AdresseVilleMagasin = adresseVilleMagasin;
            HoraireMagasin = horaireMagasin;
        }
    }
}
