using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace wpf_app
{
    /// <summary>
    /// Interaction logic for WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        private Booking booking;
        public WorkWindow()
        {
            booking = Booking.GetInstance();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            departmentCity.ItemsSource = booking.Cities.ToArray();
            arrivalCity.ItemsSource = booking.Cities.ToArray();
        }

        private void AddFlight_Click(object sender, RoutedEventArgs e)
        {
            if (arrivalCity.SelectedIndex != -1 && arrivalAirport.SelectedIndex != -1 && departmentCity.SelectedIndex != -1 && departmentAirport.SelectedIndex != -1)
            {
                try
                {
                    DateInfo dateInfo = new DateInfo(
                        (DateTime)departmentTime.SelectedItem,
                        (DateTime)arrivalTime.SelectedItem
                        );

                    Flight flight = new Flight(
                        (uint)(booking.Flights.Count + 1),

                        (Airport)departmentAirport.SelectedItem,
                        (Airport)arrivalAirport.SelectedItem,
                        dateInfo
                        );

                    booking.Flights.Add(flight);
                    MessageBox.Show("Successfully added!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OKCancel);
                }
            }
            else
            {
                MessageBox.Show("You must select all requested elements!", "Warning!", MessageBoxButton.OKCancel);
            }

        }

        private void DepartmentCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            departmentAirport.Items.Refresh();
            departmentAirport.ItemsSource = ((City)departmentCity.SelectedItem)?.Airports.ToArray();
        }

        private void ArrivalCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            arrivalAirport.Items.Refresh();
            arrivalAirport.ItemsSource = ((City)arrivalCity.SelectedItem)?.Airports.ToArray();
        }

        private void DepartmentAirport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            departmentTime.Items.Refresh();
            departmentTime.ItemsSource = ((Airport)departmentAirport.SelectedItem)?.AllowedDT.ToArray();
        }

        private void ArrivalAirport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            arrivalTime.Items.Refresh();
            arrivalTime.ItemsSource = ((Airport)arrivalAirport.SelectedItem)?.AllowedAT.ToArray();
        }

        private void AddWorker_Click(object sender, RoutedEventArgs e)
        {
            CrewForm newCrewForm = new CrewForm();
            newCrewForm.ShowDialog();
        }
    }
}
