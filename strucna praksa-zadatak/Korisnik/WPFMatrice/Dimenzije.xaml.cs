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
    /// Interaction logic for Dimenzije.xaml
    /// </summary>
    public partial class Dimenzije : Window
    {
        int opcija = 0;
  
        public Dimenzije(int op)
        {
            InitializeComponent();
            opcija = op;
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {


            if ((tbVrste.Text.Trim().Length == 0 || tbKolone.Text.Trim().Length == 0))
            {
                MessageBox.Show("Popunite sva polja!");
                return;
            
            }
         
           int m = 0;    
           int n = 0;

               m = Int32.Parse(tbVrste.Text);
               n = Int32.Parse(tbKolone.Text);
           

                if (opcija == 2)
                {
                    UnosMatrica unos = new UnosMatrica(m, n);
                    unos.ShowDialog();
                }
                else
                {
                    Random r = new Random();

                    int[][] matrA = new int[m][];
                    int[][] matrB = new int[m][];

                    for (int k = 0; k < m; k++)
                    {
                        matrA[k] = new int[n];
                        matrB[k] = new int[n];
                    }


                    for (int i = 0; i < matrA.Length; i++)
                    {
                        for (int j = 0; j < matrA[i].Length; j++)
                        {
                            matrA[i][j] = r.Next(1, 10);
                            matrB[i][j] = r.Next(1, 10);
                        }

                    }
                    UnosMatrica unos = new UnosMatrica(matrA, matrB);
                    unos.ShowDialog();
                }
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tbVrste_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbVrste.Text.Trim().Length==0)
            {
                MessageBox.Show("Unesite broj vrsta!");
              
            }
    
            
        }

   

        private void tbVrste_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !TextBoxTextAllowed(e.Text);
        }

        private void tbKolone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !TextBoxTextAllowed(e.Text);
        }

        private void tbVrste_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {

                String Text1 = (String)e.DataObject.GetData(typeof(String));
               

                if (!TextBoxTextAllowed(Text1)) e.CancelCommand();

            }

            else e.CancelCommand();
        }


        private void tbKolone_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {

                String Text1 = (String)e.DataObject.GetData(typeof(String));


                if (!TextBoxTextAllowed(Text1)) e.CancelCommand();

            }

            else e.CancelCommand();
        }

        private Boolean TextBoxTextAllowed(String Text2)
        {

            
            return Array.TrueForAll<Char>(Text2.ToCharArray(),

                delegate(Char c) { return Char.IsDigit(c) || Char.IsControl(c); });

        }

        private void tbVrste_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space && tbVrste.IsFocused == true)
            {

                e.Handled = true;

            }
        }

        private void tbKolone_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space && tbKolone.IsFocused == true)
            {

                e.Handled = true;

            }
        }

        private void tbKolone_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbKolone.Text.Trim().Length==0)
            {
                MessageBox.Show("Unesite broj kolona!");
               
            }
          
        }

     
       

     

     
     
    }
}
