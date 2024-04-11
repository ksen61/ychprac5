using PetShop7.PetShop77DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Xml.Linq;

namespace PetShop7
{
    /// <summary>
    /// Логика взаимодействия для RolesPage.xaml
    /// </summary>
    public partial class RolePage : Page
    {
        RoleTableAdapter Roles = new RoleTableAdapter();

        public RolePage()
        {
            InitializeComponent();
            RoleDataGrid.ItemsSource = Roles.GetData();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RoleDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            RoleDataGrid.Columns[1].Header = "Роль";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            if (name == "")
            {
                MessageBox.Show("Все поля обязательны для заполнения");
                return;
            }

            Roles.InsertQuery(name);
            RoleDataGrid.ItemsSource = Roles.GetData();
            RoleDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            RoleDataGrid.Columns[1].Header = "Роль";
        }

        private void RoleDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView item = (RoleDataGrid.SelectedItem as DataRowView);
            if (item != null)
            {
                string name = item.Row[1].ToString();
                NameTextBox.Text = name;
                UpdateButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;
            }
            else
            {
                NameTextBox.Text = "";
                UpdateButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            if (RoleDataGrid.SelectedItem == null || name == "")
            {
                MessageBox.Show("Все поля обязательны для заполнения");
                return;
            }
            int id = (int)(RoleDataGrid.SelectedItem as DataRowView).Row[0];
            Roles.UpdateQuery(name, id);
            RoleDataGrid.ItemsSource = Roles.GetData();
            RoleDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            RoleDataGrid.Columns[1].Header = "Роль";
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (RoleDataGrid.SelectedItem == null)
            {
                return;
            }
            int id = (int)(RoleDataGrid.SelectedItem as DataRowView).Row[0];
            Roles.DeleteQuery(id);
            RoleDataGrid.ItemsSource = Roles.GetData();
            RoleDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            RoleDataGrid.Columns[1].Header = "Роль";
        }
        
    }
}
