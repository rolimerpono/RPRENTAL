using DataService.Interface;
using Microsoft.EntityFrameworkCore;
using Model;
using Utility;
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

        public int GetRoomsAvailableCount(int RoomId, DateOnly CheckinDate, DateOnly CheckoutDate)
        {


            int room_number_count = _iWorker.tbl_RoomNumber.GetAll(tr => tr.RoomId == RoomId).Count();

            int booking_count = _iWorker.tbl_Booking.GetAll(tb =>
            (tb.RoomId == RoomId) && 
            (tb.BookingStatus == SD.BookingStatus.Approved.ToString()) ||
            (tb.BookingStatus == SD.BookingStatus.Checkin.ToString()) &&
            (
                (CheckinDate >= tb.CheckinDate && CheckinDate < tb.CheckoutDate) || 
                (CheckoutDate > tb.CheckinDate && CheckoutDate <= tb.CheckoutDate) ||
                (CheckinDate <= tb.CheckinDate && CheckoutDate >= tb.CheckoutDate)
            )).Where(fw => fw.RoomId == RoomId).Count();

            int total_count = room_number_count - booking_count;

            return total_count;

        }

        public List<string> GetRoomNumberAvailable(int RoomId, DateOnly CheckinDate, DateOnly CheckoutDate)
        {
            var room_number_available = _iWorker.tbl_RoomNumber
                                        .GetAll(tr => tr.RoomId == RoomId)
                                        .Where(objRoom => !_iWorker.tbl_Booking.Any(tb =>
                                            tb.RoomId == RoomId &&
                                            ((CheckinDate >= tb.CheckinDate && CheckinDate < tb.CheckoutDate) ||
                                            (CheckoutDate > tb.CheckinDate && CheckoutDate <= tb.CheckoutDate) ||
                                            (CheckinDate <= tb.CheckinDate && CheckoutDate >= tb.CheckoutDate)) &&
                                            tb.RoomNo == objRoom.RoomNo &&
                                            tb.BookingStatus != SD.BookingStatus.Checkout.ToString()))
                                        .Select(objRoom => objRoom.RoomNo.ToString())
                                        .ToList();

            return room_number_available;
        }



    }
}
