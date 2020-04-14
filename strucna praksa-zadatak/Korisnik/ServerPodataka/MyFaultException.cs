using System;
using System.Text;
using System.Runtime.Serialization;

namespace ServerPodataka
{
    [DataContract]
    public class MyFaultException

    {

        private string _reason;

        [DataMember]
        public string Reason

        {

            get { return _reason; }

            set { _reason = value; }

        }

    }

}

