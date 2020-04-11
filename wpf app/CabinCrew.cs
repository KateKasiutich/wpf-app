using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace wpf_app
{
    [DataContract]
    public class CabinCrew : Crew
    {
        public CabinCrew(string name, string email, Positions position, uint lisence) : base(name, email, position)
        {
            Lisence = lisence;
        }

        [DataMember]
        public uint Lisence { get; private set; }

        public new string GetInfoString()
        {
            return GetInfoString(true);
        }

        public new string GetInfoString(bool showMail) // overload method (secоnd overload)
        {
            string info = "Name: " + Name;
            if (showMail) info += ", Mail: " + Email;
            info += ", position: " + GetPositionString();
            info += ", lisence: " + Lisence;

            return info;
        }
    }
}
