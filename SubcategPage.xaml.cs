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
    /// Логика взаимодействия для SubcategPage.xaml
    /// </summary>
    public partial class SubcategPage : Page
    {
        SubcategoriesTableAdapter Subcategor = new SubcategoriesTableAdapter();
        CategoriesTableAdapter Categories = new CategoriesTableAdapter();

        List<ComboItem> categorItems;
        public SubcategPage()
        {
            InitializeComponent();
            SubcategDataGrid.ItemsSource = Subcategor.GetData();

            categorItems = new List<ComboItem>();
            foreach (var item in Categories.GetData())
            {
                ComboItem comboItem = new ComboItem(item.ID, item.Name);
                categorItems.Add(comboItem);
            }

            CategCombo.ItemsSource = categorItems;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SubcategDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            SubcategDataGrid.Columns[1].Header = "Подкатегория";
            SubcategDataGrid.Columns[2].Header = "Категория";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            ComboItem categor = CategCombo.SelectedItem as ComboItem;

            if (name == "" || categor == null)
            {
                MessageBox.Show("Все поля обязательны для заполнения");
                return;
            }

            Subcategor.InsertQuery(name, categor.id);
            SubcategDataGrid.ItemsSource = Subcategor.GetData();
            SubcategDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            SubcategDataGrid.Columns[1].Header = "Подкатегория";
            SubcategDataGrid.Columns[2].Header = "Категория";
        }

        private void SubcategDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView item = (SubcategDataGrid.SelectedItem as DataRowView);
            if (item != null)
            {
                string name = item.Row[1].ToString();
                int category_id = (int)item.Row[2];
                ComboItem category = categorItems.Find(elem => elem.id == category_id);

                NameTextBox.Text = name;
                CategCombo.SelectedItem = category;
                UpdateButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;
            }
            else
            {
                NameTextBox.Text = "";
                CategCombo.SelectedItem = null;
                UpdateButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            ComboItem category = CategCombo.SelectedItem as ComboItem;
            if (SubcategDataGrid.SelectedItem == null || name == "" || category == null)
            {
                MessageBox.Show("Все поля обязательны для заполнения");
                return;
            }
            int id = (int)(SubcategDataGrid.SelectedItem as DataRowView).Row[0];
            Subcategor.UpdateQuery(name, category.id, id);
            SubcategDataGrid.ItemsSource = Subcategor.GetData();
            SubcategDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            SubcategDataGrid.Columns[1].Header = "Подкатегория";
            SubcategDataGrid.Columns[2].Header = "Категория";
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SubcategDataGrid.SelectedItem == null)
            {
                return;
            }
            int id = (int)(SubcategDataGrid.SelectedItem as DataRowView).Row[0];
            Subcategor.DeleteQuery(id);
            SubcategDataGrid.ItemsSource = Subcategor.GetData();
            SubcategDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            SubcategDataGrid.Columns[1].Header = "Подкатегория";
            SubcategDataGrid.Columns[2].Header = "Категория";
        }
    }
}
