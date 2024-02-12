using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Desktop_app.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy Select_seat.xaml
    /// </summary>
    /// 
    

    public partial class Select_seat : Window
    {

        public Select_seat()
        {

            List<seat> MyCollection = new List<seat>();

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
            foreach(seat seat in MyCollection)
            {
                MyList.Add(seat.SeatName);
            }

            InitializeComponent();
            Console.WriteLine(MyList[1]);
            this.DataContext = MyList;

        }
        

    }
}
