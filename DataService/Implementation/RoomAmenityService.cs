using DataService.Interface;
using Microsoft.EntityFrameworkCore.Query;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Implementation
{
    public class RoomAmenityService : IRoomAmenityService
    {

        private readonly IWorker _IWorker;
        public RoomAmenityService(IWorker IWorker)
        {
          _IWorker = IWorker;
        }

        public void Create(RoomAmenity objRoomAmenity)
        {
            _IWorker.tbl_RoomAmenity.Add(objRoomAmenity);
            _IWorker.tbl_RoomAmenity.Save();
        }

        public void Delete(int ID)
        {
            IEnumerable<RoomAmenity> objRoomAmenity = _IWorker.tbl_RoomAmenity.GetAll(fw => fw.ROOM_ID == ID);
            if (objRoomAmenity != null)
            {
                foreach (var roomAmenity in objRoomAmenity)
                {
                    _IWorker.tbl_RoomAmenity.Remove(roomAmenity);
                    _IWorker.tbl_RoomAmenity.Save();
                }
                
            }
        }

        public RoomAmenity Get(int ID)
        {
            RoomAmenity objRoomAmenity = _IWorker.tbl_RoomAmenity.Get(fw => fw.ID == ID,IncludeProperties: "ROOMS");
            return objRoomAmenity;
        }

        public IEnumerable<RoomAmenity> GetAll()
        {
            IEnumerable<RoomAmenity> objRoomAmenity;
            objRoomAmenity = _IWorker.tbl_RoomAmenity.GetAll(IncludeProperties: "ROOMS");
            return objRoomAmenity;
        }

        public void Update(RoomAmenity objRoomAmenity)
        {
            _IWorker.tbl_RoomAmenity.Update(objRoomAmenity);
            _IWorker.tbl_RoomAmenity.Save();
        }
    }
}
