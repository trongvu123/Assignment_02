using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern1
{
    public class BookingReservationRepository : IBookingReservationRepository
    {
        private readonly FuminiHotelManagementContext _context;

        public BookingReservationRepository(FuminiHotelManagementContext context)
        {
            _context = context;
        }

        public void addBookingReservation(BookingReservation reservation)
        {
            _context.BookingReservations.Add(reservation);
            _context.SaveChanges();
        }

        public ObservableCollection<BookingReservation> GetAllBookingReservation()
        {
            return new ObservableCollection<BookingReservation>(_context.BookingReservations.ToList());
        }

        public ObservableCollection<BookingReservation> GetAllBookingReservationByUser(int id)
        {
            return new ObservableCollection<BookingReservation>(_context.BookingReservations.Where(b=>b.CustomerId==id).ToList());
        }

        public BookingReservation GetBookingReservation(int id)
        {
            var Booking = _context.BookingReservations.SingleOrDefault(b => b.BookingReservationId == id);
            return Booking;
        }

        public void removeBookingReservation(int id)
        {
            var booking = GetBookingReservation(id);
            _context.BookingReservations.Remove(booking);
            _context.SaveChanges();
        }

        public void updateBookingReservation(BookingReservation reservation)
        {
            _context.BookingReservations.Update(reservation);
            _context.SaveChanges(); 
        }

    }
}
