using DatabaseAccess;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class AmenityRepository : Repository<Amenity>, IAmenityRepository
    {
        private readonly ApplicationDBContext _db;

        public AmenityRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }
     
        public void save()
        {
            _db.SaveChanges();
        }

        public void Update(Amenity objAmenity)
        {
            _db.tbl_Amenity.Update(objAmenity);
        }
    }
}
