using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
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

namespace Desktop_app.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy Select_seat.xaml
    /// </summary>
    /// 
    

    public partial class Select_seat : Window
    {
        List<string> Takenseats = new List<string>();
        List<seat> MyCollection = new List<seat>();
        public Select_seat(int selectedFlightId, string ApiIp)
        {
            selectedSeats(ApiIp, selectedFlightId);
            Console.WriteLine(selectedFlightId);

            for(int i = 1; i <= 32; i++)
            {
                MyCollection.Add(new seat(i + "A", false));
                MyCollection.Add(new seat(i + "B", false));
                MyCollection.Add(new seat(i + "C", false));
                MyCollection.Add(new seat(i + "D", false));
                MyCollection.Add(new seat(i + "E", false));
                MyCollection.Add(new seat(i + "F", false));
            }
            List<string> MyList = new List<string>();
            foreach (seat seat in MyCollection)
            {
                MyList.Add(seat.SeatName);
            }
            

            

            InitializeComponent();
            //Console.WriteLine(MyList[1]);

            Button foundButton = VisualTreeHelperExtensions.FindButtonByText(this, "1A");
            //Console.Write("lala" + foundButton);
            if (foundButton != null)
            {
                foundButton.Background = Brushes.Red;
                // Znaleziono przycisk, można wykonać dalsze działania...
            }
        }
        private void onSeatClick(object sender, RoutedEventArgs e)
        {
            if(sender is Button)
            {
                Button button = sender as Button;
                var seat = button.Content.ToString();
                HomeWindow.
                
            }
            
        }

        public static class VisualTreeHelperExtensions
        {
            public static Button FindButtonByText(DependencyObject parent, string text)
            {
                if (parent == null) return null;

                int childCount = VisualTreeHelper.GetChildrenCount(parent);
                for (int i = 0; i < childCount; i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                    Button button = child as Button;

                    if (button != null && button.Content != null && button.Content.ToString() == text)
                    {
                        return button;
                    }

                    Button foundButton = FindButtonByText(child, text);
                    if (foundButton != null)
                    {
                        return foundButton;
                    }
                }

                return null;
            }
        }
        public async void selectedSeats(string ApiIp, int idLotu)
        {
            List<string> selectedSeatsList = new List<string>();
            var client = new HttpClient();
            var response = await client.GetAsync("http://" + ApiIp + "/api/ticket/takenSeats/" + idLotu);
            var jsonRespone = await response.Content.ReadAsStringAsync();
            JArray json = JArray.Parse(jsonRespone);
            foreach (var item in json)
            {
                selectedSeatsList.Add(item.ToString());
            }
            Takenseats = selectedSeatsList;
            Console.WriteLine(Takenseats.Count);
            for (int z = 0; z < Takenseats.Count; z++)
            {
                int a = MyCollection.FindIndex(x => x.SeatName.Contains(Takenseats[z]));
                MyCollection[a] = new seat(Takenseats[z], true);
                Console.WriteLine(MyCollection[a].IsTaken);
                this.DataContext = MyCollection;
            }
        }
    }
}

