using System;
using System.Collections.Generic;
using System.Windows;


namespace wpf_app
{
    /// <summary>
    /// Interaction logic for BookingInfo.xaml
    /// </summary>
    public partial class BookingInfo : Window
    {
        public BookingInfo()
        {
            booking = Booking.GetInstance();
            InitializeComponent();
        }

        private Booking booking;

        private void InformationForm_Load(object sender, EventArgs e)
        {
            List<Passenger> passengers = new List<Passenger>();
            List<Crew> crew = new List<Crew>();
            foreach (Flight flight in booking.Flights)
            {
                passengers.AddRange(flight.Passengers);
                crew.AddRange(flight.Crew);
            }
            passengersInfo.ItemsSource = passengers;
            crewInfo.ItemsSource = crew;
        }
    }
}
