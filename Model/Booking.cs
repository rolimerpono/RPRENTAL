using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Booking
    {
        public Booking()
        {
            NoOfStay = (CheckinDate.AddDays(1 - CheckoutDate.DayNumber).DayNumber);
        }

        [Key]
        public int  BookingId { get;set; }



        [ForeignKey("User")]
        [Required]
        public string UserId { get; set; }

        public ApplicationUser? User { get; set; }


        [ForeignKey("Room")]
        [Required]
        public int RoomId { get;set; }    
        public Room? Room { get;set; }      

        public int RoomNo { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string UserEmail { get; set;}

        public string? PhoneNumber { get; set; }

        [Required]
        public double TotalCost { get; set; }      

        public string? BookingStatus { get; set; }

        [Required]
        public  DateTime BookingDate { get; set; } = DateTime.Now;


        [Required]
        public DateOnly CheckinDate { get; set; }

        [Required]
        public  DateOnly CheckoutDate { get; set; }

        [ValidateNever]
        public int NoOfStay { get; set; }

        public Boolean IsPaymentSuccessfull { get; set; } = false;

        public DateTime PaymentDate { get; set; } 

        public string? StripeSessionId { get; set; }

        public string? StripePaymentIntentId { get; set; }

        public DateTime ActualCheckinDate { get; set; }

        public DateTime ActualCheckoutDate { get; set; }

        public DateTime ActualCancelledDate { get; set; }
      
        [NotMapped]
        public IEnumerable<RoomAmenity> RoomAmenity { get; set; }

        [ValidateNever]
        [NotMapped]
        public List<string> RoomNumberList { get; set; }

     















    }
}
