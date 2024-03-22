using DataWrapper.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWrapper.Implementation
{
    public class AmenityService : IAmenityService
    {
        private readonly IWorker _iWorker;

        public AmenityService(IWorker worker)
        {
            _iWorker = worker;
        }
        public bool Create(Amenity objAmenity)
        {
            try
            {
                _iWorker.tbl_Amenity.Add(objAmenity);
                _iWorker.tbl_Amenity.Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
           
        }

        public bool Delete(int Amenity_ID)
        {
            try
            {
                Amenity objAmenity = _iWorker.tbl_Amenity.Get(fw => fw.AMENITY_ID == Amenity_ID, IncludeProperties: "ROOM");

                if (objAmenity != null)
                {
                    _iWorker.tbl_Amenity.Remove(objAmenity);
                    _iWorker.tbl_Amenity.Save();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        public Amenity Get(int Amenity_ID)
        {
            try
            {
                Amenity objAmenity;
                objAmenity = _iWorker.tbl_Amenity.Get(fw => fw.AMENITY_ID == Amenity_ID, IncludeProperties: "ROOM");
                return objAmenity;

            }
            catch (Exception ex) {

                throw;
            }
        }

        public IEnumerable<Amenity> GetAll()
        {
            try
            {
                IEnumerable<Amenity> objAmenity;
                objAmenity = _iWorker.tbl_Amenity.GetAll(includeProperties: "ROOM").OrderBy(ob => ob.ROOM.ROOM_NAME);
                return objAmenity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool IsAmenityExists(Amenity objAmenity)
        {
            try
            {
                //CHECK IF AMENITY NAME ALREADY EXISTS IN ROOM
                var objResult = from oAmenity in _iWorker.tbl_Amenity.GetAll()
                                join oRoom in _iWorker.tbl_Rooms.GetAll()
                                on oAmenity.ROOM_ID equals oRoom.ROOM_ID
                                where oAmenity.ROOM_ID == objAmenity.ROOM_ID
                                && oAmenity.AMENITY_NAME == objAmenity.AMENITY_NAME
                                select oRoom;

                return objResult.Any();

            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Update(Amenity objAmenity)
        {
            try
            {
                _iWorker.tbl_Amenity.Update(objAmenity);
                _iWorker.tbl_Amenity.Save();
                return true;
            }

            catch (Exception e)
            {
                return false;
            }
        }
      
    }
}
