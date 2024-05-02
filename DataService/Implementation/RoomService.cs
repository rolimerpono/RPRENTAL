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

                if (objRoom.Image != null)
                {
                    string strFilename = Guid.NewGuid().ToString() + Path.GetExtension(objRoom.Image.FileName);
                    string strImagePath = Path.Combine(_webHost.WebRootPath, @"img\Room Images");


                    var filestream = new FileStream(Path.Combine(strImagePath, strFilename), FileMode.Create);
                    objRoom.Image.CopyTo(filestream);
                    objRoom.ImageUrl = @"\img\Room Images\" + strFilename;

                }
            

                _iWorker.tbl_Rooms.Add(objRoom);
                _iWorker.tbl_Rooms.Save();
               
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public void Delete(int RoomId)
        {
            try
            {
                Room objRoom = _iWorker.tbl_Rooms.Get(fw => fw.RoomId == RoomId);

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

        public Room Get(int RoomId)
        {
            Room objRoom;
            try
            {
              
                objRoom = _iWorker.tbl_Rooms.Get(fw => fw.RoomId == RoomId,IncludeProperties: "RoomAmenities");
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

                objRoom = _iWorker.tbl_Rooms.GetAll(IncludeProperties: "RoomAmenities");
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
            bool is_record_exists = false;
            try
            {
                    
            
             return is_record_exists = _iWorker.tbl_Rooms.Any(fw => fw.RoomName.ToLower().Trim() == objRoom.RoomName.ToLower().Trim());              

            }
            catch (Exception ex) {
                throw;              
            }
        }

        public void Update(Room objRoom)
        {
            try
            {

                if (objRoom.Image != null)
                {
                    string strFilename = Guid.NewGuid().ToString() + Path.GetExtension(objRoom.Image.FileName);
                    string strImagePath = Path.Combine(_webHost.WebRootPath, @"img\Room Images");


                    if (!String.IsNullOrEmpty(objRoom.ImageUrl))
                    {
                        string previous_image = strImagePath + "\\" + Path.GetFileName(objRoom.ImageUrl);

                        if (System.IO.File.Exists(previous_image))
                        {
                            System.IO.File.Delete(previous_image);
                        }
                        
                    }

                    var filestream = new FileStream(Path.Combine(strImagePath, strFilename), FileMode.Create);
                    objRoom.Image.CopyTo(filestream);
                    objRoom.ImageUrl = @"\img\Room Images\" + strFilename;
                
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
