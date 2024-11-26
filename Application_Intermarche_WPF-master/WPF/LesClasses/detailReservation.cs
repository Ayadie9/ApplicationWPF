using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WPF
{
    public class detailReservation
    {

        private string immatriculation;
        private string valeurCaracteristique;
        private Caracteristque caracteristqueVehicule;

        public string Immatriculation
        {
            get { return immatriculation; }
            set {
                
                if (!Regex.IsMatch(value, "^[A-Z]{2}-[0-9]{3}-[A-Z]{2}$"))
                    throw new ArgumentException("ATTENTION, il faut respecter les caractères de la plaque d'immatriculation !");

                this.Immatriculation = value;
            }
        }
   
        public string ValeurCaracteristique
        {
            get { return valeurCaracteristique; }
            set { if (string.IsNullOrEmpty(value)) { throw new ArgumentException("ATTENTION, la valeur caractéristique ne doit pas ere ni nulle ni vide !"); } valeurCaracteristique = value; }
        }

        public Caracteristque CaracteristqueVehicule { get => caracteristqueVehicule; set => caracteristqueVehicule = value; }

        public detailReservation(string immatriculation, Caracteristque caracteristque, string valeurCaracteristique)
        {
            Immatriculation = immatriculation;
            this.CaracteristqueVehicule = CaracteristqueVehicule;
            ValeurCaracteristique = valeurCaracteristique;
        }
    }
}
