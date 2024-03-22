using DatabaseAccess;
using DataWrapper.Interface;
using Repository.Implementation;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWrapper.Implementation
{
    public class Worker : IWorker
    {
        private readonly ApplicationDBContext _db;

        public Worker(ApplicationDBContext db)
        {
            _db = db;
            tbl_Rooms = new RoomRepository(_db);
            tbl_RoomNumber = new RoomNumberRepository(_db);
            tbl_Amenity = new AmenityRepository(_db);
            tbl_Booking = new BookingRepository(_db);
            tbl_User  = new  ApplicationRepository(_db);
        }
        public IRoomRepository tbl_Rooms {get; private set;}

        public iRoomNumberRepository tbl_RoomNumber { get; private set; }

        public IAmenityRepository tbl_Amenity { get; private set; }

        public IBookingRepository tbl_Booking { get; private set; }

        public IApplicationUserRepository tbl_User { get; private set; }
    }
}
