using DataModels1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHotelManagement
{
    public static class CurrentUser
    {
        public static Customer LoggedInUser { get; set; }
    }

}
