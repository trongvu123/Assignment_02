using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern1
{
    public class BookingDetailRepository : IBookingDetail
    {
        private readonly FuminiHotelManagementContext _context;

        public BookingDetailRepository(FuminiHotelManagementContext context)
        {
            _context = context;
        }

        public void AddBookingDetail(BookingDetail customer)
        {
           _context.BookingDetails.Add(customer);
            _context.SaveChanges();
        }

        public void DeleteBookingDetail(int id)
        {
            var detail = _context.BookingDetails.FirstOrDefault(b=>b.BookingReservationId==id);
            _context.BookingDetails.Remove(detail);
            _context.SaveChanges();
        }

        public ObservableCollection<BookingDetail> GetAllBookingDetail(int id)
        {
            return new ObservableCollection<BookingDetail>(_context.BookingDetails.Where(b=>b.BookingReservationId==id).ToList());
        }

        public BookingDetail GetBookingDetailById(int id)
        {
            var detail = _context.BookingDetails.FirstOrDefault(b => b.BookingReservationId == id);
            return detail;
        }

        public void UpdateBookingDetail(BookingDetail customer)
        {
            _context.BookingDetails.Update(customer);
            _context.SaveChanges();
        }
    }
}
