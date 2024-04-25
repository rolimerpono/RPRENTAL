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


            int room_number_count = _iWorker.tbl_RoomNumber.GetAll(tr => tr.ROOM_ID == ROOM_ID).Count();

            int booking_count = _iWorker.tbl_Booking.GetAll(tb =>
            (tb.ROOM_ID == ROOM_ID) && 
            (tb.BOOKING_STATUS == SD.BookingStatus.APPROVED.ToString()) ||
            (tb.BOOKING_STATUS == SD.BookingStatus.CHECK_IN.ToString()) &&
            (
                (CHECKIN_DATE >= tb.CHECK_IN_DATE && CHECKIN_DATE < tb.CHECK_OUT_DATE) || 
                (CHECKOUT_DATE > tb.CHECK_IN_DATE && CHECKOUT_DATE <= tb.CHECK_OUT_DATE) ||
                (CHECKIN_DATE <= tb.CHECK_IN_DATE && CHECKOUT_DATE >= tb.CHECK_OUT_DATE)
            )).Where(fw => fw.ROOM_ID == ROOM_ID).Count();

            int total_count = room_number_count - booking_count;

            return total_count;

        }

        public List<string> GetRoomNumberAvailable(int ROOM_ID, DateOnly CHECKIN_DATE, DateOnly CHECKOUT_DATE)
        {
            var room_number_available = _iWorker.tbl_RoomNumber
                                        .GetAll(tr => tr.ROOM_ID == ROOM_ID)
                                        .Where(objRoom => !_iWorker.tbl_Booking.Any(tb =>
                                            tb.ROOM_ID == ROOM_ID &&
                                            ((CHECKIN_DATE >= tb.CHECK_IN_DATE && CHECKIN_DATE < tb.CHECK_OUT_DATE) ||
                                            (CHECKOUT_DATE > tb.CHECK_IN_DATE && CHECKOUT_DATE <= tb.CHECK_OUT_DATE) ||
                                            (CHECKIN_DATE <= tb.CHECK_IN_DATE && CHECKOUT_DATE >= tb.CHECK_OUT_DATE)) &&
                                            tb.ROOM_NUMBER == objRoom.ROOM_NUMBER &&
                                            tb.BOOKING_STATUS != SD.BookingStatus.CHECK_OUT.ToString()))
                                        .Select(objRoom => objRoom.ROOM_NUMBER.ToString())
                                        .ToList();

            return room_number_available;
        }



    }
}
