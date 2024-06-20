using HotelManagement.Models;
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
        private readonly FuminiHotelManagementContext _context;

        public RoomTypeRepository(FuminiHotelManagementContext context)
        {
            _context = context;
        }

        public ObservableCollection<RoomType> GetRoomTypes()
        {
            return new ObservableCollection<RoomType>(_context.RoomTypes.ToList());
        }
    }
}
