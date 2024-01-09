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

namespace Desktop_app
{
    public partial class MainWindow : Window
    {
        const string folderName = "desktop-app";
        static string path = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile).ToString() + @"\" + folderName;
        static string filepath = path + @"\loginInfo.txt";
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(filepath))
            {
                using (StreamReader sr = File.OpenText(filepath))
                {
                    string login = sr.ReadLine();
                    string pass = sr.ReadLine();
                    int userId = 1;
                //Send to Api request for user id.
                    if (userId != 0)
                    {
                        HomeWindow homeWindow = new HomeWindow(userId);
                        homeWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        ErrorMessage.Text = "wrong email or password";
                    }
                }
            }

        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = email.Text;
            string pass = password.Password.ToString();
            bool stayLogged = StayLogged.IsChecked == true;
            int userId = 1;
            if(pass.Length > 0 && login.Length > 0)
            {
        //Send to Api request for user id.
                if (userId != 0)
                {
                    HomeWindow homeWindow = new HomeWindow(userId);
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
                                //Console.WriteLine("The file was created successfully");

                                // Delete the directory.
                                /*di.Delete();
                                Console.WriteLine("The directory was deleted successfully.");*/
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
                else
                {
                    ErrorMessage.Text = "Wrong email or password";
                    password.Password = null;
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
