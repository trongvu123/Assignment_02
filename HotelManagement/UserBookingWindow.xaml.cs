using HotelManagement.Models;
using MiniHotelManagement;
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

namespace HotelManagement
{
    /// <summary>
    /// Interaction logic for UserBookingWindow.xaml
    /// </summary>
    public partial class UserBookingWindow : Window
    {
        private readonly BookingReservationRepository reservationRepository;
        private  ObservableCollection<BookingReservation> _booking;
        public UserBookingWindow(BookingReservationRepository _bookingReservation)
        {
            reservationRepository = _bookingReservation;
            InitializeComponent();
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadBookingReservations();
        }
        private void LoadBookingReservations()
        {
            _booking = reservationRepository.GetAllBookingReservationByUser(CurrentUser.LoggedInUser.CustomerId);

            dgData.ItemsSource = _booking;

        }
    }
}
