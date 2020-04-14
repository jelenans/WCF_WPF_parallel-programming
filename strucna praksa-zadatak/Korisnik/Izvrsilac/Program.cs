using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;


namespace Izvrsilac
{
    class Program
    {
        static void Main(string[] args)
        {

            string port = (string)args.GetValue(0);

            Uri baseAddress = new Uri("net.tcp://localhost:800" + port + "/Izvrsilac");

            Console.WriteLine("uri:" + baseAddress.ToString() + ",port:" + port);

            ServiceHost selfHost = new ServiceHost(typeof(Sabiranje), baseAddress);

            try
            {


                selfHost.AddServiceEndpoint(
      typeof(ISabiranje),
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
