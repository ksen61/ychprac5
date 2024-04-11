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
using PetShop7.PetShop77DataSetTableAdapters;

namespace PetShop7
{
    /// <summary>
    /// Логика взаимодействия для CategoriesPage.xaml
    /// </summary>
    public partial class CategoriesPage : Page
    {
        CategoriesTableAdapter Categories = new CategoriesTableAdapter();

        public CategoriesPage()
        {
            InitializeComponent();
            CategoriesDataGrid.ItemsSource = Categories.GetData();            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CategoriesDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            CategoriesDataGrid.Columns[1].Header = "Название категории";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            if (name == "")
            {
                MessageBox.Show("Все поля обязательны для заполнения");

                return;
            }
            CategoriesDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            CategoriesDataGrid.Columns[1].Header = "Название категории";

            Categories.InsertQuery(name);
           CategoriesDataGrid.ItemsSource = Categories.GetData();
        }

        private void CategoriesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView item = (CategoriesDataGrid.SelectedItem as DataRowView);
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
            if (CategoriesDataGrid.SelectedItem == null || name == "")
            {
                MessageBox.Show("Все поля обязательны для заполнения");
                return;
            }
            CategoriesDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            CategoriesDataGrid.Columns[1].Header = "Название категории";
            int id = (int)(CategoriesDataGrid.SelectedItem as DataRowView).Row[0];
            Categories.UpdateQuery(name, id);
            CategoriesDataGrid.ItemsSource = Categories.GetData();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (CategoriesDataGrid.SelectedItem == null)
            {
                return;
            }
            CategoriesDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            CategoriesDataGrid.Columns[1].Header = "Название категории";
            int id = (int)(CategoriesDataGrid.SelectedItem as DataRowView).Row[0];
            Categories.DeleteQuery(id);
            CategoriesDataGrid.ItemsSource = Categories.GetData();
        }
    }
}
