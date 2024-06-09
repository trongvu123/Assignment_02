using DataModels1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern1
{
    public class RoomTypeRepository : IRoomType
    {
        private static ObservableCollection<RoomType> _rooms = new ObservableCollection<RoomType>
        {
            new RoomType { RoomTypeID = 1, RoomTypeName = "Standard", TypeDescription = "Standard room", TypeNote = "Basic amenities" },
               new RoomType { RoomTypeID = 2, RoomTypeName = "Deluxe", TypeDescription = "Deluxe room", TypeNote = "Enhanced amenities" },
               new RoomType { RoomTypeID = 3, RoomTypeName = "Suite", TypeDescription = "Suite room", TypeNote = "Luxury amenities" }
        };
        public ObservableCollection<RoomType> GetRoomTypes()
        {
            return _rooms;
        }
    }
}
