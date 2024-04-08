using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Interface
{
    public interface IRoomService
    {
        IEnumerable<Room> GetAll();

        Room Get(int ROOM_ID);

        Boolean IsRoomNameExists(Room objRoom);

        void Create(Room objRoom);

        void Update(Room objRoom);

        void Delete(int ROOM_ID);
    }
}
