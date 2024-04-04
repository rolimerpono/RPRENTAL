using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWrapper.Interface
{
    public interface IAmenityService
    {
        IEnumerable<Amenity> GetAll();

        Amenity Get(int ID);

        Boolean IsAmenityExists(String AmenityName);

        void Create(Amenity objAmenity);

        void Update(Amenity objAmenity);

        void Delete(int ID);

    }
}
