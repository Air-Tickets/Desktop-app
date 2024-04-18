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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

using System.Diagnostics;
using Desktop_app.Windows;
using System.Net.Http;

namespace Desktop_app
{
    public partial class MainWindow : Window
    {
        public const string ApiIp = "172.31.111.124:8080";

        const string folderName = "desktop-app";
        static string path = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile).ToString() + @"\" + folderName;
        static string filepath = path + @"\loginInfo.txt";
        public MainWindow()
        {
            this.Visibility = Visibility.Hidden;
            User user = new User();
            InitializeComponent();
            if (File.Exists(filepath))
            {
                using (StreamReader sr = File.OpenText(filepath))
                {
                    string login = sr.ReadLine();
                    string pass = sr.ReadLine();
                    loggin(login, pass);
                }
            }
            else
            {
                this.Visibility = Visibility.Visible;
            }
        }
        private async void loggin(string login, string password)
        {
            User user = new User();
            var client = new HttpClient();
            var stringContent = new StringContent(password);
            var response = await client.PostAsync("http://" + ApiIp + "/api/account/login/" + login, stringContent);
            var jsonRespone = await response.Content.ReadAsStringAsync();
            if (jsonRespone == "")
            {
                ErrorMessage.Text = "wrong email or password";
            }
            else
            {
                user = new User(jsonRespone.ToString());
                Console.WriteLine(jsonRespone.ToString());
                HomeWindow homeWindow = new HomeWindow(user, ApiIp);
                homeWindow.Show();
                this.Close();
            }
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }

        private async void loginButton_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            string login = email.Text;
            string pass = password.Password.ToString();
            bool stayLogged = StayLogged.IsChecked == true;
            if(pass.Length > 0 && login.Length > 0)
            {
                var client = new HttpClient();
                var stringContent = new StringContent(pass);
                var response = await client.PostAsync("http://" + ApiIp + "/api/account/login/" + login, stringContent);
                var jsonRespone = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(jsonRespone);
                if (jsonRespone == "")
                {
                    ErrorMessage.Text = "Wrong email or password";
                    password.Password = null;
                }
                else
                {
                    user = new User(jsonRespone.ToString());
                    HomeWindow homeWindow = new HomeWindow(user, ApiIp);
                    homeWindow.Show();
                    this.Close();

                    if (stayLogged)
                    {
                        try
                        {
                            if (!Directory.Exists(path))
                            {
                                DirectoryInfo di = Directory.CreateDirectory(path);
                                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                                using (StreamWriter sw = File.CreateText(filepath))
                                {
                                    sw.WriteLine(login);
                                    sw.WriteLine(pass);
                                }
                            }
                        }
                        catch (Exception ez)
                        {
                            Console.WriteLine("The process failed: {0}", ez.ToString());
                        }
                        finally
                        {
                            if (!File.Exists(filepath))
                            {
                                using (StreamWriter sw = File.CreateText(filepath))
                                {
                                    sw.WriteLine(login);
                                    sw.WriteLine(pass);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                ErrorMessage.Text = "Complete both fields";       
            }
        }

        private void Exit_Clicked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
