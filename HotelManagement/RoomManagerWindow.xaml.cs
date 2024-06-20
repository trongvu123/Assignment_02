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
    /// Interaction logic for RoomManagerWindow.xaml
    /// </summary>
    public partial class RoomManagerWindow : Window
    {
        private readonly RoomRepository _roomRepository;
        private readonly RoomTypeRepository _roomTypeRepository;
        private ObservableCollection<RoomInformation> _rooms;
        private ObservableCollection<RoomType> _roomTypes;
        public RoomManagerWindow(RoomTypeRepository roomTypeRepository, RoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
            _roomTypeRepository = roomTypeRepository;
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadDataRoom();
            loadDataRoomType();
        }
        public void loadDataRoom()
        {
            _rooms = new ObservableCollection<RoomInformation>(_roomRepository.GetAllRooms());
            dgData.ItemsSource = _rooms;
        }
        public void loadDataRoomType()
        {
            _roomTypes = new ObservableCollection<RoomType>(_roomTypeRepository.GetRoomTypes());
            cboCategory.ItemsSource = _roomTypes;
            cboCategory.DisplayMemberPath = "RoomTypeName";
            cboCategory.SelectedValuePath = "RoomTypeId";
        }
        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem is RoomInformation room)
            {
                txtRoomID.Text = room.RoomId.ToString();
                txtRoomNumber.Text = room.RoomNumber;
                txtRoomDescription.Text = room.RoomDetailDescription;
                txtRoomCapacity.Text = room.RoomMaxCapacity.ToString();
                txtRoomPrice.Text = room.RoomPricePerDay.ToString();
                cboCategory.SelectedValue = room.RoomTypeId;
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var room = _roomRepository.GetAllRooms();
             
                RoomInformation newRoom = new RoomInformation
                {
                 
                    RoomNumber = txtRoomNumber.Text,
                    RoomDetailDescription = txtRoomDescription.Text,
                    RoomMaxCapacity = int.Parse(txtRoomCapacity.Text),
                    RoomPricePerDay = decimal.Parse(txtRoomPrice.Text),
                    RoomStatus = 1,
                    RoomTypeId = (int)cboCategory.SelectedValue
                };
                _roomRepository.AddRoom(newRoom);
                loadDataRoom();
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
                if (int.TryParse(txtRoomID.Text, out int roomId))
                {
                    RoomInformation roomToUpdate = _roomRepository.GetRoomById(roomId);
                    roomToUpdate.RoomNumber = txtRoomNumber.Text;
                    roomToUpdate.RoomDetailDescription = txtRoomDescription.Text;
                    roomToUpdate.RoomMaxCapacity = int.Parse(txtRoomCapacity.Text);
                    roomToUpdate.RoomPricePerDay = decimal.Parse(txtRoomPrice.Text);
                    roomToUpdate.RoomStatus = 1;    
                    roomToUpdate.RoomTypeId = (int)cboCategory.SelectedValue;
                    _roomRepository.UpdateRoom(roomToUpdate);
                    loadDataRoom();
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
                if (int.TryParse(txtRoomID.Text, out int roomId))
                {
                    _roomRepository.DeleteRoom(roomId);
                    loadDataRoom();
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

        private void btnBookingReservation_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            BookingReservationWindow roomManager = (App.Current as App)?.GetBookingReservationWindow();
            roomManager.Show();
        }
    }
}
