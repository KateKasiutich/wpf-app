using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace wpf_app
{
    
    public class City
    {
        
        public List<Airport> Airports { get; private set; }

        
        private string cityName;
        
        public string CityName
        {
            get
            {
                return cityName;
            }
            private set //airport can't change it's city
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Error!");
                }
                else
                {
                    cityName = value;
                }
            }

        }


        public City(string cityName, List<Airport> cityAirports) //dependency injection
        {
            CityName = cityName;
            Airports = cityAirports;

        }

        public City(string cityName) : this(cityName, new List<Airport>()) { }
        public City() : this(null, new List<Airport>()) { }


        public override string ToString()
        {
            return CityName;
        }

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            foreach (Airport airport in Airports.ToArray())
            {
                Airport newAirport = new Airport(
                    airport.AirportTitle,
                    airport.AirportRating,
                    airport.AllowedDT,
                    airport.AllowedAT,
                    this // При десериализации мы потеряем ссылку на город в аэропорте
                    );   // поэтому нам его необходимо пересоздать

                Airports.Remove(airport); // Удаляем старый аэропорт без ссылки на город
                Airports.Add(newAirport); // Добавляем точно такой, но теперь со ссылкой на город
            }
        }
    }
}
