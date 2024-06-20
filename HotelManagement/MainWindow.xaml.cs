using HotelManagement;
using HotelManagement.Models;
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

        public MainWindow(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
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
                    CustomerFullName = txtFullName.Text,
                    Telephone = txtPhone.Text,
                    EmailAddress = txtEmail.Text,
                    CustomerBirthday = DateOnly.Parse(txtDob.Text),
                    CustomerStatus = 1,
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
                    Customer customer = _customerRepository.GetCustomerById(id);
                    if (customer != null)
                    {
                        customer.CustomerFullName = txtFullName.Text;
                        customer.Telephone = txtPhone.Text;
                        customer.EmailAddress = txtEmail.Text;
                        customer.CustomerBirthday = DateOnly.Parse(txtDob.Text);
                        customer.CustomerStatus = 1;
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
                    Customer customer = _customers.FirstOrDefault(c => c.CustomerId == id);
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
                txtCustomerID.Text = customer.CustomerId.ToString();
                txtFullName.Text = customer.CustomerFullName;
                txtPhone.Text = customer.Telephone;
                txtEmail.Text = customer.EmailAddress;
                txtDob.Text = customer.CustomerBirthday.ToString();
                txtPassword.Text = customer.Password;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            RoomManagerWindow roomManager = (App.Current as App)?.GetRoomInfoWindow();
            roomManager.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ReportWindow roomManager = (App.Current as App)?.GetReportWindow();
            roomManager.Show();
        }
    }
}
