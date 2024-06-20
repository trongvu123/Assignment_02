using HotelManagement.Models;
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
        private readonly FuminiHotelManagementContext _context;
        public RoomRepository(FuminiHotelManagementContext context)
        {
            _context = context;
        }
        public void AddRoom(RoomInformation room)
        {
            _context.RoomInformations.Add(room);
            _context.SaveChanges();
        }
        public RoomInformation GetRoomById(int roomId)
        {
            var room = _context.RoomInformations.FirstOrDefault(r => r.RoomId == roomId);
            return room;
        }
        public void DeleteRoom(int roomId)
        {
            var room = GetRoomById(roomId);
            _context.RoomInformations.Remove(room);
            _context.SaveChanges();
        }

        public ObservableCollection<RoomInformation> GetAllRooms()
        {
            return new ObservableCollection<RoomInformation>(_context.RoomInformations.ToList());
        }

     

        public void UpdateRoom(RoomInformation room)
        {
            _context.RoomInformations.Update(room);
            _context.SaveChanges();
        }
    }
}
