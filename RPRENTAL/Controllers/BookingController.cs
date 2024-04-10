using DataService.Implementation;
using DataService.Interface;
using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json;
using StaticUtility;
using Stripe;
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
        public IActionResult ConfirmBooking(string jsonData)
        {

            var objData = jsonData.Split('&').Select(obj => obj.Split('=')).ToDictionary(obj => obj[0], obj => obj[1]);

            DateOnly checkin_date = DateOnly.Parse(objData["CHECKIN_DATE"]);
            DateOnly checkout_date = DateOnly.Parse(objData["CHECKOUT_DATE"]);
            int room_id = int.Parse(objData["ROOM_ID"]);

            Booking objBooking = new Booking();


            var objRoom = _IWorker.tbl_Rooms.Get(fw => fw.ROOM_ID == room_id);
           
            objBooking.USER_ID = "a507b587-2751-4f6f-ac26-1e9c96ec769e";
            objBooking.ROOM_ID = room_id;
            objBooking.ROOM_NUMBER = 0;
            objBooking.USER_NAME = "rolimer_pono@yahoo.com";
            objBooking.USER_EMAIL = "rolimer_pono@yahoo.com";
            objBooking.PHONE_NUMBER = "0212477441";         
            objBooking.TOTAL_COST = objRoom.ROOM_PRICE * (checkout_date.AddDays(1 - checkin_date.DayNumber).DayNumber);
            objBooking.BOOKING_STATUS = SD.BookingStatus.PENDING.ToString();
            objBooking.BOOKING_DATE = DateTime.Now;
            objBooking.CHECK_IN_DATE = DateOnly.FromDateTime( DateTime.Now);
            objBooking.CHECK_OUT_DATE = DateOnly.FromDateTime(DateTime.Now);
            objBooking.IS_PAYMENT_SUCCESSFULL = false;
            objBooking.PAYMENT_DATE = DateTime.Parse("1900-01-01");
            objBooking.STRIPE_SESSION_ID = "";
            objBooking.STRIPE_PAYEMENT_INTENT_ID = "";
            objBooking.ACTUAL_CHECK_IN_DATE = DateTime.Parse("1900-01-01");
            objBooking.ACTUAL_CHECK_OUT_DATE = DateTime.Parse("1900-01-01");


            _IWorker.tbl_Booking.Add(objBooking);
            _IWorker.tbl_Booking.Save();

            return Json(new { success = true, message = "Successfully", booking = JsonConvert.SerializeObject(objBooking) });
            

          }

        [HttpPost]
        public IActionResult ShowPayment(int booking_id)
        {
            var objBooking = _IWorker.tbl_Booking.Get(fw => fw.BOOKING_ID == booking_id);

            var objRoom= _IWorker.tbl_Rooms.Get(fw => fw.ROOM_ID == objBooking.ROOM_ID);    

            var domain = Request.Scheme + "://" + Request.Host.Value + "/";

            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                SuccessUrl = domain + $"Booking/BookingConfirmation?booking_id={objBooking.BOOKING_ID}",
                CancelUrl = domain + $"Booking/CreateBooking/ID={objBooking.ROOM_ID}&jsonData={JsonConvert.SerializeObject($"CHECKIN_DATE{objBooking.CHECK_IN_DATE}, CHECKOUT_DATE{objBooking.CHECK_OUT_DATE}")}",
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

        public IActionResult BookingConfirmation(int booking_id)
        {
            Booking objBooking = _IWorker.tbl_Booking.Get(fw => fw.BOOKING_ID == booking_id, IncludeProperties: "User,Room");

            if (objBooking.BOOKING_STATUS == SD.BookingStatus.PENDING.ToString())
            {
                var service = new SessionService();
                Session session = service.Get(objBooking.STRIPE_SESSION_ID);

                if (session.PaymentStatus == "paid")
                {
                    _IWorker.tbl_Booking.UpdateBookingStatus(objBooking.BOOKING_ID, SD.BookingStatus.APPROVED.ToString(), 0);
                    _IWorker.tbl_Booking.UpdateStripePaymentID(objBooking.BOOKING_ID, session.Id, session.PaymentIntentId);
                    _IWorker.tbl_Booking.Save();
                }
            }
            return View(booking_id);
        }


    }
}
