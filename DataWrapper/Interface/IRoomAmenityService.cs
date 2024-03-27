using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWrapper.Interface
{
    public interface IRoomAmenityService
    {
        IEnumerable<RoomAmenity> GetAll();

        RoomAmenity Get(int ID);

        void Create(RoomAmenity objRoomAmenity);

        void Update(RoomAmenity objRoomAmenity);

        void Delete(int ID);
    }
}
