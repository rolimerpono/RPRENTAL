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

        public void Delete(int Amenity_ID)
        {
            try
            {
                Amenity objAmenity = _iWorker.tbl_Amenity.Get(fw => fw.AMENITY_ID == Amenity_ID);

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

        public Amenity Get(int Amenity_ID)
        {
            try
            {
                Amenity objAmenity;
                objAmenity = _iWorker.tbl_Amenity.Get(fw => fw.AMENITY_ID == Amenity_ID);
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
                objAmenity = _iWorker.tbl_Amenity.GetAll().OrderBy(fw => fw.AMENITY_NAME);
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
                var objResult = _iWorker.tbl_Amenity.Any(fw => fw.AMENITY_NAME == AmenityName);

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
