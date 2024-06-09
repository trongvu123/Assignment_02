using DataModels1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern1
{
    public class CustomerRepository : ICustomerRepository
    {
        private static  ObservableCollection<Customer> Customers = new ObservableCollection<Customer>
        {
              new Customer { CustomerID = 1, CustomerFullName = "John Doe", Telephone = "123456789", EmailAddress = "john@example.com", CustomerBirthday = "12/05/2001", CustomerStatus = 1, Password = "password123" },
              new Customer { CustomerID = 2, CustomerFullName = "Jane Smith", Telephone = "987654321", EmailAddress = "jane@example.com", CustomerBirthday = "12/05/2005", CustomerStatus = 1, Password = "qwerty456" },
              new Customer { CustomerID = 2, CustomerFullName = "Jane Smith2", Telephone = "987654321", EmailAddress = "admin@FUMiniHotelSystem.com", CustomerBirthday = "12/05/2005", CustomerStatus = 1, Password = "@@abc123@@" }

        };
        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        public void DeleteCustomer(int customerId)
        {
            var customer = Customers.FirstOrDefault(c=>c.CustomerID == customerId);
            Customers.Remove(customer);
        }

        public ObservableCollection<Customer> GetAllCustomers()
        {
            return Customers;
        }

        public Customer GetCustomerById(int customerId)
        {
            var customer = Customers.FirstOrDefault(c => c.CustomerID == customerId);
            return customer;
        }

        public Customer GetCustomerByUsernameAndPassword(string username, string password)
        {
            return Customers.FirstOrDefault(c => c.EmailAddress == username && c.Password == password);
        }

        public void UpdateCustomer(Customer customer)
        {
            var existingCustomer = GetCustomerById(customer.CustomerID);
            if (existingCustomer != null)
            {
                existingCustomer.CustomerID = customer.CustomerID;
                existingCustomer.CustomerFullName = customer.CustomerFullName;
                existingCustomer.Telephone = customer.Telephone;
                existingCustomer.EmailAddress = customer.EmailAddress;
                existingCustomer.CustomerBirthday = customer.CustomerBirthday;
                existingCustomer.CustomerStatus = customer.CustomerStatus;
                existingCustomer.CustomerStatus = 0;
                existingCustomer.Password = customer.Password;
            }
        }
    }
}
