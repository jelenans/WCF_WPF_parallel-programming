using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Diagnostics;
using System.Threading;
using System.ServiceModel.Description;
using System.IO;
using ServerPodataka;

namespace Rasporedjivac
{
     [System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults=true)]
    class Komanda : IKomanda
    {

        int[][] C;

        int xc = 0;
        int xclength = 0;
        int rn = 0;

        int[] rez;

        public static bool izvrsi = false;
        public static int N = 0;

        FileInfo file;
        string fullFile;
        public static List<Delovi> listaDelova;

        public static List<SabiranjeClient> proxies;

        public int[][] izvrsiSabiranje(bool ok, int br)
        {

 #region IZVRSIOCI
    
            Uri adrPod = new Uri("net.tcp://localhost:8050/ServerPodataka");
            ServerPodatakaClient podaci = new ServerPodatakaClient(new NetTcpBinding(), new EndpointAddress(adrPod));

            if (ok.Equals(true))
            {

                    int brojIzvrsilaca = br;

                    proxies = new List<SabiranjeClient>();
                    List<Process> procesi = new List<Process>();

                    int portASCII = 48;

                    int kljuc = 0;

                    if (brojIzvrsilaca > 10)
                    {
                        MyFaultException theFault = new MyFaultException();

                        theFault.Reason = "ne moze se pokrenuti vise od 10 izvrsilaca!";

                        throw new FaultException<MyFaultException>(theFault, new FaultReason("greska u broju izvrsilaca!"));

                    }

                    if (brojIzvrsilaca > 0)
                    {
                       
                        while (brojIzvrsilaca != 0)
                        {
                            try
                            {

                            char chPort = Convert.ToChar(portASCII);
                            String port = chPort.ToString();

                            Process p = new Process();

                            
                            file = new FileInfo("Izvrsilac.exe");
                            fullFile = file.FullName;

                            p.StartInfo.FileName = fullFile;
                            p.StartInfo.Arguments = port;
                            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            p.Start();
                            procesi.Add(p);

                         

                            Uri adr = new Uri("net.tcp://localhost:800" + port + "/Izvrsilac");
                            SabiranjeClient klijentProxy = new SabiranjeClient(new NetTcpBinding(), new EndpointAddress(adr));

                            proxies.Add(klijentProxy);
                            kljuc++;
                            brojIzvrsilaca--;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message+"direkt.: "+fullFile);

                                MyFaultException theFault = new MyFaultException();
                                theFault.Reason = "Greska operacije izvrsiSabiranje: " + e.Message.ToString();
                                throw new FaultException<MyFaultException>(theFault, new FaultReason("greska izvrsi sabiranje!"));
                            }
                        
                            portASCII++;
                        }
                    }
                    else
                    {
                        MyFaultException theFault = new MyFaultException();

                        theFault.Reason = "Unesite br veci od 0!";

                        throw new FaultException<MyFaultException>(theFault, new FaultReason("greska u izvrsi sabiranje(izvrsioci)!"));
                    }
               
           
 #endregion

#region SABIRANJE_MATRICA
                try
                {
                    List<int[][]> matrice = podaci.dobaviPodatke();

                    int[][] A = matrice[0];
                    int[][] B = matrice[1];

                int[] c = Matrica.konvertuj_u_niz(A);
                int[] d = Matrica.konvertuj_u_niz(B);


                rez = new int[c.Count()];

                int jj=0;

                listaDelova = new List<Delovi>();
                List<PodaciZaSabiranje> podaciSab = new List<PodaciZaSabiranje>();
                    
                foreach (SabiranjeClient s in proxies)
                {

                    int[] deo1 = Matrica.podeliNiz(c, proxies.Count(), jj, xc);
                    int[] deo2 = Matrica.podeliNiz(d, proxies.Count(), jj, xc);

                    Delovi delovi = new Delovi(deo1, deo2);
                    listaDelova.Add(delovi);

                    jj++;
                    xclength += deo1.Length;
                    xc = xclength;
                }


                    int ind = 0;
                    List<Thread> niti = new List<Thread>();


                    foreach (SabiranjeClient s in proxies)
                    {
                        SabiranjeClient klijentp = s;

                        PodaciZaSabiranje pod = new PodaciZaSabiranje(listaDelova[ind].deo1, listaDelova[ind].deo2, klijentp,ind);
                        ind++;

                        ParameterizedThreadStart pts = new ParameterizedThreadStart(brIzvrsilaca);
                        Thread thread = new Thread(pts);
                        niti.Add(thread);
                        thread.Start(pod);
                    }

                    for (int ij = 0; ij < niti.Count; ij++)
                    {
                        niti[ij].Join();
                    }


                    List<int[]> nizovilista = new List<int[]>();

                    for (int u = 0; u < proxies.Count; u++)
                    {
                        nizovilista.Add(nizovi[u]);
                    }

                    for (int y = 0; y < nizovilista.Count; y++)
                    {
                        for (int p = 0; p < nizovilista[y].Length; p++)
                        {
                            rez[rn] = nizovilista[y][p];
                            rn++;
                        }

                    }


                int rows = A.Length;
                int cols = A[0].Length;

                C = Matrica.konvertuj_u_matricu(rez,rows,cols);
                podaci.sacuvajPodatke(C);

                }
                catch (Exception e)
                {
                    MyFaultException theFault = new MyFaultException();

                   theFault.Reason = "Greska operacije izvrsiSabiranje: " + e.Message.ToString();

                   throw new FaultException<MyFaultException>(theFault, new FaultReason("greska u izvrsi sabiranje!"));
                }
#endregion

                foreach(Process p in procesi )
                {
                   
                    p.Kill();

                }
                
            }

            return C;
        }

       
        Dictionary<int, int[]> nizovi = new Dictionary<int, int[]>();

        public void brIzvrsilaca(object podaci)
        {
            PodaciZaSabiranje pod;

                 pod = (PodaciZaSabiranje)podaci;
                      
                int[] r = pod.klijentp.SaberiMat(pod.deo1, pod.deo2);

            lock(nizovi)
                nizovi.Add(pod.index, r);
        }

    }
}
