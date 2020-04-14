using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ServiceModel;
using System.Diagnostics;
using System.Threading;
using System.ServiceModel.Description;
using System.IO;
using ServerPodataka;


namespace WPFMatrice
{
    /// <summary>
    /// Interaction logic for UnosMatrica.xaml
    /// </summary>
    public partial class UnosMatrica : Window
    {
      
        ServerPodatakaClient podaci = new ServerPodatakaClient();
        KomandaClient komanda = new KomandaClient();
        int[][] A;
        int[][] B;

        int[][] matricaA;
        int[][] matricaB;



        const string putanja = "";
        FileInfo file ;
        string fullFile;

        int N;
        bool randOpcija=false;


 #region UNOS_KONSTRUKTOR
        public UnosMatrica(int m,int n)
        {
            InitializeComponent();

            string[] vrste = new string[m];

            matricaA = new int[m][];

            for (int k = 0; k < m; k++)
            {
                matricaA[k] = new int[n];
            }


            matricaB = new int[m][];

            for (int k = 0; k < m; k++)
            {
                matricaB[k] = new int[n];
            }

           
            lA.Content = "Unesite "+m+" vrste matrice A:";
            lA.FontFamily = new FontFamily("Euphemia");
            lA.FontWeight = FontWeights.Bold;
            lA.FontSize = 12;
           
            pr.Content = "(sa razmakom između el.)";
            
           
            lB.Content = "Unesite "+m+" vrste matrice B:";
            lB.FontFamily = new FontFamily("Euphemia");
            lB.FontWeight = FontWeights.Bold;
            lB.FontSize = 12;
            
            prb.Content = "(npr. [1 2 3 4])";

            
           
            for(int i = 0; i < matricaA.Length; i++)
            {
              
                TextBox vrsta = new TextBox();              
                vrsta.PreviewTextInput+= new TextCompositionEventHandler(vrsta_PreviewTextInput); 
               

                DataObject.AddPastingHandler(vrsta,new  DataObjectPastingEventHandler(vrsta_Pasting));
                stackPanel1.Children.Add(vrsta);

                TextBox vrstab = new TextBox();
                vrstab.PreviewTextInput += new TextCompositionEventHandler(vrsta_PreviewTextInput);
              

                DataObject.AddPastingHandler(vrstab, new DataObjectPastingEventHandler(vrsta_Pasting));
                stackPanel2.Children.Add(vrstab);
               
            }
            lbBrIzvrs.Content = "Broj izvršilaca:"; 
            tbBrIzvrsilaca.PreviewTextInput += new TextCompositionEventHandler(vrsta_PreviewTextInput);
            DataObject.AddPastingHandler(tbBrIzvrsilaca, new DataObjectPastingEventHandler(vrsta_Pasting));
            tbBrIzvrsilaca.Visibility = Visibility.Visible;

        }
#endregion

 #region RANDOM_KONSTRUKTOR
        public UnosMatrica(int[][] matrA,int[][] matrB)
        {
            InitializeComponent();


        
            N = 3;

            randOpcija = true;

                int rows = matrA.Length;
                int cols = matrA[0].Length;
              

                A = new int[rows][];
                B = new int[rows][];

                for (int k = 0; k < rows; k++)
                {
                    A[k] = new int[cols];
                    B[k] = new int[cols];
                }   

            Label labA = new Label();
            labA.Content = "matrica A: ";
            labA.FontFamily = new FontFamily("Euphemia");
            labA.FontWeight = FontWeights.Bold;
            labA.FontSize = 13;
            stackPanel1.Children.Add(labA);
          
           

            for (int i = 0; i < matrA.Length; i++)
            {
                Label lab = new Label();
                lab.FontFamily = new FontFamily("Euphemia");

                for (int j = 0; j < matrA[i].Length; j++)
                {
                    lab.Content += matrA[i][j] + " ";
                    A[i][j]= matrA[i][j];
                  

                }
                stackPanel1.Children.Add(lab);
          

            }


            Label labB = new Label();
            labB.Content = "matrica B: ";
            labB.FontFamily = new FontFamily("Euphemia");
            labB.FontWeight = FontWeights.Bold;
            labB.FontSize = 13;
            stackPanel2.Children.Add(labB);
 

            for (int i = 0; i < matrB.Length; i++)
            {
                Label labb = new Label();
                labb.FontFamily = new FontFamily("Euphemia");

                for (int j = 0; j < matrB[i].Length; j++)
                {

                    labb.Content += matrB[i][j] + " ";
                    B[i][j] = matrB[i][j];

                }

                stackPanel2.Children.Add(labb);

            }

            lbBrIzvrs.Content = "Broj izvršilaca: ";

        }

#endregion

