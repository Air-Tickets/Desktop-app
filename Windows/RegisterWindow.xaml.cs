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
    /// Logika interakcji dla klasy RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Exit_Clicked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            string Name = name.Text;
            string Surname = surname.Text;
            string Adress = adress.Text;
            string Email1 = email.Text;
            string Email2 = email2.Text;
            string Password1 = password.Password.ToString();
            string Password2 = password2.Password.ToString();

            if(Name.Length > 0 && Surname.Length > 0 && Adress.Length > 0 && Email1.Length > 0 && Email2.Length > 0 && Password1.Length > 0 && Password2.Length > 0)
            {
                if (Email1 == Email2)
                {
                    if(Password1 == Password2)
                    {
                        //Api request - check if email is taken (return true if email is already taken)
                        bool IsTaken = false;
                        if (!IsTaken)
                        {
                            //Api request - register new user with data that is already in variables (return true if user is registered)
                            bool IsRegistered = true;
                            if (IsRegistered)
                            {
                                RegisterSuccessWindow registerSuccessWindow = new RegisterSuccessWindow();
                                registerSuccessWindow.Show();
                                this.Close();


                            }
                        }
                        else
                        {
                            ErrorMessage.Text = "This email is taken";
                        }
                    }
                    else
                    {
                        ErrorMessage.Text = "Passwords are not the same";
                        password.Password = null;
                        password2.Password = null;
                    }
                }
                else
                {
                    ErrorMessage.Text = "Emails are not the same";
                }
            }
            else
            {
                ErrorMessage.Text = "Complete all fields";
            }

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
            
        }
    }
}
