using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using ServerPodataka;

namespace Izvrsilac
{
    [ServiceContract]
    interface ISabiranje
    {
        [OperationContract]
        [FaultContract(typeof(MyFaultException))]
        int[] SaberiMat(int[] a,int[] b);
    }
}
