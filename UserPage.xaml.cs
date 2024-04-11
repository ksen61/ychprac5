using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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
using PetShop7.PetShop77DataSetTableAdapters;

namespace PetShop7
{
    /// <summary>
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        UserTableAdapter Users = new UserTableAdapter();
        EmployeeTableAdapter Employees = new EmployeeTableAdapter();

        List<ComboItem> employeeItems;

        public UserPage()
        {
            InitializeComponent();
            UserDataGrid.ItemsSource = Users.GetData();

            employeeItems = new List<ComboItem>();
            foreach (var item in Employees.GetData())
            {
                ComboItem comboItem = new ComboItem(item.ID, item.Lastname);
                employeeItems.Add(comboItem);
            }
            EmployeeCombo.ItemsSource = employeeItems;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UserDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            UserDataGrid.Columns[1].Header = "Логин";
            UserDataGrid.Columns[2].Header = "Пароль";
            UserDataGrid.Columns[3].Header = "Сотрудник";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = Hash(PasswordBox.Password);
            ComboItem employee = EmployeeCombo.SelectedItem as ComboItem;
            if (login == "" || password == "" || employee == null)
            {
                MessageBox.Show("Все поля обязательны для заполнения");
                return;
            }

            Users.InsertQuery(login, password, employee.id);
            UserDataGrid.ItemsSource = Users.GetData();
            UserDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            UserDataGrid.Columns[1].Header = "Логин";
            UserDataGrid.Columns[2].Header = "Пароль";
            UserDataGrid.Columns[3].Header = "Сотрудник";
        }

        private void UserDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView item = (UserDataGrid.SelectedItem as DataRowView);
            if (item != null)
            {
                string login = item.Row[1].ToString();
                string password = item.Row[2].ToString();
                int employee_id = (int)item.Row[3];
                ComboItem employee = employeeItems.Find(elem => elem.id == employee_id);

                LoginTextBox.Text = login;
                PasswordBox.Password = password;
                EmployeeCombo.SelectedItem = employee;
                UpdateButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;
            }
            else
            {
                LoginTextBox.Text = "";
                PasswordBox.Password = "";
                EmployeeCombo.SelectedItem = null;
                UpdateButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = Hash(PasswordBox.Password);
            ComboItem employee = EmployeeCombo.SelectedItem as ComboItem;
            if (UserDataGrid.SelectedItem == null || login == "" || password == "" || employee == null)
            {
                MessageBox.Show("Все поля обязательны для заполнения");
                return;
            }
            int id = (int)(UserDataGrid.SelectedItem as DataRowView).Row[0];
            Users.UpdateQuery(login, password, employee.id, id);
            UserDataGrid.ItemsSource = Users.GetData();
            UserDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            UserDataGrid.Columns[1].Header = "Логин";
            UserDataGrid.Columns[2].Header = "Пароль";
            UserDataGrid.Columns[3].Header = "Сотрудник";
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserDataGrid.SelectedItem == null)
            {
                return;
            }
            int id = (int)(UserDataGrid.SelectedItem as DataRowView).Row[0];
            Users.DeleteQuery(id);
            UserDataGrid.ItemsSource = Users.GetData();
            UserDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            UserDataGrid.Columns[1].Header = "Логин";
            UserDataGrid.Columns[2].Header = "Пароль";
            UserDataGrid.Columns[3].Header = "Сотрудник";
        }
        private static string Hash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                string sb = "";
                for (int i = 0; i < hash.Length/4; i++)
                {
                    sb += hash[i].ToString("x2");
                }
                return sb;
            }
        }
    }
}
