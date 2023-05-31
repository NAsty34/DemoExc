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

namespace st_Mihailova_telecom1_project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        st1_Mihailova_telecomEntities data_base = new st1_Mihailova_telecomEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataUser_DataGrid(object sender, RoutedEventArgs e)
        {
            var query = from user in data_base.Subscriber
                        orderby user.Name
                        select new
                        {
                            ФИО = user.Name + " " + user.FirstName + " " + user.LastName,
                            Абонентский_номер = user.NumberSubscriber,
                            Лицевой_счет = user.PersonalAccount,
                            Услуги = user.Services1.Name
                        };
            dataGrid_Client.ItemsSource = query.ToList();
        }
    }
}
