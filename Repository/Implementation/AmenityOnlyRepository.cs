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
    public class AmenityOnlyRepository : Repository<AmenityOnly>, IAmenityOnlyRepository
    {

        private readonly ApplicationDBContext _db;
        public AmenityOnlyRepository(ApplicationDBContext db): base(db)
        {
            _db = db;
        }
      
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(AmenityOnly objAmenityOnly)
        {
            _db.tbl_AmenityOnly.Update(objAmenityOnly);
        }
    }
}
