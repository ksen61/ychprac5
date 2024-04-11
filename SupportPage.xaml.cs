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
    public partial class SupportPage : Page
    {
        SupportTableAdapter Supports = new SupportTableAdapter();
        WorkingHoursTableAdapter WorkingHours = new WorkingHoursTableAdapter();

        List<ComboItem> workingItems;

        public SupportPage()
        {
            InitializeComponent();
            SupportDataGrid.ItemsSource = Supports.GetData();

            workingItems = new List<ComboItem>();
            foreach (var item in WorkingHours.GetData())
            {
                ComboItem comboItem = new ComboItem(item.ID, item.Worktime);
                workingItems.Add(comboItem);
            }
            WorkingHoursCombo.ItemsSource = workingItems;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SupportDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            SupportDataGrid.Columns[1].Header = "Время работы";
            SupportDataGrid.Columns[2].Header = "Номер телефона";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string phone = PhoneTextBox.Text;
            ComboItem working = WorkingHoursCombo.SelectedItem as ComboItem;
            if (working == null || phone == "")
            {
                MessageBox.Show("Все поля обязательны для заполнения");
                return;
            }
            if (!Validatetelefon(phone))
            {
                MessageBox.Show("Неверный формат");
                return;
            }

            Supports.InsertQuery(working.id, phone);
            SupportDataGrid.ItemsSource = Supports.GetData();
            SupportDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            SupportDataGrid.Columns[1].Header = "Время работы";
            SupportDataGrid.Columns[2].Header = "Номер телефона";
        }

        private void SupportDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView item = (SupportDataGrid.SelectedItem as DataRowView);
            if (item != null)
            {
                int working_id = (int)item.Row[1];
                string phone = item.Row[2].ToString();
                ComboItem working = workingItems.Find(elem => elem.id == working_id);

                PhoneTextBox.Text = phone;
                WorkingHoursCombo.SelectedItem = working;
                UpdateButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;
            }
            else
            {
                PhoneTextBox.Text = "";
                WorkingHoursCombo.SelectedItem = null;
                UpdateButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string phone = PhoneTextBox.Text;
            ComboItem working = WorkingHoursCombo.SelectedItem as ComboItem;
            if (SupportDataGrid.SelectedItem == null || phone == "" || working == null)
            {
                MessageBox.Show("Все поля обязательны для заполнения");
                return;
            }
            if (!Validatetelefon(phone))
            {
                MessageBox.Show("Неверный формат");
                return;
            }
            int id = (int)(SupportDataGrid.SelectedItem as DataRowView).Row[0];
            Supports.UpdateQuery(working.id, phone, id);
            SupportDataGrid.ItemsSource = Supports.GetData();
            SupportDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            SupportDataGrid.Columns[1].Header = "Время работы";
            SupportDataGrid.Columns[2].Header = "Номер телефона";
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SupportDataGrid.SelectedItem == null)
            {
                return;
            }
            int id = (int)(SupportDataGrid.SelectedItem as DataRowView).Row[0];
            Supports.DeleteQuery(id);
            SupportDataGrid.ItemsSource = Supports.GetData();
            SupportDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            SupportDataGrid.Columns[1].Header = "Время работы";
            SupportDataGrid.Columns[2].Header = "Номер телефона";
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
    }
}
