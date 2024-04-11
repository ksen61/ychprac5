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

namespace PetShop7
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void RolesButton_Click(object sender, RoutedEventArgs e)
        {
            WorkingHoursButton.IsEnabled = true;
            SupportsButton.IsEnabled = true;
            RolesButton.IsEnabled = false;
            EmployeesButton.IsEnabled = true;
            UsersButton.IsEnabled = true;
            PageFrame.Source = new Uri("RolePage.xaml", UriKind.Relative);
        }

        private void EmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            WorkingHoursButton.IsEnabled = true;
            SupportsButton.IsEnabled = true;
            RolesButton.IsEnabled = true;
            EmployeesButton.IsEnabled = false;
            UsersButton.IsEnabled = true;
            PageFrame.Source = new Uri("EmployeePage.xaml", UriKind.Relative);
        }

        private void UsersButton_Click(object sender, RoutedEventArgs e)
        {
            WorkingHoursButton.IsEnabled = true;
            SupportsButton.IsEnabled = true;
            RolesButton.IsEnabled = true;
            EmployeesButton.IsEnabled = true;
            UsersButton.IsEnabled = false;
            PageFrame.Source = new Uri("UserPage.xaml", UriKind.Relative);
        }

        private void WorkingHoursButton_Click(object sender, RoutedEventArgs e)
        {
            WorkingHoursButton.IsEnabled = false;
            SupportsButton.IsEnabled = true;
            RolesButton.IsEnabled = true;
            EmployeesButton.IsEnabled = true;
            UsersButton.IsEnabled = true;
            PageFrame.Source = new Uri("WorkingHoursPage.xaml", UriKind.Relative);
        }

        private void SupportsButton_Click(object sender, RoutedEventArgs e)
        {
            WorkingHoursButton.IsEnabled = true;
            SupportsButton.IsEnabled = false;
            RolesButton.IsEnabled = true;
            EmployeesButton.IsEnabled = true;
            UsersButton.IsEnabled = true;
            PageFrame.Source = new Uri("SupportPage.xaml", UriKind.Relative);
        }


        private void NazadButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }
    }
}
