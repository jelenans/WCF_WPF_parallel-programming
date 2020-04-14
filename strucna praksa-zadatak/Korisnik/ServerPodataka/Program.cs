using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ServerPodataka
{
     [System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    class Program
    {
        static void Main(string[] args)
        {

            Uri baseAddress = new Uri("net.tcp://localhost:8050/ServerPodataka");

            
            ServiceHost selfHost = new ServiceHost(typeof(ServerPodataka), baseAddress);

            try
            {


                selfHost.AddServiceEndpoint(
      typeof(IServerPodataka),
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
