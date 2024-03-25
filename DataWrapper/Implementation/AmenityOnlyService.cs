using DataWrapper.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWrapper.Implementation
{
    public class AmenityOnlyService : IAmenityOnlyService
    {
        private readonly IWorker _iWorker;

        public AmenityOnlyService(IWorker worker)
        {
            _iWorker = worker;
        }
        public void Create(AmenityOnly objAmenity)
        {
            try
            {
                _iWorker.tbl_AmenityOnly.Add(objAmenity);
                _iWorker.tbl_AmenityOnly.Save();
               
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
                AmenityOnly objAmenity = _iWorker.tbl_AmenityOnly.Get(fw => fw.ID == Amenity_ID);

                if (objAmenity != null)
                {
                    _iWorker.tbl_AmenityOnly.Remove(objAmenity);
                    _iWorker.tbl_AmenityOnly.Save();
                  
                }
            }
            catch (Exception ex)
            {
                throw;
            }
         
        }

        public AmenityOnly Get(int Amenity_ID)
        {
            try
            {
                AmenityOnly objAmenity;
                objAmenity = _iWorker.tbl_AmenityOnly.Get(fw => fw.ID == Amenity_ID);
                return objAmenity;

            }
            catch (Exception ex) {

                throw;
            }
        }

        public IEnumerable<AmenityOnly> GetAll()
        {
            try
            {
                IEnumerable<AmenityOnly> objAmenity;
                objAmenity = _iWorker.tbl_AmenityOnly.GetAll().OrderBy(fw => fw.AMENITY_NAME);
                return objAmenity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool IsAmenityExists(AmenityOnly objAmenity)
        {
            try
            {
                //CHECK IF AMENITY NAME ALREADY EXISTS
                var objResult = _iWorker.tbl_AmenityOnly.Any(fw => fw.AMENITY_NAME == objAmenity.AMENITY_NAME);

                return objResult;

            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public void Update(AmenityOnly objAmenity)
        {
            try
            {
                _iWorker.tbl_AmenityOnly.Update(objAmenity);
                _iWorker.tbl_AmenityOnly.Save();
               
            }

            catch (Exception e)
            {
                throw;
            }
        }
      
    }
}
