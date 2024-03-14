using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRoomRepository : IRepository<Room>
    {
        void UpdateRecord(Room objEntity);
        void Save();
    }
}
