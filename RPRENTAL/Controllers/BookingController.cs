using DataService.Interface;
using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json;
using StaticUtility;
using Stripe.Checkout;
using System.Security.Claims;
using static StaticUtility.SD;

namespace RPRENTAL.Controllers
{
    public class BookingController : Controller
    {

        private readonly IWorker _IWorker;
        public BookingController(IWorker IWorker)
        {
            _IWorker = IWorker; 
        }
        public IActionResult Index()
        {
            return View();
        }
    

        [HttpGet]
        public IActionResult CreateBooking(int ID, string jsonData)
        {
            var userID = (User.Identity as ClaimsIdentity)?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser user = new ApplicationUser();

            if (userID != null)
            {
                user = _IWorker.tbl_User.Get(fw => fw.Id == userID);
            }


            var objData = jsonData.Split('&').Select(obj => obj.Split('=')).ToDictionary(obj => obj[0], obj => obj[1]);

            DateOnly checkin_date = DateOnly.Parse(objData["CHECKIN_DATE"]);
            DateOnly checkout_date = DateOnly.Parse(objData["CHECKOUT_DATE"]);



            Common.Util objUtil = new Common.Util(_IWorker);

            if (objUtil.GetRoomsAvailableCount(ID, checkin_date, checkout_date) <=0)
            {
                return View();
            }


            Booking objBooking = new()
            {
                ROOM_ID         = ID,
                ROOM            = _IWorker.tbl_Rooms.Get(fw => fw.ROOM_ID == ID, IncludeProperties:"ROOM_AMENITIES"),
                CHECK_IN_DATE   = checkin_date,
                CHECK_OUT_DATE  = checkout_date,
                USER_ID         = user.Id,
                PHONE_NUMBER    = user.PhoneNumber,
                USER_EMAIL      = user.Email,
                USER_NAME       = user.USER_NAME,
            };

          
            objBooking.TOTAL_COST = objBooking.ROOM.ROOM_PRICE * (checkout_date.AddDays(1 - checkin_date.DayNumber).DayNumber);

            return PartialView("Common/_BookingDetail", objBooking);

        }


        [HttpPost]
        public IActionResult ConfirmBooking(Booking objBooking)
        {


            var objRoom = _IWorker.tbl_Rooms.Get(fw => fw.ROOM_ID == objBooking.ROOM_ID);

            objBooking.TOTAL_COST = objRoom.ROOM_PRICE * (objBooking.CHECK_OUT_DATE.AddDays(1 - objBooking.CHECK_IN_DATE.DayNumber).DayNumber);


            objBooking.BOOKING_STATUS = BookingStatus.PENDING.ToString();
            objBooking.BOOKING_DATE = DateTime.Now;


            _IWorker.tbl_Booking.Add(objBooking);
            _IWorker.tbl_Booking.Save();



            var domain = Request.Scheme + "://" + Request.Host.Value + "/";
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                SuccessUrl = domain + $"Booking/CompleteBooking?BookingID={objBooking.BOOKING_ID}",
                CancelUrl = $"{domain}Booking/ConfirmBooking/ID={objBooking.ROOM_ID}&jsonData={JsonConvert.SerializeObject($"{objBooking.CHECK_IN_DATE} {objBooking.CHECK_OUT_DATE}")}"
            };

            options.LineItems.Add(new SessionLineItemOptions
            {

                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmount = (long)(objBooking.TOTAL_COST * 100),
                    Currency = "nzd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = objRoom.ROOM_NAME,
                        Description = objRoom.DESCRIPTION
                        //Images= new List<string> { domain + room.ImgUrl}

                    }

                },
                Quantity = 1

            });


            var service = new SessionService();
            Session session = service.Create(options);


            _IWorker.tbl_Booking.UpdateStripePaymentID(objBooking.BOOKING_ID, session.Id, session.PaymentIntentId);
            _IWorker.tbl_Booking.Save();

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);

        }


    }
}
