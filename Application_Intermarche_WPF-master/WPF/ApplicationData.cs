
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{

        public class ApplicationData
        {
       
            private ObservableCollection<Client> lesClients;
            private ObservableCollection<ASSURANCE> lesAssurances;
            private ObservableCollection<Caracteristque> lesCaracteristiques;
            private ObservableCollection<CategorieVehicule> lesCategoriesVehicules;
            private ObservableCollection<detailReservation> lesdetailReservation;
            private ObservableCollection<Employe> lesEmploye;
            private ObservableCollection<Magasin> lesMagasin;
            private ObservableCollection<Reservation> lesReservation;
            private ObservableCollection<Vehicule> lesVehicules;

        public ObservableCollection<Client> LesClients
        {
            get
            {
                return this.lesClients;
            }

            set
            {
                this.lesClients = value;
            }
        }


        public ObservableCollection<ASSURANCE> LesAssurances
        {
            get
            {
                return lesAssurances;
            }

            set
            {
                lesAssurances = value;
            }
        }

        public ObservableCollection<Caracteristque> LesCaracteristiques
        {
            get
            {
                return lesCaracteristiques;
            }

            set
            {
                lesCaracteristiques = value;
            }
        }

        public ObservableCollection<CategorieVehicule> LesCategoriesVehicules
        {
            get
            {
                return lesCategoriesVehicules;
            }

            set
            {
                lesCategoriesVehicules = value;
            }
        }

        public ObservableCollection<detailReservation> LesdetailReservation
        {
            get
            {
                return lesdetailReservation;
            }

            set
            {
                lesdetailReservation = value;
            }
        }

        public ObservableCollection<Employe> LesEmploye
        {
            get
            {
                return lesEmploye;
            }

            set
            {
                lesEmploye = value;
            }
        }

        public ObservableCollection<Magasin> LesMagasin
        {
            get
            {
                return lesMagasin;
            }

            set
            {
                lesMagasin = value;
            }
        }

        public ObservableCollection<Reservation> LesReservation
        {
            get
            {
                return lesReservation;
            }

            set
            {
                lesReservation = value;
            }
        }

        public ObservableCollection<Vehicule> LesVehicules
        {
            get
            {
                return this.lesVehicules;
            }

            set
            {
                this.lesVehicules = value;
            }
        }

        public ApplicationData()
        {
            this.LesClients = Client.Read();
            
            //this.LesAssurances = ASSURANCE.Read()
        }
    }
    
}
