using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    public class Vehicule
    {
        private string immatriculation;
        private string typeBoite;
        private int numMagasin;
        private string nomCategorie;
        private string nomVehicule;
        private string descriptionVehicule;
        private int nombrePlaces;
        private decimal prixLocation;
        private bool climatisation;
        private string lienPhotoUrl;



        public string Immatriculation
        {
            get
            {
                return immatriculation;
            }

            set
            {
                immatriculation = value;
            }
        }

        public string TypeBoite
        {
            get
            {
                return typeBoite;
            }

            set
            {
                typeBoite = value;
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
                if (value <= 0) { throw new ArgumentOutOfRangeException("Attention, le numéro de magasin doit etre supérieur à 0"); }
                numMagasin = value;
            }
        }

        public string NomCategorie
        {
            get
            {
                return nomCategorie;
            }

            set
            {
                nomCategorie = value;
            }
        }

        public string NomVehicule
        {
            get
            {
                return nomVehicule;
            }

            set
            {
                nomVehicule = value;
            }
        }

        public string DescriptionVehicule
        {
            get
            {
                return descriptionVehicule;
            }

            set
            {
                descriptionVehicule = value;
            }
        }

        public int NombrePlaces
        {
            get
            {
                return nombrePlaces;
            }

            set
            {
                nombrePlaces = value;
            }
        }

        public decimal PrixLocation
        {
            get
            {
                return prixLocation;
            }

            set
            {
                prixLocation = value;
            }
        }

        public bool Climatisation
        {
            get
            {
                return climatisation;
            }

            set
            {
                climatisation = value;
            }
        }

        public string LienPhotoUrl
        {
            get
            {
                return this.lienPhotoUrl;
            }

            set
            {
                this.lienPhotoUrl = value;
            }
        }

        public Vehicule(string immatriculation, string typeBoite, int numMagasin, string nomCategorie, string nomVehicule, string descriptionVehicule, int nombrePlaces, decimal prixLocation, bool climatisation, string lienPhotoUrl)
        {
            Immatriculation = immatriculation;
            TypeBoite = typeBoite;
            NumMagasin = numMagasin;
            NomCategorie = nomCategorie;
            NomVehicule = nomVehicule;
            DescriptionVehicule = descriptionVehicule;
            NombrePlaces = nombrePlaces;
            PrixLocation = prixLocation;
            Climatisation = climatisation;
            LienPhotoUrl = lienPhotoUrl;
        }

        public static ObservableCollection<Vehicule> Read()
        {
            ObservableCollection<Vehicule> lesVehicule = new ObservableCollection<Vehicule>();
            String sql = "SELECT * FROM Vehicule;";
            DataTable dt = DataAccess.Instance.GetData(sql);
            if (dt != null)
            {
                foreach (DataRow res in dt.Rows)
                {
                    Console.WriteLine("ligne : " + res);
                    Vehicule nouveauVehicule = new Vehicule(
                        res["immatriculation"].ToString(),
                        res["type_boite"].ToString(),
                        (int)res["num_magasin"],
                        res["nom_categorie"].ToString(),
                        res["nom_vehicule"].ToString(),
                        res["description_vehicule"].ToString(),
                        (int)res["nombre_places"],
                        (decimal)(res["prix_location"]),
                        (bool)res["climatisation"],
                        res["lien_phoo_url"].ToString()
                        );
                    lesVehicule.Add(nouveauVehicule);
                }
            }
            return lesVehicule;
        }

    }
}
