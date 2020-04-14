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
using System.Windows.Shapes;

namespace WPFMatrice
{
    /// <summary>
    /// Interaction logic for Rez.xaml
    /// </summary>
    public partial class Rez : Window
    {
        public Rez()
        {
            InitializeComponent();
        }


        public Rez(int[][] C)
        {
            InitializeComponent();


            Label labA = new Label();
            labA.Content = "Rezultat sabiranja matrica: ";
            labA.FontFamily = new FontFamily("Euphemia");
            labA.FontWeight = FontWeights.Bold;
            labA.FontSize = 13;
            stackPanelRez.Children.Add(labA);
            stackPanelRez.Children.Add(new Label());



            for (int i = 0; i < C.Length; i++)
            {
                Label lab = new Label();
                lab.FontFamily = new FontFamily("Euphemia");

                for (int j = 0; j < C[i].Length; j++)
                {
                    lab.Content += C[i][j] + " ";


                }
                stackPanelRez.Children.Add(lab);


            }
        }

      

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
    }
}
