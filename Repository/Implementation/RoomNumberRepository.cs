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
    public class RoomNumberRepository : Repository<RoomNumber>,IRoomNumberRepository
    {
        private readonly ApplicationDBContext _db;
        public RoomNumberRepository(ApplicationDBContext db) : base(db) 
        {
            _db = db;            
        }

        public void Save()
        {
            _db.SaveChanges();  
        }

        public void Update(RoomNumber objEntity)
        {
           _db.tbl_RoomNumber.Update(objEntity);
        }
    }
}
