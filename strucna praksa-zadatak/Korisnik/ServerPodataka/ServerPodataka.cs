using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Xml; 

namespace ServerPodataka
{

     [System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    class ServerPodataka: IServerPodataka
    {
       

        public void sacuvajPodatke(int[][] mat)
        {
            try
            {
                Lista lista = Lista.getInstance();
                lista.dodajMat(mat);
                System.Xml.Serialization.XmlSerializer writer =
                    new System.Xml.Serialization.XmlSerializer(typeof(Lista));


                System.IO.StreamWriter file = new System.IO.StreamWriter(
                    @"c:\temp\matrice.xml");
                writer.Serialize(file, lista);
                file.Close();
            }
            catch (Exception exp)
            {

                MyFaultException theFault = new MyFaultException();
                theFault.Reason = "Greska operacije sacuvajPodatke: " + exp.Message.ToString();
                throw new FaultException<MyFaultException>(theFault, new FaultReason("greska u cuvanju!"));

            }
        
        }

        public List<int[][]> dobaviPodatke() 
        {
            try
            {
                System.Xml.Serialization.XmlSerializer reader =
            new System.Xml.Serialization.XmlSerializer(typeof(Lista));
                System.IO.StreamReader file = new System.IO.StreamReader(
                    @"c:\temp\matrice.xml");
                Lista lista = new Lista();
                lista = (Lista)reader.Deserialize(file);

                List<int[][]> podaci = lista.getPodaci();
                file.Close();
                return podaci;
            }
            catch (Exception exp)
            {

                MyFaultException theFault = new MyFaultException();
                theFault.Reason = "Greska operacije dobaviPodatke: " + exp.Message.ToString();
                throw new FaultException<MyFaultException>(theFault, new FaultReason("greska u load!"));

            }
        
        }

    }
}
