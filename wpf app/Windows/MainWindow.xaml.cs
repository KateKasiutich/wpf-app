using System.Windows;

namespace wpf_app
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Book_Button_Click(object sender, RoutedEventArgs e)
        {
            BookFlight newBookFlight = new BookFlight();
            newBookFlight.ShowDialog();
        }

        private void View_Button_Click(object sender, RoutedEventArgs e)
        {
            BookingInfo newBookingInfo = new BookingInfo();
            newBookingInfo.ShowDialog();
        }

        private void Worker_Button_Click(object sender, RoutedEventArgs e)
        {
            WorkWindow newWorkWindow = new WorkWindow();
            newWorkWindow.ShowDialog();
        }
    }
}
