using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace wpf_app
{
    
    public class Flight
    {
        
        public List<Passenger> Passengers { get; private set; }
        
        public List<Crew> Crew { get; private set; }
        
        public List<CabinCrew> CabinCrew { get; private set; }

        
        private readonly uint id;

        public Flight(uint flightId, Airport departmentAirport, Airport arrivalAirport, DateInfo flightInfo, List<Passenger> passengers, List<Crew> crew, List<CabinCrew> cabinCrew) : this(flightId, departmentAirport, arrivalAirport, flightInfo)
        {
            Passengers = passengers;
            Crew = crew;
            CabinCrew = cabinCrew;
        }

        public Flight(uint flightId, Airport departmentAirport, Airport arrivalAirport, DateInfo flightInfo)
        {
            id = flightId;
            Passengers = new List<Passenger>();
            Crew = new List<Crew>();
            CabinCrew = new List<CabinCrew>();
            DepartmentAirport = departmentAirport;
            ArrivalAirport = arrivalAirport;
            FlightInfo = flightInfo;
        }

        public uint GetID()
        {
            return id;
        }

        
        private Airport departmentAirport;
        
        public Airport DepartmentAirport
        {
            get
            {
                return departmentAirport;
            }
            private set
            {
                if (value == null)
                {
                    throw new Exception("Error!");
                }

                departmentAirport = value;
            }
        }

        public override string ToString()
        {
            string str = "Flight №" + GetID() + ": ";
            str += "from " + DepartmentAirport.AirportTitle + " to " + ArrivalAirport.AirportTitle;
            str += ", " + FlightInfo.GetDateInfo();
            return str;
        }

        
        private Airport arrivalAirport;
        
        public Airport ArrivalAirport
        {
            get
            {
                return arrivalAirport;
            }
            private set
            {
                if (value == null)
                {
                    throw new Exception("Error!");
                }

                arrivalAirport = value;
            }
        }

        
        private DateInfo flightInfo;
        
        public DateInfo FlightInfo
        {
            get
            {
                return flightInfo;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception("Error!");
                }

                flightInfo = value;
            }
        }
    }
}
