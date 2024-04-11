using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для SupportsPage.xaml
    /// </summary>
    public partial class SuppliersPage : Page
    {
        SuppliersTableAdapter Suppliers = new SuppliersTableAdapter();

        public SuppliersPage()
        {
            InitializeComponent();
            SuppliersDataGrid.ItemsSource = Suppliers.GetData();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SuppliersDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            SuppliersDataGrid.Columns[1].Header = "Поставщик";
            SuppliersDataGrid.Columns[2].Header = "Номер телефона";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string phone = PhoneTextBox.Text;
            if (name == "" || phone == "")
            {
                MessageBox.Show("Все поля обязательны для заполнения");
                return;
            }
            if (!Validatetelefon(phone))
            {
                MessageBox.Show("неверный формат");
                return;
            }
            Suppliers.InsertQuery(name, phone);
            SuppliersDataGrid.ItemsSource = Suppliers.GetData();
            SuppliersDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            SuppliersDataGrid.Columns[1].Header = "Поставщик";
            SuppliersDataGrid.Columns[2].Header = "Номер телефона";
        }

        private void SuppliersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView item = (SuppliersDataGrid.SelectedItem as DataRowView);
            if (item != null)
            {
                string name = item.Row[1].ToString();
                string phone = item.Row[2].ToString();

                NameTextBox.Text = name;
                PhoneTextBox.Text = phone;
                UpdateButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;
            }
            else
            {
                NameTextBox.Text = "";
                PhoneTextBox.Text = "";
                UpdateButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string phone = PhoneTextBox.Text;
            if (SuppliersDataGrid.SelectedItem == null || name == "" || phone == "")
            {
                MessageBox.Show("Все поля обязательны для заполнения");
                return;
            }
            if (!Validatetelefon(phone))
            {
                MessageBox.Show("неверный формат");
                return;
            }
            int id = (int)(SuppliersDataGrid.SelectedItem as DataRowView).Row[0];
            Suppliers.UpdateQuery(name, phone, id);
            SuppliersDataGrid.ItemsSource = Suppliers.GetData();
            SuppliersDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            SuppliersDataGrid.Columns[1].Header = "Поставщик";
            SuppliersDataGrid.Columns[2].Header = "Номер телефона";
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SuppliersDataGrid.SelectedItem == null)
            {
                return;
            }
            int id = (int)(SuppliersDataGrid.SelectedItem as DataRowView).Row[0];
            Suppliers.DeleteQuery(id);
            SuppliersDataGrid.ItemsSource = Suppliers.GetData();
            SuppliersDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            SuppliersDataGrid.Columns[1].Header = "Поставщик";
            SuppliersDataGrid.Columns[2].Header = "Номер телефона";
        }
        private bool Validatetelefon(string telefon)
        {
            Regex regex = new Regex(@"^8\(\d\d\d\)\d\d\d-\d\d-\d\d$");
            MatchCollection match = regex.Matches(telefon);
            if (match.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<SuppliersModel> suppli = Converter.Load<List<SuppliersModel>>();
                foreach (var suppliers in suppli)
                {
                    Suppliers.InsertQuery(suppliers.name, suppliers.phone);

                }

                SuppliersDataGrid.ItemsSource = Suppliers.GetData();
            }
            catch
            {
                MessageBox.Show("Ошибка при загрузке JSON");
            }
            SuppliersDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            SuppliersDataGrid.Columns[1].Header = "Поставщик";
            SuppliersDataGrid.Columns[2].Header = "Номер телефона";
        }
    }
}
