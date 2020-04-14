using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace ServerPodataka
{
    [ServiceContract]
    interface IServerPodataka
    {
        [OperationContract]
        [FaultContract(typeof(MyFaultException))]
        void sacuvajPodatke(int[][] mat);

        [OperationContract]
        [FaultContract(typeof(MyFaultException))]
        List<int[][]> dobaviPodatke();


    }
}
