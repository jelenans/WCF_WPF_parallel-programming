using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using ServerPodataka;

namespace Rasporedjivac
{
    [ServiceContract]
    interface IKomanda
    {
        [OperationContract]
        [FaultContract(typeof(MyFaultException))]
        int[][] izvrsiSabiranje(bool ok, int br);

        [OperationContract]
        [FaultContract(typeof(MyFaultException))]
        void brIzvrsilaca(object podaci);
    }
}
