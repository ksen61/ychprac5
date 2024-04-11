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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace PetShop7
{
    /// <summary>
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        EmployeeTableAdapter Employees = new EmployeeTableAdapter();
        WorkingHoursTableAdapter WorkingH = new WorkingHoursTableAdapter();
        RoleTableAdapter Roles = new RoleTableAdapter();
        ProductTableAdapter Products = new ProductTableAdapter();
        CheckTableAdapter Checks = new CheckTableAdapter();

        List<ComboItem> workingItems;
        List<ComboItem> roleItems;
        List<ComboItem> productItems;
        List<ComboItem> checkItems;


        public EmployeePage()
        {
            InitializeComponent();
            EmployeeDataGrid.ItemsSource = Employees.GetData();

            workingItems = new List<ComboItem>();
            foreach (var item in WorkingH.GetData())
            {
                ComboItem comboItem = new ComboItem(item.ID, item.Worktime);
                workingItems.Add(comboItem);
            }

            roleItems = new List<ComboItem>();
            foreach (var item in Roles.GetData())
            {
                ComboItem comboItem = new ComboItem(item.ID, item.RoleName);
                roleItems.Add(comboItem);
            }

            productItems = new List<ComboItem>();
            foreach (var item in Products.GetData())
            {
                ComboItem comboItem = new ComboItem(item.ID, item.Name);
                productItems.Add(comboItem);
            }

            checkItems = new List<ComboItem>();
            foreach (var item in Checks.GetData())
            {
                string dateString = item.Date.ToString();
                ComboItem comboItem = new ComboItem(item.ID, dateString);
                checkItems.Add(comboItem);
            }

            WorkingHoursCombo.ItemsSource = workingItems;
            RoleCombo.ItemsSource = roleItems;
            ProductCombo.ItemsSource = productItems;
            CheckCombo.ItemsSource = checkItems;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EmployeeDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            EmployeeDataGrid.Columns[1].Header = "Фамилия сотрудника";
            EmployeeDataGrid.Columns[2].Header = "Имя сотрудника";
            EmployeeDataGrid.Columns[3].Header = "Отчество сотрудника";
            EmployeeDataGrid.Columns[4].Header = "Время работы";
            EmployeeDataGrid.Columns[5].Header = "Роль";
            EmployeeDataGrid.Columns[6].Header = "Товар";
            EmployeeDataGrid.Columns[7].Header = "Чек";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string lastname = LastnameTextBox.Text;
            string name = NameTextBox.Text;
            string middlename = MiddlenameTextBox.Text;
            ComboItem working = WorkingHoursCombo.SelectedItem as ComboItem;
            ComboItem role = RoleCombo.SelectedItem as ComboItem;
            ComboItem product = ProductCombo.SelectedItem as ComboItem;
            ComboItem check = CheckCombo.SelectedItem as ComboItem;

            if (lastname == ""  || name == "" || middlename == "" || working == null || role == null || product == null || check == null)
        {
                MessageBox.Show("Все поля обязательны для заполнения");
                return;
            }
            EmployeeDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            EmployeeDataGrid.Columns[1].Header = "Фамилия сотрудника";
            EmployeeDataGrid.Columns[2].Header = "Имя сотрудника";
            EmployeeDataGrid.Columns[3].Header = "Отчество сотрудника";
            EmployeeDataGrid.Columns[4].Header = "Время работы";
            EmployeeDataGrid.Columns[5].Header = "Роль";
            EmployeeDataGrid.Columns[6].Header = "Товар";
            EmployeeDataGrid.Columns[7].Header = "Чек";

            Employees.InsertQuery(lastname, name, middlename, working.id, role.id, product.id, check.id);
            EmployeeDataGrid.ItemsSource = Employees.GetData();
        }

        private void EmployeeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView item = (EmployeeDataGrid.SelectedItem as DataRowView);
            if (item != null)
            {
                string lastname = item.Row[1].ToString();
                string name = item.Row[2].ToString();
                string middlename = item.Row[3].ToString();

                int working_id = Convert.ToInt32(item.Row[4]);
                int role_id = Convert.ToInt32(item.Row[5]);
                int product_id = Convert.ToInt32(item.Row[6]);
                int check_id = Convert.ToInt32(item.Row[7]);

                ComboItem working = workingItems.Find(elem => elem.id == working_id);
                ComboItem role = roleItems.Find(elem => elem.id == role_id);
                ComboItem product = productItems.Find(elem => elem.id == product_id);
                ComboItem check = checkItems.Find(elem => elem.id == check_id);

                LastnameTextBox.Text = lastname;
                NameTextBox.Text = name;
                MiddlenameTextBox.Text = middlename;

                if (working != null)
                {
                    WorkingHoursCombo.SelectedItem = working;
                }
                if (role != null)
                {
                    RoleCombo.SelectedItem = role;
                }
                if (product != null)
                {
                    ProductCombo.SelectedItem = product;
                }
                if (check != null)
                {
                    CheckCombo.SelectedItem = check;
                }

                UpdateButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;
            }
            else
            {
                LastnameTextBox.Text = "";
                NameTextBox.Text = "";
                MiddlenameTextBox.Text = "";
                WorkingHoursCombo.SelectedItem = null;
                RoleCombo.SelectedItem = null;
                ProductCombo.SelectedItem = null;
                CheckCombo.SelectedItem = null;
                UpdateButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }
        }


        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string lastname = LastnameTextBox.Text;
            string name = NameTextBox.Text;
            string middlename = MiddlenameTextBox.Text;
            ComboItem working = WorkingHoursCombo.SelectedItem as ComboItem;
            ComboItem role = RoleCombo.SelectedItem as ComboItem;
            ComboItem product = ProductCombo.SelectedItem as ComboItem;
            ComboItem check = CheckCombo.SelectedItem as ComboItem;
            if (lastname == "" || name == "" || middlename == "" || working == null || role == null || product == null || check == null)
            {
                MessageBox.Show("Все поля обязательны для заполнения");
                return;
            }
            EmployeeDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            EmployeeDataGrid.Columns[1].Header = "Фамилия сотрудника";
            EmployeeDataGrid.Columns[2].Header = "Имя сотрудника";
            EmployeeDataGrid.Columns[3].Header = "Отчество сотрудника";
            EmployeeDataGrid.Columns[4].Header = "Время работы";
            EmployeeDataGrid.Columns[5].Header = "Роль";
            EmployeeDataGrid.Columns[6].Header = "Товар";
            EmployeeDataGrid.Columns[7].Header = "Чек";

            int id = (int)(EmployeeDataGrid.SelectedItem as DataRowView).Row[0];
            Employees.UpdateQuery1(lastname, name, middlename, working.id, role.id, product.id, check.id, id);
            EmployeeDataGrid.ItemsSource = Employees.GetData();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeDataGrid.SelectedItem == null)
            {
                return;
            }
            EmployeeDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            EmployeeDataGrid.Columns[1].Header = "Фамилия сотрудника";
            EmployeeDataGrid.Columns[2].Header = "Имя сотрудника";
            EmployeeDataGrid.Columns[3].Header = "Отчество сотрудника";
            EmployeeDataGrid.Columns[4].Header = "Время работы";
            EmployeeDataGrid.Columns[5].Header = "Роль";
            EmployeeDataGrid.Columns[6].Header = "Товар";
            EmployeeDataGrid.Columns[7].Header = "Чек";
            int id = (int)(EmployeeDataGrid.SelectedItem as DataRowView).Row[0];
            Employees.DeleteQuery(id);
            EmployeeDataGrid.ItemsSource = Employees.GetData();
        }
    }
}
