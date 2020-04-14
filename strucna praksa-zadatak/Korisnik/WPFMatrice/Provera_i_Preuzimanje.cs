using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WPFMatrice
{
    class Provera_i_Preuzimanje
    {

        public static MessageBoxResult proveraUnosa(StackPanel stackPanel,int brElem) {

            string[] el = null;
            MessageBoxResult rez = new MessageBoxResult();
            rez = MessageBoxResult.None;

            foreach (TextBox tbvrsta in stackPanel.Children)
            {
                el = tbvrsta.Text.Split(' ');
                if (tbvrsta.Text.Trim().Length == 0)
                {
                    rez=MessageBox.Show("Popunite sva polja!");
                    break;

                }
                else if ((el.Count() != brElem))
                {

                   rez=MessageBox.Show("Unesite " + brElem + " elemenata!");
                   break;

                }
            }
        
            return rez;
        
        }


        public static int[][] preuzmiMatricu(int[][] matrica,StackPanel stackPanel) {

            string[] vrste = new string[matrica.Length];
            string[] elementi = new string[matrica[0].Length];

            int k = 0;
            foreach (var child in stackPanel.Children)
            {

                TextBox tb = (TextBox)child;
                vrste[k] = tb.Text;
                k++;
            }

            for (int i = 0; i < matrica.Length; i++)
                for (int j = 0; j < matrica[i].Length; j++)
                {
                    elementi = vrste[i].Split(' ');
                    int element = Int32.Parse(elementi[j]);
                    matrica[i][j] = element;

                }
               
            return matrica;
        }
    }
}
