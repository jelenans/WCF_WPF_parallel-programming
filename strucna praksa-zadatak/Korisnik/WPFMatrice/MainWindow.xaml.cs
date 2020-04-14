using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFMatrice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServerPodatakaClient podaci;
        KomandaClient komanda;
        public MainWindow()
        {
            InitializeComponent();
            podaci = new ServerPodatakaClient();
            komanda = new KomandaClient();
        }
      
        private void Opcija_Click(object sender, RoutedEventArgs e)
        {
            if (rbRandom.IsChecked==true)
            {
                Dimenzije dim = new Dimenzije(1);
                dim.ShowDialog();
            }

            if (rbUnos.IsChecked == true)
            {

                Dimenzije dim = new Dimenzije(2);
                dim.ShowDialog();
            }
        
          
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
