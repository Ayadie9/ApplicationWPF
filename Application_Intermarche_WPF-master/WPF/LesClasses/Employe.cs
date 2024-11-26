using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    public class Employe
    {
        private int numEmploye;
        private int numMagasin;
        private string login;
        private string mdp;


        public int NumEmploye
        {
            get
            {
                return numEmploye;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Le numéro d'employé doit etre supérieur à 0");
                }
                numEmploye = value;
            }
        }

        public int NumMagasin
        {
            get
            {
                return numMagasin;
            }

            set
            {
                if(value<=0) { throw new ArgumentException("Le numéro de magasin doit etre supérieur à 0"); }
                numMagasin = value;
            }
        }

        public string Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }

        public string Mdp
        {
            get
            {
                return this.mdp;
            }

            set
            {
                this.mdp = value;
            }
        }

        public Employe(int numEmploye, int numMagasin, string login, string mdp)
        {
            NumEmploye = numEmploye;
            NumMagasin = numMagasin;
            Login = login;
            Mdp = mdp;
        }
    }
}
