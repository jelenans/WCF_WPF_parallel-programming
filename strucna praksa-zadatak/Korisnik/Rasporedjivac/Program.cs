using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Diagnostics;
using System.Threading;
using System.ServiceModel.Description;


namespace Rasporedjivac
{
    class Program
    {
       
        static void Main(string[] args)
        {

            Uri baseAddress = new Uri("net.tcp://localhost:8051/Rasporedjivac");


            ServiceHost selfHost = new ServiceHost(typeof(Komanda), baseAddress);

            try
            {


                selfHost.AddServiceEndpoint(
      typeof(IKomanda),
      new NetTcpBinding(),
      "");

              

                selfHost.Open();
                Console.WriteLine("The service is ready.");


                Console.WriteLine("");
                Console.WriteLine();
           

                Console.ReadLine();





            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);

                selfHost.Abort();
            }
        }
    }
}
