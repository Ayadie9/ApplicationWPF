using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WPF;

namespace WPF
{
    public class Client
    {
        private static int autoIncrementNumClient;

        private int numClient;
        private string nomClient;
        private string prenomClient;
        private string adresseRueClient;
        private string adresseCpClient;
        private string adresseVilleClient;
        private string telephone;
        private string mail;
        private bool estParticuler;


        public int NumClient
        {
            get
            {
                return numClient;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(" le numéro de cleint doit etre supérieur à 0");
                }
                numClient = value;
            }
        }

        public string NomClient
        {
            get
            {
                return nomClient;
            }

            set
            {
                if(string.IsNullOrEmpty(nomClient)) { throw new ArgumentException("ATTENTION, la valeur ne doit etre ni nulle ni vide !"); }
                nomClient = value;
            }
        }

        public string AdresseRueClient
        {
            get
            {
                return adresseRueClient;
            }

            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("L'adresse de la rue du client ne doit pas etre ni nulle ni vide");
                }
                adresseRueClient = value;
            }
        }

        public string AdresseCpClient
        {
            get
            {
                return adresseCpClient;
            }

            set
            {
                if(value.Length !=5)
                    throw new ArgumentException("Attention, le code postal doit etre constitué de 5 chiffres");
                adresseCpClient = value;
            }
        }

        public string AdresseVilleClient
        {
            get
            {
                return adresseVilleClient;
            }

            set
            {
                if (string.IsNullOrEmpty(value)) { throw new ArgumentNullException("ATTENTION, la valeur ne doit pas etre ni nulle ni vide !"); }
                adresseVilleClient = value;
            }
        }

        public string Mail
        {
            get
            {
                return this.mail;
            }

            set
            {
                try
                {
                    MailAddress email = new MailAddress(value);
                    this.Mail = value;
                }
                catch (Exception ex) { throw new ArgumentException("L'email est invalide");}
               
            }
        }

        public string Telephone
        {
            get
            {
                return this.telephone;
            }

            set
            {
                if (!Regex.IsMatch(value, "^[0-9]{5}$"))
                    throw new ArgumentException("Le téléphone portable est incorrect, il faut saisir 10 chiffres");

                this.telephone = value;
            }
        }


        public bool EstParticuler
        {
            get
            {
                return this.estParticuler;
            }

            set
            {
                this.estParticuler = value;
            }
        }

        public string PrenomClient
        {
            get
            {
                return this.prenomClient;
            }

            set
            {
                this.prenomClient = value;
            }
        }

        public static int AutoIncrementNumClient
        {
            get
            {
                return autoIncrementNumClient;
            }

            set
            {
                autoIncrementNumClient = value;
            }
        }

        public Client(string nomClient,string prenomClient, string adresseRueClient, string adresseCpClient, string adresseVilleClient,string telephone, string mail,bool estParticulier)
        {
            this.NumClient = AutoIncrementNumClient;
            this.NomClient = nomClient;
            this.PrenomClient = prenomClient;
            this.AdresseRueClient = adresseRueClient;
            this.AdresseCpClient = adresseCpClient;
            this.AdresseVilleClient = adresseVilleClient;
            this.Telephone = telephone;
            this.Mail = mail;
            this.EstParticuler = estParticulier;
        }


        public int Create()
        {
            String sql = $"insert into client (num_client,nom_client,prenom_client,adresse_rue_client,adresse_cp_client,adresse_ville_client,telephone_client,mail_client,estparticulier) values (" +
            $"'{this.NumClient}','{this.NomClient}','{this.PrenomClient}'," +
            $"'{this.AdresseRueClient}','{this.AdresseCpClient}','{this.AdresseVilleClient}'," +
            $"'{this.Telephone}','{this.Mail}',{this.EstParticuler});";


            Console.WriteLine("Client créer avec succès");

            return DataAccess.Instance.SetData(sql);
        }
        public static ObservableCollection<Client> Read()
        {
            ObservableCollection<Client> lesClients = new ObservableCollection<Client>();
            String sql = "SELECT * FROM client;";
            DataTable dt = DataAccess.Instance.GetData(sql);
            if (dt != null)
            {
                foreach (DataRow res in dt.Rows)
                {
                    Console.WriteLine("ligne : " + res);
                    Client nouveau = new Client(
                        res["nom_client"].ToString(),
                        res["prenom_client"].ToString(),
                        res["adresse_rue_client"].ToString(),
                        res["adresse_cp_client"].ToString(),
                        res["adresse_ville_client"].ToString(),
                        res["telephone_client"].ToString(),
                        res["mail_client"].ToString(),
                        (bool)res["estparticulier"]
                        );
                    lesClients.Add(nouveau);
                }
            }
            return lesClients;
        }

        public override string? ToString()
        {
            return "Nom " + this.NomClient + "\nPrenom : " + this.PrenomClient;
        }
    }
}
