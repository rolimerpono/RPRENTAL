using DatabaseAccess;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDBContext _db;
        private DbSet<T> dbSet;

        public Repository(ApplicationDBContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public void Add(T objEntity)
        {
            dbSet.Add(objEntity); 
        }

        public bool Any(Expression<Func<T, bool>> Filter)
        {
            return dbSet.Any(Filter);
        }

        public IEnumerable<T> GetAllRecords(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool isTracking = false)
        {            
           
            IQueryable<T> objQuery = isTracking ? dbSet.AsQueryable() : dbSet.AsNoTracking();

            if (filter != null)
            {
                objQuery = objQuery.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            { 
                foreach( var prop in includeProperties.Split(new char [] { ',' }, StringSplitOptions.RemoveEmptyEntries) )
                {
                    objQuery = objQuery.Include(prop);
                }
            }

            return objQuery;
        }

        public T GetRecord(Expression<Func<T, bool>>? filter = null, string? IncludeProperties = null, bool isTracking = false)
        {
            IQueryable<T> objQuery = isTracking ? dbSet.AsQueryable() : dbSet.AsNoTracking();

            if (filter != null)
            {
                objQuery = objQuery.Where(filter);
            }

            if (!string.IsNullOrEmpty(IncludeProperties)) 
            { 
                foreach( var prop in IncludeProperties.Split(new char [] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    objQuery = objQuery.Include(prop);
                }
            }

            return objQuery.FirstOrDefault();
        }

        public void remove(T objEntity)
        {
            dbSet.Remove(objEntity);
        }
    }
}
