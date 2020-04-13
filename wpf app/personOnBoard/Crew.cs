using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace wpf_app
{
    
    public class Crew : PersonOnBoard
    {
        
        public Positions Position { get; protected set; }

        public Crew(string name, string email, Positions position) : base(name, email)
        {
            Position = position;
        }

        public string GetPositionString()
        {
            switch (Position)
            {
                case Positions.Stewardess:
                    return "Stewardess";
                case Positions.Pilot:
                    return "Pilot";
                case Positions.Administartor:
                    return "Administrator";
                default:
                    throw new Exception("Error! Unknown position!");
            }
        }

        public new string GetInfoString()
        {
            return GetInfoString(true);
        }

        public string GetInfoString(bool showMail) // overload method (first overload)
        {
            string info = "Name: " + Name;
            if (showMail) info += ", Mail: " + Email;
            info += ", position: " + GetPositionString();

            return info;
        }
    }
}
