using DataService.Interface;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace DataService.Implementation
{
    public class RoomService : IRoomService
    {
        private readonly IWorker _iWorker;
        private readonly IWebHostEnvironment _webHost;
        public RoomService(IWorker  iWorker , IWebHostEnvironment webhost)
        {
            _iWorker = iWorker;
            _webHost = webhost;
        }

        [HttpPost]
        public void Create(Room objRoom)
        {
            try
            {

                if (objRoom.IMAGE != null)
                {
                    string strFilename = Guid.NewGuid().ToString() + Path.GetExtension(objRoom.IMAGE.FileName);
                    string strImagePath = Path.Combine(_webHost.WebRootPath, @"img\Room Images");


                    var filestream = new FileStream(Path.Combine(strImagePath, strFilename), FileMode.Create);
                    objRoom.IMAGE.CopyTo(filestream);
                    objRoom.IMAGE_URL = @"\img\Room Images\" + strFilename;

                }
            

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

                objRoom = _iWorker.tbl_Rooms.GetAll(IncludeProperties: "ROOM_AMENITIES");
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

                if (objRoom.IMAGE != null)
                {
                    string strFilename = Guid.NewGuid().ToString() + Path.GetExtension(objRoom.IMAGE.FileName);
                    string strImagePath = Path.Combine(_webHost.WebRootPath, @"img\Room Images");


                    if (!String.IsNullOrEmpty(objRoom.IMAGE_URL))
                    {
                        string previous_image = strImagePath + "\\" + Path.GetFileName(objRoom.IMAGE_URL);

                        if (System.IO.File.Exists(previous_image))
                        {
                            System.IO.File.Delete(previous_image);
                        }
                        
                    }

                    var filestream = new FileStream(Path.Combine(strImagePath, strFilename), FileMode.Create);
                    objRoom.IMAGE.CopyTo(filestream);
                    objRoom.IMAGE_URL = @"\img\Room Images\" + strFilename;
                
                }

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
