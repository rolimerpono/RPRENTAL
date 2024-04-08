using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Interface
{
    public interface IRoomNumberService
    {
        IEnumerable<RoomNumber> GetAll();

        RoomNumber Get(int ROOM_NUMBER);

        Boolean IsRoomNumberExists(int ROOM_NUMBER);

        void Create(RoomNumber objRoomNumber);

        void Update(RoomNumber objRoomNumber);

        void Delete(int ROOM_NUMBER);
    }
}
