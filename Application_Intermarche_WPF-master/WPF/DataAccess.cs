using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF
{
    public class DataAccess
    {
        private static DataAccess instance;

        private static string strConnexion =
            "Server=srv-peda-new;" +
            "port=5433;" +
            "Database=SAE201_Intermarche;" +
            "Search Path=sae;";


        
        public static DataAccess Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataAccess();
                }
                return instance;
            }
        }
        

        public NpgsqlConnection? Connexion
        {
            get;
            set;
        }

        public bool ConnexionBD()
        {
            

            try
            {
                Connexion = new NpgsqlConnection();
                strConnexion += "uid="+ SeConnecter.IdentifiantSaisie + ";" + "password=" + SeConnecter.MotDePasseSaisie + ";";
                Console.WriteLine(strConnexion);
                Connexion.ConnectionString = strConnexion;
                Connexion.Open();
                return true;
            }
            catch (Exception e)
            {
                MessageBoxResult res = MessageBox.Show("Mot de passe ou Identifiant incorrect", "Erreur de Connexion",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }
        public void DeconnexionBD()
        {
            try
            {
                Connexion.Close();
            }
            catch (Exception e)
            { Console.WriteLine("pb à la déconnexion : " + e); }
        }

        public DataTable GetData(string selectSQL)
        {
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(selectSQL, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception e)
            {
                Console.WriteLine("pb avec : " + selectSQL + e.ToString());
                return null;
            }
        }
        public int SetData(string setSQL)
        {
            try
            {
                NpgsqlCommand sqlCommand = new NpgsqlCommand(setSQL, Connexion);
                int nbLines = sqlCommand.ExecuteNonQuery();
                return nbLines;
            }
            catch (Exception e)
            {
                Console.WriteLine("pb avec : " + setSQL + e.ToString());
                return 0;
            }
        }
    }
}
