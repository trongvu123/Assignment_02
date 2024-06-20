using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern1
{
    public interface IBookingDetail
    {
        ObservableCollection<BookingDetail> GetAllBookingDetail(int id);
        BookingDetail GetBookingDetailById(int id);
        void AddBookingDetail(BookingDetail customer);
        void UpdateBookingDetail(BookingDetail customer);
        void DeleteBookingDetail(int id);
    }
}
