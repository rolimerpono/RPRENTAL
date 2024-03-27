using DataWrapper.Interface;
using Microsoft.EntityFrameworkCore.Query;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataWrapper.Implementation
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
            RoomAmenity objRoomAmenity = _IWorker.tbl_RoomAmenity.Get(fw => fw.ID == ID);
            if(objRoomAmenity != null) 
            { 
                _IWorker.tbl_RoomAmenity.Remove(objRoomAmenity);
                _IWorker.tbl_RoomAmenity.Save();
            }
        }

        public RoomAmenity Get(int ID)
        {
            RoomAmenity objRoomAmenity = _IWorker.tbl_RoomAmenity.Get(fw => fw.ID == ID);
            return objRoomAmenity;
        }

        public IEnumerable<RoomAmenity> GetAll()
        {
            IEnumerable<RoomAmenity> objRoomAmenity;
            objRoomAmenity = _IWorker.tbl_RoomAmenity.GetAll();
            return objRoomAmenity;
        }

        public void Update(RoomAmenity objRoomAmenity)
        {
            _IWorker.tbl_RoomAmenity.Update(objRoomAmenity);
            _IWorker.tbl_RoomAmenity.Save();
        }
    }
}
