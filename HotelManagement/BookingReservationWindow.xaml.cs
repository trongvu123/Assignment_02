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

namespace MiniHotelManagement
{
    /// <summary>
    /// Interaction logic for BookingReservationWindow.xaml
    /// </summary>
    public partial class BookingReservationWindow : Window
    {
        private readonly BookingReservationRepository bookingReservationRepository;
        private readonly BookingDetailRepository bookingDetailRepository;
        private ObservableCollection<BookingReservation> _bookings;
        public BookingReservationWindow(BookingReservationRepository _bookingReservationRepository, BookingDetailRepository _bookingDetailRepository)
        {
            bookingReservationRepository = _bookingReservationRepository;
            bookingDetailRepository = _bookingDetailRepository;
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadBookingReservations();
        }
        private void LoadBookingReservations()
        {
            _bookings = bookingReservationRepository.GetAllBookingReservation();
            dgData.ItemsSource = _bookings;
            
        }
        private void LoadBookingDetails(int bookingReservationId)
        {
          var filteredDetails = bookingDetailRepository.GetAllBookingDetail(bookingReservationId);
            dgDetailData.ItemsSource = filteredDetails;
        }

        private void dgData_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (dgData.SelectedItem is BookingReservation selectedReservation)
            {
                LoadBookingDetails(selectedReservation.BookingReservationId);
               
                dgData.Visibility = Visibility.Collapsed;
                dgDetailData.Visibility = Visibility.Visible;
                btnBack.Visibility = Visibility.Visible;
            }
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BookingReservation customer1 = new BookingReservation
                {
                    BookingReservationId = int.Parse(txtBookingReservationId.Text),
                    BookingDate = DateOnly.Parse(txtDate.Text),
                    TotalPrice = decimal.Parse(txtTotalPrice.Text), 
                    CustomerId = int.Parse(txtCustomerId.Text),
                    BookingStatus = 1
                };
                bookingReservationRepository.addBookingReservation(customer1);
                _bookings.Add(customer1);
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
                if (txtBookingReservationId.Text.Length > 0)
                {
                    int id = int.Parse(txtBookingReservationId.Text);
                    BookingReservation bookingReservation = bookingReservationRepository.GetBookingReservation(id);
                    if (bookingReservation != null)
                    {
                        bookingReservation.BookingReservationId = id;
                        bookingReservation.BookingDate = DateOnly.Parse(txtDate.Text);
                        bookingReservation.TotalPrice = decimal.Parse(txtTotalPrice.Text);
                        bookingReservation.CustomerId = int.Parse(txtCustomerId.Text);
                        bookingReservation.BookingStatus = 1;
                        bookingReservationRepository.updateBookingReservation(bookingReservation);  
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
                if (txtBookingReservationId.Text.Length > 0)
                {

                    int id = int.Parse(txtBookingReservationId.Text);
                    var detail = bookingReservationRepository.GetBookingReservation(id);
                    bookingReservationRepository.removeBookingReservation(id);
                    _bookings.Remove(detail);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem is BookingReservation booking)
            {
                txtBookingReservationId.Text = booking.BookingReservationId.ToString();
                txtCustomerId.Text= booking.CustomerId.ToString();
                txtDate.Text= booking.BookingDate.ToString();
                txtTotalPrice.Text= booking.TotalPrice.ToString();  
                txtCustomerId.Text = booking.CustomerId.ToString(); 
            }
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            dgData.Visibility = Visibility.Visible;
            dgDetailData.Visibility = Visibility.Collapsed;
            btnBack.Visibility = Visibility.Collapsed;
        }

    }
}
