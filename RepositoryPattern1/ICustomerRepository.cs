using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models;
namespace RepositoryPattern1
{
    public interface ICustomerRepository
    {
        ObservableCollection<BookingReservation> GetAllCustomers();
        Customer GetCustomerById(int customerId);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int customerId);
    }
}
