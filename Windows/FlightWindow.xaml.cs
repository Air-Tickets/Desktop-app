using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Common;
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

        public FlightWindow(string ApiIp)
        {
            InitializeComponent();
            flightListContent(ApiIp);
            FillDataGrid();


        }

    public void FillDataGrid()
        {
            DataGridTemplateColumn selectColumn = new DataGridTemplateColumn();
            selectColumn.Header = "Select";
            FrameworkElementFactory buttonFactory = new FrameworkElementFactory(typeof(Button));
            buttonFactory.SetValue(Button.ContentProperty, "Select");
            buttonFactory.SetValue(Button.BackgroundProperty, Brushes.LightBlue);
            buttonFactory.SetValue(Button.BorderBrushProperty, Brushes.Black);
            buttonFactory.SetValue(Button.BorderThicknessProperty, new Thickness(1));
            buttonFactory.SetValue(Button.ForegroundProperty, Brushes.Black);
            buttonFactory.AddHandler(Button.ClickEvent, new RoutedEventHandler(SelectButton_Click));
            DataTemplate buttonTemplate = new DataTemplate();
            buttonTemplate.VisualTree = buttonFactory;
            selectColumn.CellTemplate = buttonTemplate;
            selectColumn.Width = 150;
            FlightsGrid.Columns.Add(selectColumn);

            FlightsGrid.Columns.Add(new DataGridTextColumn
            {
                Header = "Miejsce Startowe",
                Binding = new Binding("miejsce_startowe")
            });
            FlightsGrid.Columns.Add(new DataGridTextColumn
            {
                Header = "Miejsce Docelowe",
                Binding = new Binding("miejsce_docelowe")
            });
            FlightsGrid.Columns.Add(new DataGridTextColumn
            {
                Header = "Godzina Odlotu",
                Binding = new Binding("godzina_odlotu")
            });
            FlightsGrid.Columns.Add(new DataGridTextColumn
            {
                Header = "Godzina Boardingu",
                Binding = new Binding("godzina_boardingu")
            });
            FlightsGrid.Columns.Add(new DataGridTextColumn
            {
                Header = "Przewoznik",
                Binding = new Binding("przewoznik")
            });
            FlightsGrid.Columns.Add(new DataGridTextColumn
            {
                Header = "Numer_lotu",
                Binding = new Binding("numer_lotu")
            });
            FlightsGrid.Columns.Add(new DataGridTextColumn
            {
                Header = "Liczba Kupionych Biletow",
                Binding = new Binding("liczba_kupionych_biletow")
            });

        }
        private void SelectButton_Click(object sender, RoutedEventArgs e)
    {
        // Pobierz wiersz (lot) powiązany z guzikiem
        var button = sender as Button;
        var dataGridRow = FindAncestor<DataGridRow>(button);
        var selectedFlight = (flight)dataGridRow.Item;

        // Tutaj możesz wykonać dowolne działania związane z wybranym lotem
        Console.WriteLine("Wybrano lot o ID: " + selectedFlight.id);
    }

    private T FindAncestor<T>(DependencyObject current) where T : DependencyObject
    {
        do
        {
            if (current is T ancestor)
            {
                return ancestor;
            }
            current = VisualTreeHelper.GetParent(current);
        }
        while (current != null);
        return null;
    }
    public async void flightListContent(string ApiIp)
        {
            List<flight> flightList = new List<flight>();
            var client = new HttpClient();
            var response = await client.GetAsync("http://"+ApiIp+"/api/flight");
            var jsonRespone = await response.Content.ReadAsStringAsync();
            JArray json = JArray.Parse(jsonRespone);
            foreach (var item in json)
            {
                flightList.Add(new flight(item));
            }
            FlightsGrid.ItemsSource = flightList;

        }
    }
}
