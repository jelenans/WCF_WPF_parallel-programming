using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rasporedjivac
{
    class Matrica
    {

        public static int[] konvertuj_u_niz(int[][] matrica) {

            int[] niz=null;

            int x = matrica.Length;
            int y = matrica[0].Length;

            int cn = x*y;

            niz= new int[cn];

            int a = 0;

            for (int i = 0; i < matrica.Length; i++)
                for (int j = 0; j < matrica[i].Length; j++)
                {
                    niz[a] = matrica[i][j];
                    a++;

                }

            return niz;
        }

        public static int[] podeliNiz(int[] niz,int brojProxija,int brojac,int xc)
        {


            int deoDuzina = 0;

            int[] deo1 =null;

            int x;

            if (brojac == brojProxija - 1)
            {
                deoDuzina = niz.Length - xc;
                deo1 = new int[deoDuzina];
                for (x = 0; x < deoDuzina; x++)
                {
                    deo1[x] = niz[xc];
                    xc++;
    
                }
            }
            else
            {
                deoDuzina = niz.Length / brojProxija;
                deo1 = new int[deoDuzina];
                for (x = 0; x < deoDuzina; x++)
                {
                    deo1[x] = niz[xc];
                    xc++;
                }

            }

            return deo1;
        }

        public static int[][] konvertuj_u_matricu(int[] niz,int rows,int cols) {

       
            int[][] matrica = null;

            matrica = new int[rows][];
            for (int k = 0; k < rows; k++)
            {
                matrica[k] = new int[cols];
            }

            int g = 0;


            for (int u = 0; u < rows; u++)
                for (int v = 0; v < cols; v++)
                {
                    matrica[u][v] = niz[g];
                    g++;

                }

            return matrica;
        
        }
    }
}
