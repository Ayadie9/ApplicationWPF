﻿using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour FicheClient.xaml
    /// </summary>
    public partial class FicheClient : Window
    {
        public FicheClient(bool CreerCLient)
        {
            InitializeComponent();
            if (CreerCLient ) {ButtonValiderFicheClient.Content = "Créer Client";}
            else { ButtonValiderFicheClient.Content = "Retour"; }
        }
    }
}
