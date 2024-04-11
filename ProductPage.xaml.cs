using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        ProductTableAdapter Products = new ProductTableAdapter();
        SubcategoriesTableAdapter Subcateg = new SubcategoriesTableAdapter();

        List<ComboItem> subcategItems;

        public ProductPage()
        {
            InitializeComponent();
            ProductDataGrid.ItemsSource = Products.GetData();

            subcategItems = new List<ComboItem>();
            foreach (var item in Subcateg.GetData())
            {
                ComboItem comboItem = new ComboItem(item.ID, item.Name);
                subcategItems.Add(comboItem);
            }

            SubcategCombo.ItemsSource = subcategItems;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ProductDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            ProductDataGrid.Columns[1].Header = "Название товара";
            ProductDataGrid.Columns[2].Header = "Описание товара";
            ProductDataGrid.Columns[3].Header = "Подкатегория";
            ProductDataGrid.Columns[4].Header = "Дата изготовления";
            ProductDataGrid.Columns[5].Header = "Срок годности";
            ProductDataGrid.Columns[6].Header = "Цена(руб.)";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string description = DescriptionTextBox.Text;
            ComboItem subcategor = SubcategCombo.SelectedItem as ComboItem;
            string dataofmanufacture = DataofManufactireTextBox.Text;
            string shelflife = ShelfLifeTextBox.Text;
            string prices = PriceTextBox.Text;

            if (name == "" || description == "" || subcategor == null ||  prices == "")
    {
                MessageBox.Show("Все поля кроме 'Срок годности' обязательны для заполнения");
                return;
            }

            DateTime dataOfManufacture;
            DateTime? shelfLifeDate = null;

            if (!DateTime.TryParse(dataofmanufacture, out dataOfManufacture))
            {
                MessageBox.Show("Неверная дата изготовления");
                return;
            }

            if (!string.IsNullOrEmpty(shelflife))
            {
                if (!DateTime.TryParse(shelflife, out DateTime parsedShelfLife))
                {
                    MessageBox.Show("Неверный срок годности");
                    return;
                }

                if (parsedShelfLife < dataOfManufacture)
                {
                    MessageBox.Show("Срок годности не может быть ранее даты изготовления");
                    return;
                }

                shelfLifeDate = parsedShelfLife;
            }

            double price;
            try
            {
                price = Convert.ToSingle(prices);
            }
            catch
            {
                MessageBox.Show("Цена должна быть числом");
                return;
            }
            if (price <= 0)
            {
                MessageBox.Show("Цена должна быть больше 0");
                return;
            }
            ProductDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            ProductDataGrid.Columns[1].Header = "Название товара";
            ProductDataGrid.Columns[2].Header = "Описание товара";
            ProductDataGrid.Columns[3].Header = "Подкатегория";
            ProductDataGrid.Columns[4].Header = "Дата изготовления";
            ProductDataGrid.Columns[5].Header = "Срок годности";
            ProductDataGrid.Columns[6].Header = "Цена(руб.)";

            Products.InsertQuery(name, description, subcategor.id, dataOfManufacture, shelfLifeDate, price);
            ProductDataGrid.ItemsSource = Products.GetData();
        }

        private void ProductDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView item = (ProductDataGrid.SelectedItem as DataRowView);
            if (item != null)
            {
                string name = item.Row[1].ToString();
                string description = item.Row[2].ToString();
                int subcategor_id = (int)item.Row[3];
                string dataofmanufacture = item.Row[4].ToString();
                string shelflife = item.Row[5].ToString();
                double price = (double)item.Row[6];
                ComboItem subcateg = subcategItems.Find(elem => elem.id == subcategor_id);

                NameTextBox.Text = name;
                DescriptionTextBox.Text = description;
                SubcategCombo.SelectedItem = subcateg;
                DataofManufactireTextBox.Text = dataofmanufacture;
                ShelfLifeTextBox.Text = shelflife;
                PriceTextBox.Text = price.ToString();
                UpdateButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;
            }
            else
            {
                NameTextBox.Text = "";
                DescriptionTextBox.Text = "";
                SubcategCombo.SelectedItem = null;
                DataofManufactireTextBox.Text = "";
                ShelfLifeTextBox.Text = "";
                PriceTextBox.Text = "";
                UpdateButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }
        }

        void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView item = (ProductDataGrid.SelectedItem as DataRowView);
            if (item != null)
            {
                string name = NameTextBox.Text;
                string description = DescriptionTextBox.Text;
                ComboItem subcategor = SubcategCombo.SelectedItem as ComboItem;
                string dataofmanufacture = DataofManufactireTextBox.Text;
                string shelflife = ShelfLifeTextBox.Text;
                string prices = PriceTextBox.Text;

                if (name == "" || description == "" || subcategor == null || prices == "")
                {
                    MessageBox.Show("Все поля кроме 'Срок годности' обязательны для заполнения");
                    return;
                }

                DateTime dataOfManufacture;
                DateTime? shelfLifeDate = null;

                if (!DateTime.TryParse(dataofmanufacture, out dataOfManufacture))
                {
                    MessageBox.Show("Неверная дата изготовления");
                    return;
                }

                if (!string.IsNullOrEmpty(shelflife))
                {
                    if (!DateTime.TryParse(shelflife, out DateTime parsedShelfLife))
                    {
                        MessageBox.Show("Неверный срок годности");
                        return;
                    }

                    if (parsedShelfLife < dataOfManufacture)
                    {
                        MessageBox.Show("Срок годности не может быть ранее даты изготовления");
                        return;
                    }

                    shelfLifeDate = parsedShelfLife;
                }

                double price;
                try
                {
                    price = Convert.ToDouble(prices);
                }
                catch
                {
                    MessageBox.Show("Цена должна быть числом");
                    return;
                }
                if (price <= 0)
                {
                    MessageBox.Show("Цена должна быть больше 0");
                    return;
                }
                ProductDataGrid.Columns[0].Visibility = Visibility.Collapsed;
                ProductDataGrid.Columns[1].Header = "Название товара";
                ProductDataGrid.Columns[2].Header = "Описание товара";
                ProductDataGrid.Columns[3].Header = "Подкатегория";
                ProductDataGrid.Columns[4].Header = "Дата изготовления";
                ProductDataGrid.Columns[5].Header = "Срок годности";
                ProductDataGrid.Columns[6].Header = "Цена(руб.)";
                int product_id = (int)item.Row[0];
                Products.UpdateQuery(name, description, subcategor.id, dataOfManufacture, shelfLifeDate, price, product_id);
                ProductDataGrid.ItemsSource = Products.GetData();
            }
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView item = (ProductDataGrid.SelectedItem as DataRowView);
            if (item != null)
            {
                int product_id = (int)item.Row[0];
                Products.DeleteQuery(product_id);
                ProductDataGrid.ItemsSource = Products.GetData();
            }
            ProductDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            ProductDataGrid.Columns[1].Header = "Название товара";
            ProductDataGrid.Columns[2].Header = "Описание товара";
            ProductDataGrid.Columns[3].Header = "Подкатегория";
            ProductDataGrid.Columns[4].Header = "Дата изготовления";
            ProductDataGrid.Columns[5].Header = "Срок годности";
            ProductDataGrid.Columns[6].Header = "Цена(руб.)";
        }
        
    }
}
