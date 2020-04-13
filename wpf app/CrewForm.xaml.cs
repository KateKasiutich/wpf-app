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
    /// Interaction logic for CrewForm.xaml
    /// </summary>
    public partial class CrewForm : Window
    {
        private Booking booking;
        public CrewForm()
        {
            InitializeComponent();
            booking = Booking.GetInstance();
            FlightBox.ItemsSource = booking.Flights;
        }

        private void AddWorker_Click(object sender, RoutedEventArgs e)
        {
            if (workersLicense.Text != null && workersName.Text != null && workersEmail.Text != null && workersPosition.SelectedItem != null)
            {
                Positions position = (Positions)workersPosition.SelectedItem;
                uint lisence = 0;
                try
                {
                    lisence = Convert.ToUInt32(workersLicense.Text);

                    Crew crew = new Crew(
                    workersName.Text,
                    workersEmail.Text,
                    position);

                    Flight flight = (Flight)FlightBox.SelectedItem;
                    if (flight == null) throw new Exception();

                    flight.Crew.Add(crew);
                    MessageBox.Show("Successfully added!");

                    workersName.Clear();
                    workersEmail.Clear();
                    workersLicense.Clear();
                    FlightBox.SelectedIndex = -1;


                }
                catch (Exception)
                {
                    MessageBox.Show("Please, fill all fields!");
                }
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            workersPosition.ItemsSource = new Positions[] { Positions.Stewardess, Positions.Pilot, Positions.Administartor };
        }
    }
}
