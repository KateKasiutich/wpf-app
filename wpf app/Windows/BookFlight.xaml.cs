using System;
using System.Windows;

namespace wpf_app
{
    public partial class BookFlight : Window
    {
        private Booking booking;
        public BookFlight()
        {
            InitializeComponent();
            booking = Booking.GetInstance();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (flightBox.SelectedIndex != -1)
            {
                Flight flight = (Flight)flightBox.SelectedItem;
                uint passportNumber = 0;
                try
                {
                    passportNumber = Convert.ToUInt32(passengersPassportNumber.Text);

                    Passenger passenger = new Passenger(
                    passengersName.Text,
                    emailTextBox.Text,
                    passportNumber,
                    (uint)(flight.Passengers.Count + 1)
                    );
                    flight.Passengers.Add(passenger);
                    MessageBox.Show("Successfully added!");

                    passengersName.Clear();
                    emailTextBox.Clear();
                    passengersPassportNumber.Clear();

                }
                catch (Exception)
                {
                    MessageBox.Show("Please, enter correct passport number!");
                }
            }
            else
            {
                MessageBox.Show("Please, choose one flight!");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            flightBox.ItemsSource = booking.Flights;
        }
    }
}
