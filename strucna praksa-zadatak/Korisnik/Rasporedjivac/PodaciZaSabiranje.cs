using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rasporedjivac
{
    public class PodaciZaSabiranje
    {
        public int[] deo1=null;
        public int[] deo2=null;
        public SabiranjeClient klijentp=null;
        public int index=0;


        public PodaciZaSabiranje(int[] d1, int[] d2, SabiranjeClient kp,int ind)
        {
            deo1 = d1;
            deo2 = d2;
            klijentp = kp;
            index = ind;
        }
    }
}
