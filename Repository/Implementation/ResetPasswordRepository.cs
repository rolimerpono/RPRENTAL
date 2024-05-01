using DatabaseAccess;
using Microsoft.EntityFrameworkCore.Migrations;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class ResetPasswordRepository : Repository<ResetPassword>, IResetPasswordRepository
    {
        private readonly ApplicationDBContext _db;

        public ResetPasswordRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }
     
    }
}
