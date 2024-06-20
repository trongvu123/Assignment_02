using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models;
namespace RepositoryPattern1
{
    public interface IRoomRepository
    {
        ObservableCollection<RoomInformation> GetAllRooms();
        RoomInformation GetRoomById(int roomId);
        void AddRoom(RoomInformation room);
        void UpdateRoom(RoomInformation room);
        void DeleteRoom(int roomId);
    }
}
