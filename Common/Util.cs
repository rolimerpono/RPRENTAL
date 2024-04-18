using DataService.Interface;
using Microsoft.EntityFrameworkCore;
using Model;
using StaticUtility;
using System.Reflection.Metadata.Ecma335;

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

            int count = _iWorker.tbl_RoomNumber.GetAll(tb => tb.ROOM_ID == ROOM_ID).Count();

            int book_count = _iWorker.tbl_Booking.GetAll(fw => (fw.ROOM_ID == ROOM_ID) &&
             ((CHECKIN_DATE >= fw.CHECK_IN_DATE && CHECKIN_DATE < fw.CHECK_OUT_DATE) ||
             (CHECKOUT_DATE > fw.CHECK_IN_DATE && CHECKOUT_DATE <= fw.CHECK_OUT_DATE) ||
             (CHECKIN_DATE <= fw.CHECK_IN_DATE && CHECKOUT_DATE >= fw.CHECK_OUT_DATE && fw.BOOKING_STATUS != SD.BookingStatus.CHECK_OUT.ToString()))).Count();

            int final_count = count - book_count;

            return final_count;

        }

        public List<string> GetRoomNumberAvailable(int ROOM_ID, DateOnly CHECKIN_DATE, DateOnly CHECKOUT_DATE)
        {
            var room_number_available = _iWorker.tbl_RoomNumber
                                        .GetAll(fr => fr.ROOM_ID == ROOM_ID)
                                        .Where(objRoom => !_iWorker.tbl_Booking.Any(fb =>
                                            fb.ROOM_ID == ROOM_ID &&
                                            ((CHECKIN_DATE >= fb.CHECK_IN_DATE && CHECKIN_DATE < fb.CHECK_OUT_DATE) ||
                                            (CHECKOUT_DATE > fb.CHECK_IN_DATE && CHECKOUT_DATE <= fb.CHECK_OUT_DATE) ||
                                            (CHECKIN_DATE <= fb.CHECK_IN_DATE && CHECKOUT_DATE >= fb.CHECK_OUT_DATE)) &&
                                            fb.ROOM_NUMBER == objRoom.ROOM_NUMBER &&
                                            fb.BOOKING_STATUS != SD.BookingStatus.CHECK_OUT.ToString()))
                                        .Select(objRoom => objRoom.ROOM_NUMBER.ToString())
                                        .ToList();

            return room_number_available;
        }



    }
}
