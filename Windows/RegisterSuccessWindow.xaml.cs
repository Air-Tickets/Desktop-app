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

namespace Desktop_app.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy RegisterSuccessWindow.xaml
    /// </summary>
    public partial class RegisterSuccessWindow : Window
    {
        public async void TheEnclosingMethod()
        {

            await Task.Delay(2000);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        public RegisterSuccessWindow()
        {
            
            InitializeComponent();
            TheEnclosingMethod();

        }
    }
}
