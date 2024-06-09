using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels1;
namespace RepositoryPattern1
{
    public interface IRoomType
    {
        public ObservableCollection<RoomType> GetRoomTypes();
    }
}
