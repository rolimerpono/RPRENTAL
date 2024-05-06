using Common;
using DataService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Model;
using Newtonsoft.Json;
using StaticUtility;
using Stripe;
using Stripe.Checkout;
using System;
using System.Security.Claims;
using static StaticUtility.SD;
using static System.Net.WebRequestMethods;


namespace RPRENTAL.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {

        private readonly IWorker _IWorker;
        private readonly IRoomAmenityService _IRoomAmenityService;
        private readonly IWebHostEnvironment _webHost;
        private readonly IHelper _helper;
        private readonly ICompositeViewEngine _viewEngine;



        public BookingController(IWorker IWorker, IRoomAmenityService iRoomAmenityService, IWebHostEnvironment webhost, IHelper helper, ICompositeViewEngine viewengine)
        {
            _IWorker = IWorker;
            _IRoomAmenityService = iRoomAmenityService;
            _webHost = webhost;
            _helper = helper;
            _viewEngine = viewengine;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll(string? status)
        {

            IEnumerable<Booking> objBookings;


            if (User.IsInRole(SD.UserRole.Admin.ToString()))
            {
                objBookings = _IWorker.tbl_Booking.GetAll();

            }
            else
            {
                var user_id = (User.Identity as ClaimsIdentity)?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                objBookings = _IWorker.tbl_Booking.GetAll(fw => fw.UserId == user_id);
            }

            if (!string.IsNullOrEmpty(status) && status != "null")
            {
                objBookings = objBookings.Where(fw => fw.BookingStatus!.ToLower() == status.ToLower());
            }
            else
            {
                objBookings = objBookings.Where(fw => fw.BookingStatus!.ToLower() == SD.BookingStatus.Pending.ToString().ToLower());
            }


            return Json(new { data = objBookings });
        }


        [HttpGet]      
        public IActionResult CreateBooking(int Id, string jsonData)
        {
            Booking objBooking;


            if (Id == 0 || String.IsNullOrEmpty(jsonData))
            {
                return Json(new { success = false, message = SD.BookingTransaction.Fail });
            }

            var userID = (User.Identity as ClaimsIdentity)?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser user = new ApplicationUser();

            if (userID != null)
            {
                user = _IWorker.tbl_User.Get(fw => fw.Id == userID);
            }

            var objData = jsonData.Split('&').Select(obj => obj.Split('=')).ToDictionary(obj => obj[0], obj => obj[1]);

            DateOnly checkin_date = DateOnly.Parse(objData["CheckinDate"]);
            DateOnly checkout_date = DateOnly.Parse(objData["CheckoutDate"]);

            objData = null;



            Common.Util objUtil = new Common.Util(_IWorker);

            if (objUtil.GetRoomsAvailableCount(Id, checkin_date, checkout_date) <= 0)
            {
                return View();
            }


            objBooking = new()
            {
                RoomId = Id,
                Room = _IWorker.tbl_Rooms.Get(fw => fw.RoomId == Id, IncludeProperties: "RoomAmenities"),
                CheckinDate = checkin_date,
                CheckoutDate = checkout_date,
                UserId = user.Id,
                PhoneNumber = user.PhoneNumber,
                UserEmail = user.Email!,
                UserName = user.UserName!                
            };


            objBooking.NoOfStay = (checkout_date.AddDays(1 - checkin_date.DayNumber).DayNumber);
            objBooking.TotalCost = objBooking.Room.RoomPrice * (checkout_date.AddDays(1 - checkin_date.DayNumber).DayNumber);

            return PartialView("Common/_BookingDetails", objBooking);

        }

        [HttpPost,ValidateAntiForgeryToken ]     
        public IActionResult CheckIn(int BookingId, int RoomNo)
        {
            Booking objBooking = _IWorker.tbl_Booking.Get(fw => fw.BookingId == BookingId);
            objBooking.RoomNo = RoomNo; ;

            if (objBooking == null)
            {
                return Json(new { success = false, message = SD.BookingTransaction.Fail });
            }


            _IWorker.tbl_Booking.UpdateBookingStatus(objBooking.BookingId, SD.BookingStatus.Checkin.ToString(), objBooking.RoomNo);
            _IWorker.tbl_Booking.Save();
            return Json(new { success = true, message = SD.BookingTransaction.Success });

        }

        [HttpPost, ValidateAntiForgeryToken]
       
        public IActionResult CheckOut(int BookingId)
        {
            Booking objBooking = _IWorker.tbl_Booking.Get(fw => fw.BookingId == BookingId);
           

            if (objBooking == null)
            {
                return Json(new { success = false, message = SD.BookingTransaction.Fail });
            }


            _IWorker.tbl_Booking.UpdateBookingStatus(objBooking.BookingId, SD.BookingStatus.Checkout.ToString(), objBooking.RoomNo);
            _IWorker.tbl_Booking.Save();
            return Json(new { success = true, message = SD.BookingTransaction.Success });

        }

        [HttpPost,ValidateAntiForgeryToken]

        public IActionResult CancelBooking(int BookingId)
        {
            Booking objBooking = _IWorker.tbl_Booking.Get(fw => fw.BookingId == BookingId);


            if (objBooking == null)
            {
                return Json(new { success = false, message = SD.BookingTransaction.Fail });
            }
            
            _IWorker.tbl_Booking.UpdateBookingStatus(objBooking.BookingId, SD.BookingStatus.Cancelled.ToString(), objBooking.RoomNo);
            _IWorker.tbl_Booking.Save();
            return Json(new { success = true, message = SD.BookingTransaction.Success });

        }

        public IActionResult BookingDetails(int BookingId)
        {
            Util objUtil = new Util(_IWorker);

            Booking objBooking = _IWorker.tbl_Booking.Get(fw => fw.BookingId == BookingId, IncludeProperties: "User,Room");

            if (BookingId == 0)
            {
                return Json(new { success = false, message = SD.BookingTransaction.Fail, booking = JsonConvert.SerializeObject(objBooking) });
            }

            objBooking.Room!.RoomAmenities = _IRoomAmenityService.GetAll().Where(fw => fw.RoomId == objBooking.RoomId);


            if (objBooking != null)
            {
                if (objBooking.RoomNo == 0 && objBooking.BookingStatus == SD.BookingStatus.Approved.ToString())
                {
                    List<string> objList = objUtil.GetRoomNumberAvailable(objBooking.RoomId, objBooking.CheckinDate, objBooking.CheckoutDate).ToList();

                    objBooking.RoomNumberList = objList;
                }
                else
                {
                    objBooking.RoomNumberList = new List<string>();
                }
            }

            return PartialView("Common/_BookingDetail", objBooking);

        }


        [HttpPost]
        public IActionResult ConfirmBooking(int Id, string jsonData)
        {
            Booking objBooking = new Booking();


            if (Id == 0 || string.IsNullOrEmpty(jsonData))
            {
                return Json(new { success = false, message = SD.BookingTransaction.Fail, booking = JsonConvert.SerializeObject(objBooking) });
            }

            try
            {

                var objData = jsonData.Split('&').Select(obj => obj.Split('=')).ToDictionary(obj => obj[0], obj => obj[1]);
                var user_id = (User.Identity as ClaimsIdentity)?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                ApplicationUser objUser = _IWorker.tbl_User.Get(fw => fw.Id == user_id);

                DateOnly checkin_date = DateOnly.Parse(objData["CheckinDate"]);
                DateOnly checkout_date = DateOnly.Parse(objData["CheckoutDate"]);
                int room_id = Id;

                var objRoom = _IWorker.tbl_Rooms.Get(fw => fw.RoomId == room_id);

                objBooking.UserId = objUser.Id;
                objBooking.RoomId = room_id;
                objBooking.RoomNo = 0;
                objBooking.UserName = objUser.UserName!;
                objBooking.UserEmail = objUser.Email!;
                objBooking.PhoneNumber = objUser.PhoneNumber;
                objBooking.TotalCost = objRoom.RoomPrice * (checkout_date.AddDays(1 - checkin_date.DayNumber).DayNumber);
                objBooking.BookingStatus = SD.BookingStatus.Pending.ToString();
                objBooking.BookingDate = DateTime.Now;
                objBooking.CheckinDate = checkin_date;
                objBooking.CheckoutDate = checkout_date;
                objBooking.NoOfStay = (checkout_date.AddDays(1 - checkin_date.DayNumber).DayNumber);
                objBooking.IsPaymentSuccessfull = false;
                objBooking.PaymentDate = DateTime.Parse("1900-01-01");
                objBooking.StripeSessionId = string.Empty;
                objBooking.StripePaymentIntentId = string.Empty;
                objBooking.ActualCheckinDate = DateTime.Parse("1900-01-01");
                objBooking.ActualCheckoutDate = DateTime.Parse("1900-01-01");


                _IWorker.tbl_Booking.Add(objBooking);
                _IWorker.tbl_Booking.Save();

                return Json(new { success = true, message = SD.BookingTransaction.Success, booking = JsonConvert.SerializeObject(objBooking) });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = SD.BookingTransaction.Fail, booking = JsonConvert.SerializeObject(objBooking) });
            }



        }

        [HttpPost]
        public IActionResult ShowPayment(int BookingId)
        {

            if (BookingId == 0)
            {
                return Json(new { success = false, message = "Booking id is null." });
            }          

            var objBooking = _IWorker.tbl_Booking.Get(fw => fw.BookingId == BookingId);

            var objRoom = _IWorker.tbl_Rooms.Get(fw => fw.RoomId == objBooking.RoomId);

            var domain = Request.Scheme + "://" + Request.Host.Value + "/";

            var options = new SessionCreateOptions
            {

                LineItems = new List<SessionLineItemOptions>(),
                CustomFields = new List<SessionCustomFieldOptions>
                {
                    new SessionCustomFieldOptions
                    {
                        Key = "engraving",
                        Label = new SessionCustomFieldLabelOptions
                        {
                            Type ="custom",
                            Custom = "Please find test card number below. Thank you."

                        },
                        Type = "dropdown",
                        Optional = true,

                        Dropdown = new SessionCustomFieldDropdownOptions
                        {

                            Options = new List<SessionCustomFieldDropdownOptionOptions>
                            {
                                new SessionCustomFieldDropdownOptionOptions
                                {
                                    Label = "Visa - [4242 4242 4242 4242]",
                                    Value = "4242424242424242"
                                },
                                new SessionCustomFieldDropdownOptionOptions
                                {
                                    Label = "Visa Debit - [4000 0566 5566 5556]",
                                    Value = "4000056655665556"
                                },
                                new SessionCustomFieldDropdownOptionOptions
                                {
                                    Label = "Mastercard - [5555 5555 5555 4444]",
                                    Value = "5555555555554444"
                                },

                            },

                        },
                    },

                },


                Mode = "payment",
                SuccessUrl = domain + $"Booking/BookingConfirmation?BookingId={objBooking.BookingId}",
                CancelUrl = domain,
                ClientReferenceId = "rolimer_pono@yahoo.com",



                ConsentCollection = new SessionConsentCollectionOptions
                {
                    TermsOfService = "required",
                },
                CustomText = new SessionCustomTextOptions
                {
                    TermsOfServiceAcceptance = new SessionCustomTextTermsOfServiceAcceptanceOptions
                    {
                        Message = "I agree to the [Terms of Service]",
                    },

                },


            };



            options.LineItems.Add(new SessionLineItemOptions
            {

                PriceData = new SessionLineItemPriceDataOptions
                {

                    UnitAmount = (long)(objBooking.TotalCost * 100),
                    Currency = "nzd",

                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = objRoom.RoomName,
                        Description = objRoom.Description,
                        //Images = new List<string> { "https://placehold.co/600x400" } 

                    }

                },
                Quantity = 1,

            });


            var service = new SessionService();
            Session session = service.Create(options);

            _IWorker.tbl_Booking.UpdateStripePaymentID(objBooking.BookingId, session.Id, session.PaymentIntentId);
            _IWorker.tbl_Booking.Save();



            if (!String.IsNullOrEmpty(session.Id))
            {
                return Json(new { success = true, redirectUrl = session.Url, message = SD.BookingTransaction.Success });
            }

            return Json(new { success = false, redirectUrl = session.Url, message = SD.BookingTransaction.Fail + ' ' + session.StripeResponse });

        }

        public IActionResult BookingConfirmation(int BookingId)
        {


            Booking objBooking = _IWorker.tbl_Booking.Get(fw => fw.BookingId == BookingId, IncludeProperties: "Room,User");


            if (BookingId == 0)
            {
                return View("NotSuccess", objBooking);
            }

            objBooking.RoomAmenity = _IWorker.tbl_RoomAmenity.GetAll(fw => fw.RoomId == objBooking.RoomId);


            var iCounter = new Util(_IWorker).GetRoomsAvailableCount(objBooking.RoomId, objBooking.CheckinDate, objBooking.CheckoutDate);


            if (iCounter == 0)
            {
                return View("NotSuccess", objBooking);
            }


            if (objBooking.BookingStatus == SD.BookingStatus.Pending.ToString())
            {


                var service = new SessionService();
                Session session = service.Get(objBooking.StripeSessionId);

                if (!String.IsNullOrEmpty(session.PaymentIntentId))
                {

                    if (session.PaymentStatus == "paid")
                    {
                        _IWorker.tbl_Booking.UpdateBookingStatus(objBooking.BookingId, SD.BookingStatus.Approved.ToString(), 0);
                        _IWorker.tbl_Booking.UpdateStripePaymentID(objBooking.BookingId, session.Id, session.PaymentIntentId);
                        _IWorker.tbl_Booking.Save();

                        Email objEmail = new Email();
                        objEmail.SenderMail = "sycopons2010@gmail.com";
                        objEmail.SenderName = "THE KWANO";
                        objEmail.RecieverName = objBooking.UserName;
                        objEmail.RecieverEmail = objBooking.UserEmail;
                        objEmail.Subject = "THE KWANO BOOKING";                      

                        PartialViewResult pvr = PartialView("BookingConfirmation", objBooking);
                        string html_result_string = _helper.ViewToString(this.ControllerContext, pvr, _viewEngine);
                        objEmail.HtmlContent = html_result_string;

                        Boolean is_success = SD.MailSend(objEmail);
                        
                        ViewBag.IsMessageSend = is_success;

                        return View(objBooking);
                    }

                }
                return View("NotSuccess", objBooking);

            }
            return View("NotSucces", objBooking);
        }

      

    }

}
