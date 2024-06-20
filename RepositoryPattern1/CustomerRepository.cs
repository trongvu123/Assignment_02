using HotelManagement.Models;
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
        private readonly FuminiHotelManagementContext _context;

        public CustomerRepository(FuminiHotelManagementContext context)
        {
            _context = context;
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(int customerId)
        {
            var customer = _context.Customers.FirstOrDefault(c=>c.CustomerId == customerId);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public ObservableCollection<Customer> GetAllCustomers()
        {
            return new ObservableCollection<Customer>(_context.Customers.ToList());
        }

        public Customer GetCustomerById(int customerId)
        {
            var customer =_context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
            return customer;
        }

        public Customer GetCustomerByUsernameAndPassword(string username, string password)
        {
            return _context.Customers.FirstOrDefault(c => c.EmailAddress == username && c.Password == password);
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        ObservableCollection<BookingReservation> ICustomerRepository.GetAllCustomers()
        {
            throw new NotImplementedException();
        }
    }
}
