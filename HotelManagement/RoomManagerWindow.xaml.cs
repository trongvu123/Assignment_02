using DataModels1;
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
        public RoomManagerWindow()
        {
            _roomRepository = new RoomRepository();
            _roomTypeRepository = new RoomTypeRepository();
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
            cboCategory.SelectedValuePath = "RoomTypeID";
        }
        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem is RoomInformation room)
            {
                txtRoomID.Text = room.RoomID.ToString();
                txtRoomNumber.Text = room.RoomNumber;
                txtRoomDescription.Text = room.RoomDescription;
                txtRoomCapacity.Text = room.RoomMaxCapacity.ToString();
                txtRoomPrice.Text = room.RoomPricePerDate.ToString();
                cboCategory.SelectedValue = room.RoomTypeID;
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var room = _roomRepository.GetAllRooms();
                var roomLast = room.LastOrDefault();
                RoomInformation newRoom = new RoomInformation
                {
                    RoomID = roomLast.RoomID + 1,
                    RoomNumber = txtRoomNumber.Text,
                    RoomDescription = txtRoomDescription.Text,
                    RoomMaxCapacity = int.Parse(txtRoomCapacity.Text),
                    RoomPricePerDate = decimal.Parse(txtRoomPrice.Text),
                    RoomStatus = 1,
                    RoomTypeID = (int)cboCategory.SelectedValue
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
                    roomToUpdate.RoomDescription = txtRoomDescription.Text;
                    roomToUpdate.RoomMaxCapacity = int.Parse(txtRoomCapacity.Text);
                    roomToUpdate.RoomPricePerDate = decimal.Parse(txtRoomPrice.Text);
                    roomToUpdate.RoomTypeID = (int)cboCategory.SelectedValue;
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
    }
}
