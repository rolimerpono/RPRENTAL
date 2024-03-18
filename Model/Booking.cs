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
        [Key]
        public int  BOOKING_ID { get;set; }

     
        public required string USER_ID { get;set; }


        [ForeignKey(nameof(USER_ID))]
        public ApplicationUser? USERS { get; set; }


        public required int ROOM_ID { get;set; }

        [ForeignKey("ROOM_ID")]
        public Room? ROOM { get;set; }

        public int ROOM_NUMBER { get; set; }

        public required string USER_NAME { get; set; }

        public required string USER_EMAIL { get; set;}

        public string? PHONE_NUMBER { get; set; }

        public required double TOTAL_COST { get; set; }

        [NotMapped]
        public int  NO_OF_STAY { get; set; }

        public string? BOOKING_STATUS { get; set; }

        public required DateTime BOOKING_DATE { get; set; } = DateTime.Now;

        public required DateOnly CHECK_IN_DATE { get; set; }

        public required  DateOnly CHECK_OUT_DATE { get; set; } 

        public Boolean IS_PAYMENT_SUCCESSFULL { get; set; } = false;

        public DateTime PAYMENT_DATE { get; set; } 

        public string? STRIPE_SESSION_ID { get; set; }

        public string? STRIPE_PAYEMENT_INTENT_ID { get; set; }

        public DateTime ACTUAL_CHECK_IN_DATE { get; set; }

        public DateTime ACTUAL_CHECK_OUT_DATE { get; set; }

        [NotMapped]
        public List<String>? ROOM_NUMBER_LIST { get; set; }















    }
}
