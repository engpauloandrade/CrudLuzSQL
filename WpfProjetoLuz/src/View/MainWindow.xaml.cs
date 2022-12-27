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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using WpfProjetoLuz.src.Database;

namespace WpfProjetoLuz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowVM();
        }


        private void Button_btnSair(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Deseja encerrar a aplicação?", "Encerrar", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void Button_btnDataHora(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Data e Hora Atual:\n " + DateTime.Now.ToShortDateString() + " - " +
            DateTime.Now.ToLongTimeString());

        }

    }
}
