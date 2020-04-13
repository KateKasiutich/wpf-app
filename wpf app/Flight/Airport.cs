using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace wpf_app
{

    public class Airport : IComparable
    {

        public City City { get; private set; }

        public Airport(string airportTitle, int rating, List<DateTime> allowedDepartmentTime, List<DateTime> allowedArrivalTime, City city)
        {
            AirportRating = rating;
            AirportTitle = airportTitle;
            AllowedDT = allowedDepartmentTime;
            AllowedAT = allowedArrivalTime;
            City = city;
        }

        public Airport()
        {
            AllowedAT = new List<DateTime>();
            AllowedDT = new List<DateTime>();
        }


        private string airportTitle;

        public string AirportTitle
        {
            get
            {
                return airportTitle;

            }
            set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Input shouldn`t be empty!");
                }
                airportTitle = value;
            }


        }


        private int rating;
        const int MaxRating = 10;

        public int AirportRating
        {
            get
            {
                return rating;
            }
            set
            {
                if (value > MaxRating)
                {
                    rating = MaxRating;

                }
                else
                {
                    rating = value;
                }
            }
        }


        public List<DateTime> AllowedAT { get; private set; }

        public List<DateTime> AllowedDT { get; private set; }

        public int CompareTo(object obj) // добавдяем сравнение
        {
            Airport a = obj as Airport;
            if (a != null)
            {
                int result = AirportTitle.CompareTo(a.AirportTitle); //сравниваем по названию аэропорта
                if (result == 0) result = AirportRating.CompareTo(a.AirportRating); // по рейтингу
                if (result == 0) result = City.CityName.CompareTo(a.City.CityName); // по названию города
                return result;
            }
            else
            {
                throw new Exception("It's impossible to compare two objects");
            }
        }

        public override string ToString()
        {
            return AirportTitle;
        }
    }
}
