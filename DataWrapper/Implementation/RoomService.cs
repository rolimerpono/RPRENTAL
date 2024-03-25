using DataWrapper.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWrapper.Implementation
{
    public class RoomService : IRoomService
    {
        private readonly IWorker _iWorker;
        public RoomService(IWorker  iWorker)
        {
            _iWorker = iWorker;
        }

        public void Create(Room objRoom)
        {
            try
            {
                _iWorker.tbl_Rooms.Add(objRoom);
                _iWorker.tbl_Rooms.Save();
               
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public void Delete(int ROOM_ID)
        {
            try
            {
                Room objRoom = _iWorker.tbl_Rooms.Get(fw => fw.ROOM_ID == ROOM_ID);

                if (objRoom != null)
                {
                    _iWorker.tbl_Rooms.Remove(objRoom);
                    _iWorker.tbl_Rooms.Save();
                   
                }
            }
            catch (Exception ex)
            {
                throw ex;                
            }
          
        }

        public Room Get(int ROOM_ID)
        {
            Room objRoom;
            try
            {
              
                objRoom = _iWorker.tbl_Rooms.Get(fw => fw.ROOM_ID == ROOM_ID,IncludeProperties: "ROOM_AMENITIES");
                if (objRoom != null)
                {
                    return objRoom;
                }
                return null;

            }
            catch(Exception ex)
            {
                throw;                
            }
        }

        public IEnumerable<Room> GetAll()
        {
           IEnumerable<Room> objRoom;
            try
            {

                objRoom = _iWorker.tbl_Rooms.GetAll(includeProperties: "ROOM_AMENITIES");
                if (objRoom != null)
                {
                    return objRoom;
                }
                return null;

            }
            catch (Exception ex)
            {
                throw;             
            }
        }

        public bool IsRoomNameExists(Room objRoom)
        {
            Room objRoomResult;
            try
            {
                objRoomResult = _iWorker.tbl_Rooms.Get(fw => fw.ROOM_NAME == objRoom.ROOM_NAME);
                if (objRoomResult != null)
                {
                    return true;      
                }
                return false;

            }
            catch (Exception ex) {
                throw;              
            }
        }

        public void Update(Room objRoom)
        {
            try
            {
                _iWorker.tbl_Rooms.Update(objRoom);
                _iWorker.tbl_Rooms.Save();
               
            }

            catch (Exception e)
            {
                throw;
            }
        }
    }
}
