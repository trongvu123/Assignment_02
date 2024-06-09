using DataModels1;
using RepositoryPattern1;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace MiniHotelManagement
{
    public partial class MainWindow : Window
    {
        private readonly CustomerRepository _customerRepository;
        private ObservableCollection<Customer> _customers;

        public MainWindow()
        {
            _customerRepository = new CustomerRepository();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadData();
        }

        public void loadData()
        {
            _customers = new ObservableCollection<Customer>(_customerRepository.GetAllCustomers());
            dgData.ItemsSource = _customers;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer customer1 = new Customer
                {
                    CustomerID = _customers.Any() ? _customers.Max(c => c.CustomerID) + 1 : 1,
                    CustomerFullName = txtFullName.Text,
                    Telephone = txtPhone.Text,
                    EmailAddress = txtEmail.Text,
                    CustomerBirthday = txtDob.Text,
                    CustomerStatus = 0,
                    Password = txtPassword.Text
                };
                _customerRepository.AddCustomer(customer1);
                _customers.Add(customer1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtCustomerID.Text.Length > 0)
                {
                    int id = int.Parse(txtCustomerID.Text);
                    Customer customer = _customers.FirstOrDefault(c => c.CustomerID == id);
                    if (customer != null)
                    {
                        customer.CustomerFullName = txtFullName.Text;
                        customer.Telephone = txtPhone.Text;
                        customer.EmailAddress = txtEmail.Text;
                        customer.CustomerBirthday = txtDob.Text;
                        customer.CustomerStatus = 0;
                        customer.Password = txtPassword.Text;
                        _customerRepository.UpdateCustomer(customer);
                        dgData.Items.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtCustomerID.Text.Length > 0)
                {
                    int id = int.Parse(txtCustomerID.Text);
                    Customer customer = _customers.FirstOrDefault(c => c.CustomerID == id);
                    if (customer != null)
                    {
                        _customers.Remove(customer);
                        _customerRepository.DeleteCustomer(id);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem is Customer customer)
            {
                txtCustomerID.Text = customer.CustomerID.ToString();
                txtFullName.Text = customer.CustomerFullName;
                txtPhone.Text = customer.Telephone;
                txtEmail.Text = customer.EmailAddress;
                txtDob.Text = customer.CustomerBirthday;
                txtPassword.Text = customer.Password;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            RoomManagerWindow roomManager = new RoomManagerWindow();
            roomManager.Show();
        }
    }
}
