using st_Mihailova_telecom1_project;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Timers;
using System.Web;
using System.Web.Security;
using System.Windows;
using System.Windows.Input;

namespace st_Mihailova_telecom1_projectApp
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public string code = "";
        public User user;
        public Role role;
        
        public Authorization()
        {
            InitializeComponent();
            number.Focus();
            Code.IsEnabled = false;
            Login.IsEnabled = false;
            password.IsEnabled = false;
            UpdateCode.Visibility  = Visibility.Hidden;
        }


        private void Check_enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                user = st1_Mihailova_telecomEntities.getContext().User.FirstOrDefault(a => a.Password == password.Text);
                if (user == null)
                {
                    MessageBox.Show("Неверный пароль", "Error password");
                }
                else
                {
                    Generate_code();
                }
                UpdateCode.Visibility = Visibility.Visible;
            }
            
        }
        private void Generate_code()
        {
            code = Membership.GeneratePassword(8, 1);
            MessageBox.Show($"Код для доступа в систему: {code}", "GodeLogin");
            Code.IsEnabled = true;
            Code.Focus();
        }

        

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (role != null && user != null && Code.Text == code.ToString())
            {
                MessageBox.Show($"{role.Name}", "Role");
                new MainWindow().Show();
                Close();
            }
            else
            {
                MessageBox.Show("Пароль, номер или код введены неправильно", "Data verification");
            }
            
        }

        private void numder_enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                role = st1_Mihailova_telecomEntities.getContext().Role.FirstOrDefault(a => a.Number == number.Text);
                if (role != null)
                {
                    password.IsEnabled = true;
                    password.Focus();
                    Login.IsEnabled = true;
                }
                else
                {
                    password.IsEnabled = false;
                    Login.IsEnabled = false;
                    MessageBox.Show("Номер введен неправильно", "Data verification");
                }
            }
        }


        private void Cancel_button(object sender, RoutedEventArgs e)
        {
            number.Clear();
            password.Clear();
            Code.Clear();
            number.Focus();
        }

        private void UpdateCode_Click(object sender, RoutedEventArgs e)
        {
            Generate_code();
        }

        private void Code_IsEnabledChanged(object sender, KeyEventArgs e)
        {
            Timer timer = new Timer(10000);
            timer.Start();
            if (e.Key == Key.Enter)
            {
                if (Code.Text != code)
                {
                    MessageBox.Show("Неверный код. Для обновения кода нажмите на иконку", "ErrorCod");
                }
            }
        }

      
    }
}
