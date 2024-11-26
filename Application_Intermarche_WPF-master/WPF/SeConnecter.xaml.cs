 using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF
{

    /// <summary>
    /// Logique d'interaction pour SeConnecter.xaml
    /// </summary>
    public partial class SeConnecter : Window
    {
        private static string identifiantSaisie;
        private static string motDePasseSaisie;


        public static string IdentifiantSaisie
        {
            get
            {
                return identifiantSaisie;
            }

            set
            {
                identifiantSaisie = value;
            }
        }

        public static string MotDePasseSaisie
        {
            get
            {
                return motDePasseSaisie;
            }

            set
            {
                motDePasseSaisie = value;
            }
        }


        public SeConnecter()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Console.WriteLine("Identifiant saisie : " + IdentifiantSaisie + "\nMot de passe Saisie : " + MotDePasseSaisie);
            if (DataAccess.Instance.ConnexionBD())
            {
                Console.WriteLine("Connexion réussi");
                DialogResult = true;
            }
        }

        private void TextBoxIdentifiant_TextChanged(object sender, TextChangedEventArgs e)
        {
            IdentifiantSaisie = TextBoxIdentifiant.Text;
        }

        private void TextBoxMotDePasse_TextChanged(object sender, TextChangedEventArgs e)
        {
            MotDePasseSaisie = TextBoxMotDePasse.Text;
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show(
                "Vérifier que l'identifiant et le mot de passe saisie correspond " +
                "; Ci cela ne marche toujours pas conctacter votre employeur", "Aide",
                    MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
