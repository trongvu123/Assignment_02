﻿using HotelManagement;
using HotelManagement.Models;
using RepositoryPattern1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static MiniHotelManagement.Login_Window;

namespace MiniHotelManagement
{
    /// <summary>
    /// Interaction logic for UserProfile.xaml
    /// </summary>
    public partial class UserProfile : Window
    {
        private readonly CustomerRepository _customerRepository;
        private ObservableCollection<Customer> _customers;
        public UserProfile(CustomerRepository customerRepository)
        {
            InitializeComponent();
            _customerRepository = customerRepository;
            _customers = new ObservableCollection<Customer>();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadUserData();
        }
        public void LoadUserData()
        {
            if (CurrentUser.LoggedInUser != null)
            {
                txtCustomerID.Text = CurrentUser.LoggedInUser.CustomerId.ToString();
                txtFullName.Text = CurrentUser.LoggedInUser.CustomerFullName;
                txtPhone.Text = CurrentUser.LoggedInUser.Telephone;
                txtEmail.Text = CurrentUser.LoggedInUser.EmailAddress;
                txtDob.Text = CurrentUser.LoggedInUser.CustomerBirthday.ToString();
                txtPassword.Text = CurrentUser.LoggedInUser.Password;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtCustomerID.Text.Length > 0)
                {
                    int id = int.Parse(txtCustomerID.Text);
                    var customer = _customerRepository.GetAllCustomers().FirstOrDefault(c => c.CustomerId == id);
                    if (customer != null)
                    {
                        customer.CustomerFullName = txtFullName.Text;
                        customer.Telephone = txtPhone.Text;
                        customer.EmailAddress = txtEmail.Text;
                        customer.CustomerBirthday = DateOnly.Parse(txtDob.Text);
                        customer.CustomerStatus = 1;
                        customer.Password = txtPassword.Text;
                        _customerRepository.UpdateCustomer(customer);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Update success!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            UserBookingWindow roomManager = (App.Current as App)?.GetUserBookingWindow();
            roomManager.Show();
        }
    }
}
