using DataService.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Implementation
{
    public class BookingService : IBookingService
    {

        private readonly IWorker _IWorker;
        public BookingService(IWorker IWorker)
        {
            _IWorker = IWorker;   
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Booking objBooking)
        {
            throw new NotImplementedException();
        }

        public void UpdateBookingStatus(int BookingID, string BookingStatus, int RoomNumber)
        {
            throw new NotImplementedException();
        }

        public void UpdatePaypalPaymentID(int BookingID, string SessionID, string PaypalPaymentID)
        {
            throw new NotImplementedException();
        }

        public void UpdateStripePaymentID(int BookingID, string SessionID, string StripePaymentID)
        {
            throw new NotImplementedException();
        }
    }
}