 #region VALIDACIJA

        private void vrsta_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {

                String Text1 = (String)e.DataObject.GetData(typeof(String));


                if (!TextBoxTextAllowed(Text1)) e.CancelCommand();

            }

            else e.CancelCommand();
        }


        private void vrsta_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !TextBoxTextAllowed(e.Text);
        }

        private Boolean TextBoxTextAllowed(String Text2)
        {


            return Array.TrueForAll<Char>(Text2.ToCharArray(),

                delegate(Char c) { return Char.IsDigit(c) || Char.IsControl(c); });

        }


        #endregion


        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (randOpcija == false)
            {

                MessageBoxResult rez = new MessageBoxResult();

                rez = Provera_i_Preuzimanje.proveraUnosa(stackPanel1, matricaA[0].Length);
                if (!rez.Equals(MessageBoxResult.None))
                    return;

                rez = Provera_i_Preuzimanje.proveraUnosa(stackPanel2, matricaA[0].Length);
                if (!rez.Equals(MessageBoxResult.None))
                    return;
            }
            if (tbBrIzvrsilaca.Text.Trim().Length == 0)
            {
                MessageBox.Show("Popunite sva polja!");
                return;
            }

            int br;

            Process pServerPodataka = new Process();

            try
            {


                file = new FileInfo("ServerPodataka.exe");
                fullFile = file.FullName;

                pServerPodataka.StartInfo.FileName = fullFile;
                pServerPodataka.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                pServerPodataka.Start();

                MessageBox.Show("Računanje je u toku!");
            }
            catch (FaultException<MyFaultException> exx)
            {
                MessageBox.Show("server podataka"+exx.Message);
            }

            if (randOpcija == true)
            {
                try
                {

                    podaci.sacuvajPodatke(A);
                    podaci.sacuvajPodatke(B);

                }
                catch (FaultException<MyFaultException> ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
            else {

                try{
                matricaA= Provera_i_Preuzimanje.preuzmiMatricu(matricaA,stackPanel1);
                matricaB= Provera_i_Preuzimanje.preuzmiMatricu(matricaB, stackPanel2);

                podaci.sacuvajPodatke(matricaA);
                podaci.sacuvajPodatke(matricaB);

                }
                catch (FaultException<MyFaultException> ex)
                {
                    MessageBox.Show(ex.Message);

                }

              
            }

            int Nn = Int32.Parse(tbBrIzvrsilaca.Text);
            br = Nn;

            file = new FileInfo("Rasporedjivac.exe");
            fullFile = file.FullName;

            Process pRasporedjivac = new Process();
            pRasporedjivac.StartInfo.FileName = fullFile;



            pRasporedjivac.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            try
            {
               pRasporedjivac.Start();

            }
            catch (FaultException<MyFaultException> ex)
            {
                MessageBox.Show(ex.Message);
            }


                            int[][] D = null;
            try
            {
                D = komanda.izvrsiSabiranje(true, br);

            }
            catch (FaultException<MyFaultException> ex)
            {
                MessageBox.Show(ex.Message + " izvrsiSabFault" + " " + ex.Detail);
            }

            pServerPodataka.Kill();
            pRasporedjivac.Kill();


            Rez rezultat = new Rez(D);
            rezultat.ShowDialog();
    

        }


        private void Nazad_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();

        }


       

     
    }
} 
