using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace wpf_app
{
    [DataContract]
    public class Passenger : PersonOnBoard
    {
        public Passenger(string name, string email, uint passportNumber, uint ticketNumber) : base(name, email)
        {
            this.passportNumber = passportNumber;
            this.ticketNumber = ticketNumber;
        }

        [DataMember]
        private readonly uint ticketNumber; //passenger's ticket number cant't change during the flight
        public uint GetTicketNumber()
        {
            return ticketNumber;
        }

        [DataMember]
        private readonly uint passportNumber;
        public uint GetPassportNumber()
        {
            return passportNumber;
        }

        public new string GetInfoString()
        {
            string info = "Name: " + Name + ", mail" + Email + ", paasport number: " + GetPassportNumber() + ", ticket nnumber" + GetTicketNumber();

            return info;
        }
    }
}
