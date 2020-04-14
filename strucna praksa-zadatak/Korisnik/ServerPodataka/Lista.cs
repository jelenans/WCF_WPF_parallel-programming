using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerPodataka
{
    [Serializable]
   public class Lista
    {
        private static Lista lista;
        public List<int[][]> podaci= new List<int[][]>();
 
        public static Lista getInstance()
        {
            if (lista == null)
            {
                lista= new Lista();
            }
            return lista;
        }


        public void dodajMat(int[][] mat) 
        {
            podaci.Add(mat);
        }

        public List<int[][]> getPodaci() {

            return podaci;
        }


    }
}
