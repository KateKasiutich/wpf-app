using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace wpf_app
{
    
    public class Booking
    {
        private static Booking instance;

        public List<City> Cities { get; private set; }
        
        public List<Flight> Flights { get; private set; }

        private Booking()
        {
            Cities = new List<City>();
            Flights = new List<Flight>();

            City city = new City("HolyLand");
            List<DateTime> departmentList = new List<DateTime>();
            departmentList.Add(DateInfo.GetDateTimeFromString("03.12.1999 15:51"));
            departmentList.Add(DateInfo.GetDateTimeFromString("12.12.1987 10:10"));
            departmentList.Add(DateInfo.GetDateTimeFromString("06.06.2012 21:21"));
            List<DateTime> arrivalList = new List<DateTime>();
            arrivalList.Add(DateInfo.GetDateTimeFromString("15.10.2018 12:21"));
            arrivalList.Add(DateInfo.GetDateTimeFromString("28.06.2007 10:20"));
            arrivalList.Add(DateInfo.GetDateTimeFromString("27.07.2017 20:30"));
            Airport newAirport = new Airport("Olimp", 5, departmentList, arrivalList, city);
            city.Airports.Add(newAirport);
            Cities.Add(city);

            city = new City(

               "LaLaLand",
               new List<Airport>()
               {
                    new Airport(
                        "Hell On Earth",
                        0,
                        new List<DateTime>()
                        {
                            DateInfo.GetDateTimeFromString("02.02.1980 21:31")
                        },
                        new List<DateTime>()
                        {
                            DateInfo.GetDateTimeFromString("13.12.1992 23:23"),
                            DateInfo.GetDateTimeFromString("13.12.1992 23:23")
                        },
                        city
                        ),

                    new Airport(
                        "Heaven On Earth",
                         10,
                        new List<DateTime>()
                        {
                            DateInfo.GetDateTimeFromString("02.02.1902 21:31"),
                            DateInfo.GetDateTimeFromString("02.02.1902 21:31")
                        },
                        new List<DateTime>()
                        {
                            DateInfo.GetDateTimeFromString("13.12.1998 23:23")
                        },
                        city
                          )
               });
            Cities.Add(city);

            city = new City(

              "Gotham",
              new List<Airport>()
              {
                    new Airport(
                        "Gold",
                        10,
                        new List<DateTime>()
                        {
                            DateInfo.GetDateTimeFromString("02.10.1988 21:00")
                        },
                        new List<DateTime>()
                        {
                            DateInfo.GetDateTimeFromString("15.06.1999 23:20")
                        },
                        city
                        ),

                    new Airport(
                        "Silver",
                         9,
                        new List<DateTime>()
                        {
                            DateInfo.GetDateTimeFromString("03.05.2017 21:25")
                        },
                        new List<DateTime>()
                        {
                            DateInfo.GetDateTimeFromString("13.12.2016 15:30")
                        },
                        city
                          )
              });
            Cities.Add(city);



        }

        public static Booking GetInstance() //static method
        {
            if (instance == null)
                instance = new Booking();
            return instance;
        }
    }
}
