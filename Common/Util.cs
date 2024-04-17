using DataService.Interface;
using Microsoft.EntityFrameworkCore;
using StaticUtility;

namespace Common
{
    public class Util
    {
        private readonly IWorker _iWorker;

        public Util(IWorker worker)
        {
            _iWorker = worker;
            
        }

        public int GetRoomsAvailableCount(int ROOM_ID, DateOnly CHECKIN_DATE, DateOnly CHECKOUT_DATE)
        {

            int RoomIDAvailableCount = _iWorker.tbl_RoomNumber.GetAll(fw => fw.ROOM_ID == ROOM_ID).
                                    Where(rn => !_iWorker.tbl_Booking.Any(b => b.ROOM_NUMBER == rn.ROOM_NUMBER
                                    && b.CHECK_IN_DATE < CHECKOUT_DATE && b.CHECK_OUT_DATE > CHECKIN_DATE
                                    && b.BOOKING_STATUS != SD.BookingStatus.CHECK_OUT.ToString())).Count();        

            return RoomIDAvailableCount;

        }

        public List<string> GetRoomNumberAvailable(int room_id)

        {
            var query = (from objRoom in _iWorker.tbl_RoomNumber.GetAll(fr => fr.ROOM_ID == room_id)
                         where !_iWorker.tbl_Booking.Any(fb => fb.ROOM_ID == room_id && fb.ROOM_NUMBER == objRoom.ROOM_NUMBER && fb.BOOKING_STATUS != SD.BookingStatus.CHECK_OUT.ToString())
                         select objRoom.ROOM_NUMBER.ToString()).ToList();

            return query;

        }



    }
}
