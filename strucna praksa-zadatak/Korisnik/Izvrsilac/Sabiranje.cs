using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using ServerPodataka;

namespace Izvrsilac
{
     [System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    class Sabiranje : ISabiranje
    {

        public int[] SaberiMat(int[] a, int[] b)
        {

            int[] rez;

            try
            {
                rez = new int[a.Length];
                for (int i = 0; i < rez.Length; i++)
                {
                    rez[i] = a[i] + b[i];
                }
              
            }
            catch (Exception e)
            {

                MyFaultException theFault = new MyFaultException();
                theFault.Reason = "Greska operacije saberiMat: " + e.Message.ToString();
                throw new FaultException<MyFaultException>(theFault,new FaultReason("greska sabiranja!"));
           
            }

                return rez;
        }
    }
}
