using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Interface
{
    public interface IWorker
    {
        IRoomRepository tbl_Rooms { get; }
        IRoomNumberRepository tbl_RoomNumber { get; }

        IRoomAmenityRepository tbl_RoomAmenity { get; }       
        IBookingRepository tbl_Booking { get; } 
        IApplicationUserRepository tbl_User { get; }
        IAmenityRepository tbl_Amenity { get; }



    }
}
