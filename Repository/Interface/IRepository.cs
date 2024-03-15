using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool isTracking = false);

        T Get(Expression<Func<T, bool>> filter, string? IncludeProperties = null, bool isTracking = false);

        void Add(T objEntity);

        bool Any(Expression<Func<T, Boolean>>? Filter);

        void Remove(T objEntity);



    }
}
