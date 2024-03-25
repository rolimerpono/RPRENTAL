using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRoomNumberRepository : IRepository<RoomNumber>
    {

        void Update(RoomNumber objEntity);

        void Save();
    }
}
