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

namespace Desktop_app
{
    /// <summary>
    /// Logika interakcji dla klasy HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow(User user)
        {
            InitializeComponent();
            Console.WriteLine();
            TextBlock welcome_text = Welcome_text;
            welcome_text.Text = "Welcome " + user.Imie + "!";
            TextBox name_text = Name_text;
            TextBox surname_text = Surname_text;
            TextBox pesel_text = Pesel_text;
            name_text.Text = user.Imie;
            surname_text.Text = user.Nazwisko;
            pesel_text.Text=user.PESEL;
        }

        private void SelcetSeat_btn_Click(object sender, RoutedEventArgs e)
        {
            TextBlock selcectedFlight_text = SelcectedFlight_text;
            if (selcectedFlight_text.Text != "")
            {
                Windows.Select_seat select_Seat = new Windows.Select_seat();
                select_Seat.Show();
            }
            else
            {
                string messageBoxText = "NO flight chosen";
                string caption = "AMELKA";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Exclamation;
                MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
        }

        private void SelcetFlight_btn_Click(object sender, RoutedEventArgs e)
        {
            Windows.FlightWindow flightWidnow = new Windows.FlightWindow();
            flightWidnow.Show();
        }
    }
}
