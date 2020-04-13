using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace wpf_app
{
    
    public class DateInfo
    {
        public const string DateTimeFormat = "dd.MM.yyyy HH:mm";

        public static DateTime GetDateTimeFromString(string dateTimeString)
        {
            DateTime dateTime = DateTime.ParseExact(dateTimeString, DateTimeFormat, System.Globalization.CultureInfo.InvariantCulture);
            return dateTime;
        }

        public DateInfo(DateTime department, DateTime arrival)
        {
            if (arrival <= department) throw new Exception("Time travel is prohibited!");
            Department = department;
            Arrival = arrival;
        }

        
        private DateTime department = DateTime.MinValue;
        
        public DateTime Department
        {
            get
            {
                return department;
            }
            private set
            {
                if (value == DateTime.MinValue || value == DateTime.MaxValue)
                {
                    throw new Exception("Error! Incorrect value of Department DateTime!");
                }
                if (value >= arrival)
                {
                    throw new Exception("Error! Department must be earlier than Arrival!");
                }
                department = value;
            }
        }

        
        private DateTime arrival = DateTime.MaxValue;
        
        public DateTime Arrival
        {
            get
            {
                return arrival;
            }
            private set
            {
                if (value == DateTime.MinValue || value == DateTime.MaxValue)
                {
                    throw new Exception("Error! Incorrect value of Arrival DateTime!");
                }
                if (value <= department)
                {
                    throw new Exception("Error! Arrival must be later than Department!");
                }
                arrival = value;
            }
        }

        public string GetDateInfo()
        {
            string info = department.ToString(DateTimeFormat) + " - " + arrival.ToString(DateTimeFormat);
            return info;
        }

        public TimeSpan GetFlyTime()
        {
            TimeSpan interval = arrival - department;
            return interval;
        }

    }
}
