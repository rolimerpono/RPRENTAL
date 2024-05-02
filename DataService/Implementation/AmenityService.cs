using DataService.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Implementation
{
    public class AmenityService : IAmenityService
    {
        private readonly IWorker _iWorker;

        public AmenityService(IWorker worker)
        {
            _iWorker = worker;
        }
        public void Create(Amenity objAmenity)
        {
            try
            {
                _iWorker.tbl_Amenity.Add(objAmenity);
                _iWorker.tbl_Amenity.Save();
               
            }
            catch (Exception ex)
            {
                throw;

            }
           
        }

        public void Delete(int AmenityId)
        {
            try
            {
                Amenity objAmenity = _iWorker.tbl_Amenity.Get(fw => fw.AmenityId == AmenityId);

                if (objAmenity != null)
                {
                    _iWorker.tbl_Amenity.Remove(objAmenity);
                    _iWorker.tbl_Amenity.Save();
                  
                }
            }
            catch (Exception ex)
            {
                throw;
            }
         
        }

        public Amenity Get(int AmenityId)
        {
            try
            {
                Amenity objAmenity;
                objAmenity = _iWorker.tbl_Amenity.Get(fw => fw.AmenityId == AmenityId);
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
                objAmenity = _iWorker.tbl_Amenity.GetAll().OrderBy(fw => fw.AmenityName);
                return objAmenity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool IsAmenityExists(String AmenityName)
        {
            try
            {
                //CHECK IF AMENITY NAME ALREADY EXISTS
                var objResult = _iWorker.tbl_Amenity.Any(fw => fw.AmenityName == AmenityName);

                return objResult;

            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public void Update(Amenity objAmenity)
        {
            try
            {
                _iWorker.tbl_Amenity.Update(objAmenity);
                _iWorker.tbl_Amenity.Save();
               
            }

            catch (Exception e)
            {
                throw;
            }
        }
      
    }
}
