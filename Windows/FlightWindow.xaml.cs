using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
    /// Logika interakcji dla klasy FlightWindow.xaml
    /// </summary>
    public partial class FlightWindow : Window
    {
        List<flight> flightList = new List<flight>(); 
        public FlightWindow()
        {
            flightListContent();
            InitializeComponent();
            //this.Close();
        }
        public async void flightListContent()
        {
            flight Flight = new flight();
            var client = new HttpClient();
            var response = await client.GetAsync("http://172.31.111.124:8080/api/flight");
            var jsonRespone = await response.Content.ReadAsStringAsync();
            JArray json = JArray.Parse(jsonRespone);
            foreach (var item in json)
            {
                flightList.Add(new flight(item));
            }
            Console.WriteLine(json[0]);

            //JESZCZE NIE DZIAŁA
            List<List<string>> MyArray = new List<List<string>>();
            for (int i = 0; i < json.Count; i++)
            {
                
                foreach (var item in json)
                {
                    List<string> myarray1 = new List<string>();
                    myarray1.Add(item["id"].ToString());
                    MyArray.Add(myarray1);

                }
            }
            


            //Flight = new flight(json[0]);
            this.DataContext = MyArray;
            
        }
    }
}
