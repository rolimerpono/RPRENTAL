using DataService.Interface;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Implementation
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

        public void Delete(int RoomNo)
        {
            try
            { 
                var objRoomNumber = _IWorker.tbl_RoomNumber.Get(fw => fw.RoomNo == RoomNo);

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

        public RoomNumber Get(int RoomNo)
        {
            try
            {
                var objRoomNumber = _IWorker.tbl_RoomNumber.Get(fw => fw.RoomNo == RoomNo, IncludeProperties: "Room");

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
                var objRoomNumber = _IWorker.tbl_RoomNumber.GetAll(IncludeProperties: "Room");

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
            

        public bool IsRoomNumberExists(int RoomNo)
        {
           
            var objRoomNumber = _IWorker.tbl_RoomNumber.Get(fw => fw.RoomNo == RoomNo);

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
