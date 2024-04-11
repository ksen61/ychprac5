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
    /// Логика взаимодействия для FilialsPage.xaml
    /// </summary>
    public partial class WorkingHoursPage : Page
    {
        WorkingHoursTableAdapter WorkingHours = new WorkingHoursTableAdapter();

        public WorkingHoursPage()
        {
            InitializeComponent();
            WorkingHoursDataGrid.ItemsSource = WorkingHours.GetData();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WorkingHoursDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            WorkingHoursDataGrid.Columns[1].Header = "Время работы";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string worktime = WorkTimeTextBox.Text;
            if (worktime == "")
            {
                MessageBox.Show("Все поля обязательны для заполнения");
                return;
            }
            if (!ValidateVremya(worktime))
            {
                MessageBox.Show("Неверный формат");
                return;
            }
            WorkingHours.InsertQuery(worktime);
            WorkingHoursDataGrid.ItemsSource = WorkingHours.GetData();
            WorkingHoursDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            WorkingHoursDataGrid.Columns[1].Header = "Время работы";
        }

        private void WorkingHoursDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView item = (WorkingHoursDataGrid.SelectedItem as DataRowView);
            if (item != null)
            {
                string worktime = item.Row[1].ToString();
                WorkTimeTextBox.Text = worktime;
                UpdateButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;
            }
            else
            {
                WorkTimeTextBox.Text = "";
                UpdateButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string worktime = WorkTimeTextBox.Text;
            if (WorkingHoursDataGrid.SelectedItem == null || worktime == "")
            {
                MessageBox.Show("Все поля обязательны для заполнения");
                return;
            }

            if (!ValidateVremya(worktime))
            {
                MessageBox.Show("Неверный формат");
                return;
            }

            int id = (int)(WorkingHoursDataGrid.SelectedItem as DataRowView).Row[0];
            WorkingHours.UpdateQuery(worktime, id);
            WorkingHoursDataGrid.ItemsSource = WorkingHours.GetData();
            WorkingHoursDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            WorkingHoursDataGrid.Columns[1].Header = "Время работы";
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (WorkingHoursDataGrid.SelectedItem == null)
            {
                return;
            }
            int id = (int)(WorkingHoursDataGrid.SelectedItem as DataRowView).Row[0];
            WorkingHours.DeleteQuery(id);
            WorkingHoursDataGrid.ItemsSource = WorkingHours.GetData();
            WorkingHoursDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            WorkingHoursDataGrid.Columns[1].Header = "Время работы";
        }

        private bool ValidateVremya(string vremya)
        {
            Regex regex = new Regex(@"^(0[0-9]|1[0-9]|2[0-3]):([0-5][0-9])-(0[0-9]|1[0-9]|2[0-3]):([0-5][0-9])$");
            MatchCollection match = regex.Matches(vremya);
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