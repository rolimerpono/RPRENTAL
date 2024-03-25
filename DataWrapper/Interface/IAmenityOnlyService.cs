using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWrapper.Interface
{
    public interface IAmenityOnlyService
    {
        IEnumerable<AmenityOnly> GetAll();

        AmenityOnly Get(int ID);

        Boolean IsAmenityExists(AmenityOnly objAmenity);

        void Create(AmenityOnly objAmenity);

        void Update(AmenityOnly objAmenity);

        void Delete(int ID);

    }
}
