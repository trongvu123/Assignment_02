using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern1
{
    public interface IBookingReservationRepository
    {
        ObservableCollection<BookingReservation> GetAllBookingReservation();
        BookingReservation GetBookingReservation(int id);
        ObservableCollection<BookingReservation> GetAllBookingReservationByUser(int id);
        void addBookingReservation(BookingReservation reservation);
        void removeBookingReservation(int id);  
        void updateBookingReservation(BookingReservation reservation);
    }
}
