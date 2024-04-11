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
    /// Логика взаимодействия для WorkerWindow.xaml
    /// </summary>
    public partial class WorkerWindow : Window
    {
        public WorkerWindow()
        {
            InitializeComponent();
        }

        private void CategoriesButton_Click(object sender, RoutedEventArgs e)
        {
            CategoriesButton.IsEnabled = false;
            SubcategButton.IsEnabled = true;
            ProductButton.IsEnabled = true;
            WarehouseButton.IsEnabled = true;
            SuppliersButton.IsEnabled = true;
            PageFrame.Source = new Uri("CategoriesPage.xaml", UriKind.Relative);
        }

        private void SubcategButton_Click(object sender, RoutedEventArgs e)
        {
            CategoriesButton.IsEnabled = true;
            SubcategButton.IsEnabled = false;
            ProductButton.IsEnabled = true;
            WarehouseButton.IsEnabled = true;
            SuppliersButton.IsEnabled = true;
            PageFrame.Source = new Uri("SubcategPage.xaml", UriKind.Relative);
        }

        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            CategoriesButton.IsEnabled = true;
            SubcategButton.IsEnabled = true;
            ProductButton.IsEnabled = false;
            WarehouseButton.IsEnabled = true;
            SuppliersButton.IsEnabled = true;
            PageFrame.Source = new Uri("ProductPage.xaml", UriKind.Relative);
        }

        private void WarehouseButton_Click(object sender, RoutedEventArgs e)
        {
            CategoriesButton.IsEnabled = true;
            SubcategButton.IsEnabled = true;
            ProductButton.IsEnabled = true;
            WarehouseButton.IsEnabled = false;
            SuppliersButton.IsEnabled = true;
            PageFrame.Source = new Uri("WarehousePage.xaml", UriKind.Relative);
        }

        private void SuppliersButton_Click(object sender, RoutedEventArgs e)
        {
            CategoriesButton.IsEnabled = true;
            SubcategButton.IsEnabled = true;
            ProductButton.IsEnabled = true;
            WarehouseButton.IsEnabled = true;
            SuppliersButton.IsEnabled = false;
            PageFrame.Source = new Uri("SuppliersPage.xaml", UriKind.Relative);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }
    }
}
