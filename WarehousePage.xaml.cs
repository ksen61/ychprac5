using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
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
using System.Globalization;

namespace PetShop7
{
    /// <summary>
    /// Логика взаимодействия для WarehousePage.xaml
    /// </summary>
    public partial class WarehousePage : Page
    {
        WarehouseTableAdapter Warehouse = new WarehouseTableAdapter();
        ProductTableAdapter Product = new ProductTableAdapter();
        SuppliersTableAdapter Suppliers = new SuppliersTableAdapter();

        List<ComboItem> productItems;
        List<ComboItem> supplierItems;

        public WarehousePage()
        {
            InitializeComponent();
            WarehouseDataGrid.ItemsSource = Warehouse.GetData();

            productItems = new List<ComboItem>();
            foreach (var item in Product.GetData())
            {
                ComboItem comboItem = new ComboItem(item.ID, item.Name);
                productItems.Add(comboItem);
            }

            supplierItems = new List<ComboItem>();
            foreach (var item in Suppliers.GetData())
            {
                ComboItem comboItem = new ComboItem(item.ID, item.Name);
                supplierItems.Add(comboItem);
            }

            ProductCombo.ItemsSource = productItems;
            SuppliersCombo.ItemsSource = supplierItems;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WarehouseDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            WarehouseDataGrid.Columns[1].Header = "Товар";
            WarehouseDataGrid.Columns[2].Header = "Количсевто товара";
            WarehouseDataGrid.Columns[3].Header = "Дата доставки";
            WarehouseDataGrid.Columns[4].Header = "Поставщик";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ComboItem product = ProductCombo.SelectedItem as ComboItem;
            string quantitys = QuantityTextBox.Text;
            string delivery = DeliveryTextBox.Text;
            ComboItem supplier = SuppliersCombo.SelectedItem as ComboItem;

            if (product == null || quantitys == "" || delivery == "" || supplier == null)
            {
                MessageBox.Show("Все поля обязательны для заполнения");
                return;
            }

    

            if(!ValidateDateTime(delivery))
            {
                MessageBox.Show("Неверный формат");
                return;
            }

            double quantity;
            try
            {
                quantity = Convert.ToInt32(quantitys);
            }
            catch
            {
                MessageBox.Show("Количество товара должно быть числом");
                return;
            }
            if (quantity <= 0)
            {
                MessageBox.Show("Количество товара должно быть больше 0");
                return;
            }

            Warehouse.InsertQuery(product.id, (int)quantity, delivery, supplier.id);
            WarehouseDataGrid.ItemsSource = Warehouse.GetData();

            WarehouseDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            WarehouseDataGrid.Columns[1].Header = "Товар";
            WarehouseDataGrid.Columns[2].Header = "Количсевто товара";
            WarehouseDataGrid.Columns[3].Header = "Дата доставки";
            WarehouseDataGrid.Columns[4].Header = "Поставщик";
        }

        private void WarehouseDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView item = (WarehouseDataGrid.SelectedItem as DataRowView);
            if (item != null)
            {
                int product_id = (int)item.Row[1];
                int quantity = (int)item.Row[2];
                string delivery = item.Row[3].ToString();
                int supplier_id = (int)item.Row[4];
                ComboItem product = productItems.Find(elem => elem.id == product_id);
                ComboItem supplier = supplierItems.Find(elem => elem.id == supplier_id);

                ProductCombo.SelectedItem = product;
                QuantityTextBox.Text = quantity.ToString();
                DeliveryTextBox.Text = delivery;
                SuppliersCombo.SelectedItem = supplier;
                UpdateButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;
            }
            else
            {
                ProductCombo.SelectedItem = null;
                QuantityTextBox.Text = "";
                DeliveryTextBox.Text = "";
                SuppliersCombo.SelectedItem = null;
                UpdateButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }
        }

        void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView item = (WarehouseDataGrid.SelectedItem as DataRowView);
            if (item != null)
            {
                ComboItem product = ProductCombo.SelectedItem as ComboItem;
                string quantitys = QuantityTextBox.Text;
                string delivery = DeliveryTextBox.Text;
                ComboItem supplier = SuppliersCombo.SelectedItem as ComboItem;

                if (product == null || quantitys == "" || delivery == "" || supplier == null)
                {
                    MessageBox.Show("Все поля обязательны для заполнения");
                    return;
                }

                if (!ValidateDateTime(delivery))
                {
                    MessageBox.Show("Неверный формат");
                    return;
                }

                double quantity;
                try
                {
                    quantity = Convert.ToInt32(quantitys);
                }
                catch
                {
                    MessageBox.Show("Количество товара должно быть числом");
                    return;
                }
                if (quantity <= 0)
                {
                    MessageBox.Show("Количество товара должна быть больше 0");
                    return;
                }
                WarehouseDataGrid.Columns[0].Visibility = Visibility.Collapsed;
                WarehouseDataGrid.Columns[1].Header = "Товар";
                WarehouseDataGrid.Columns[2].Header = "Количсевто товара";
                WarehouseDataGrid.Columns[3].Header = "Дата доставки";
                WarehouseDataGrid.Columns[4].Header = "Поставщик";


                int warehouse_id = (int)item.Row[0];
                Warehouse.UpdateQuery(product.id, (int)quantity, delivery, supplier.id, warehouse_id);
                WarehouseDataGrid.ItemsSource = Warehouse.GetData();
            }
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView item = (WarehouseDataGrid.SelectedItem as DataRowView);
            if (item != null)
            {
                int product_id = (int)item.Row[0];
                Warehouse.DeleteQuery(product_id);
                WarehouseDataGrid.ItemsSource = Warehouse.GetData();
            }
            WarehouseDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            WarehouseDataGrid.Columns[1].Header = "Товар";
            WarehouseDataGrid.Columns[2].Header = "Количсевто товара";
            WarehouseDataGrid.Columns[3].Header = "Дата доставки";
            WarehouseDataGrid.Columns[4].Header = "Поставщик";
        }
        private bool ValidateDateTime(string data)
        {
            Regex regex = new Regex(@"^\d{2}.\d{2}.\d{4} \d{2}:\d{2}$");
            Match match = regex.Match(data);
            if (!match.Success)
            {
                return false;
            }

            if (DateTime.TryParseExact(data, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                DateTime minDate = new DateTime(1900, 1, 1);
                DateTime maxDate = new DateTime(2100, 12, 31, 23, 59, 59);
                if (result >= minDate && result <= maxDate)
                {
                    return true;
                }
            }
            

            return false;
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<WarehouseModel> ware = Converter.Load<List<WarehouseModel>>();
                foreach (var warehou in ware)
                {
                    Warehouse.InsertQuery(warehou.ProductID, warehou.Quantity, warehou.Delivery_Date, warehou.Suppliers_ID);

                }

                WarehouseDataGrid.ItemsSource = Warehouse.GetData();
            }
            catch
            {
                MessageBox.Show("Ошибка при загрузке JSON");
            }
            WarehouseDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            WarehouseDataGrid.Columns[1].Header = "Товар";
            WarehouseDataGrid.Columns[2].Header = "Количсевто товара";
            WarehouseDataGrid.Columns[3].Header = "Дата доставки";
            WarehouseDataGrid.Columns[4].Header = "Поставщик";
        }





    }
}
