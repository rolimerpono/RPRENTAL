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

        Amenity Get(int AMENITY_ID);

        Boolean IsAmenityExists(Amenity objAmenity);

        void Create(Amenity objAmenity);

        void Update(Amenity objAmenity);

        void Delete(int AMENITY_ID);

    }
}
