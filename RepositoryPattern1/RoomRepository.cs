using DataModels1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern1
{
    public class RoomRepository : IRoomRepository
    {
        private static ObservableCollection<RoomInformation> Rooms = new ObservableCollection<RoomInformation>
        {
               new RoomInformation { RoomID = 1, RoomNumber = "101", RoomDescription = "Standard room", RoomMaxCapacity = 2, RoomStatus = 1, RoomPricePerDate = 100, RoomTypeID = 1 },
               new RoomInformation { RoomID = 2, RoomNumber = "102", RoomDescription = "Deluxe room", RoomMaxCapacity = 4, RoomStatus = 1, RoomPricePerDate = 200, RoomTypeID = 2 },
               new RoomInformation { RoomID = 3, RoomNumber = "201", RoomDescription = "Suite room", RoomMaxCapacity = 6, RoomStatus = 1, RoomPricePerDate = 300, RoomTypeID = 3 }
        };

        public void AddRoom(RoomInformation room)
        {
            Rooms.Add(room);
        }
        public RoomInformation GetRoomById(int roomId)
        {
            var room = Rooms.FirstOrDefault(r => r.RoomID == roomId);
            return room;
        }
        public void DeleteRoom(int roomId)
        {
            var room = GetRoomById(roomId);
            Rooms.Remove(room);
        }

        public ObservableCollection<RoomInformation> GetAllRooms()
        {
            return Rooms;
        }

     

        public void UpdateRoom(RoomInformation room)
        {
            var roomExist = GetRoomById(room.RoomID);
            if (roomExist != null)
            {
                roomExist.RoomNumber = room.RoomNumber;
                roomExist.RoomDescription = room.RoomDescription;
                roomExist.RoomMaxCapacity = room.RoomMaxCapacity;
                roomExist.RoomStatus = room.RoomStatus;
                roomExist.RoomPricePerDate = room.RoomPricePerDate;
                roomExist.RoomTypeID = room.RoomTypeID;
            }

        }
    }
}
