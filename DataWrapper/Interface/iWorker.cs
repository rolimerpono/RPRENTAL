using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWrapper.Interface
{
    public interface IWorker
    {
        IRoomRepository tbl_Rooms { get; }
        IRoomNumberRepository tbl_RoomNumber { get; }
        IAmenityRepository tbl_Amenity { get; }
        IBookingRepository tbl_Booking { get; } 
        IApplicationUserRepository tbl_User { get; }
        IAmenityOnlyRepository tbl_AmenityOnly { get; }


    }
}
