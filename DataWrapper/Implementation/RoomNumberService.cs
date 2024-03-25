using DataWrapper.Interface;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWrapper.Implementation
{
    public class RoomNumberService : IRoomNumberService
    {
        private readonly IWorker _IWorker;


        public RoomNumberService(IWorker iworker)
        {
            _IWorker = iworker;   
        }
        public void Create(RoomNumber objRoomNumber)
        {
            try { 

                _IWorker.tbl_RoomNumber.Add(objRoomNumber);
                _IWorker.tbl_RoomNumber.Save();
                
            
            }
            catch (Exception e)
            {
              
            }
        }

        public void Delete(int ROOM_NUMBER)
        {
            try
            { 
                var objRoomNumber = _IWorker.tbl_RoomNumber.Get(fw => fw.ROOM_NUMBER == ROOM_NUMBER);

                if(objRoomNumber != null)
                {
                    _IWorker.tbl_RoomNumber.Remove(objRoomNumber);
                    _IWorker.tbl_RoomNumber.Save();
                    
                }
                     
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public RoomNumber Get(int ROOM_NUMBER)
        {
            try
            {
                var objRoomNumber = _IWorker.tbl_RoomNumber.Get(fw => fw.ROOM_NUMBER == ROOM_NUMBER, IncludeProperties: "ROOM");

                if (objRoomNumber != null)
                {
                    return objRoomNumber;
                }
                return null;
            
            }

            catch(Exception ex)
            {
                return null;
            }           
        }

        public IEnumerable<RoomNumber> GetAll()
        {
            try
            {
                var objRoomNumber = _IWorker.tbl_RoomNumber.GetAll(includeProperties: "ROOM");

                if (objRoomNumber != null)
                {
                    return objRoomNumber;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }           
        }
            

        public bool IsRoomNumberExists(int ROOM_NUMBER)
        {
           
            var objRoomNumber = _IWorker.tbl_RoomNumber.Get(fw => fw.ROOM_NUMBER == ROOM_NUMBER);

            if (objRoomNumber != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Update(RoomNumber objRoomNumber)
        {
            try
            {
                _IWorker.tbl_RoomNumber.Update(objRoomNumber);
                _IWorker.tbl_RoomNumber.Save();
            }

            catch (Exception ex) 
            {
                throw;
            }

        }
    }
}
