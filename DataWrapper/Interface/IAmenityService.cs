﻿using Model;
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

        Amenity Get(int Amenity_ID);

        Boolean IsAmenityExists(Amenity objAmenity);

        bool Create(Amenity objAmenity);

        bool Update(Amenity objAmenity);

        bool Delete(int Amenity_ID);

    }
}
