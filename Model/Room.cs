using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Room
    {
        public Room()
        {
            ROOM_ID = 0;
            DESCRIPTION = "";
            ROOM_NAME = "";
            ROOM_PRICE = 0;
            MAX_OCCUPANCY = 0;
            IMAGE_URL = "https://placehold.co/600x400";
            CREATED_DATE = DateTime.Now;
        }


        [Key]
        public int ROOM_ID { get; set; }


        [Display(Name = "ROOM NAME")]
        [Required(ErrorMessage = "Please provide a room name.")]
        public string ROOM_NAME { get; set; }

        public string? DESCRIPTION { get; set; } = "";

        [Display(Name = "PRICE")]
        [Range(10,100)]
        public required double ROOM_PRICE { get; set; }


        [Display(Name = "OCCUPANCY")]
        [Range(1,10)]
        public required int MAX_OCCUPANCY { get; set; }

        public string? IMAGE_URL { get; set; }

        [NotMapped]
        public IFormFile? IMAGE { get; set; }

        public DateTime? CREATED_DATE { get; set; } = DateTime.Now;

        public DateTime? UPDATED_DATE { get; set; } = DateTime.Now;

        [ValidateNever]
        public IEnumerable<Amenity> ROOM_AMENITIES { get; set; }

        [NotMapped]
        public Boolean IS_ROOM_AVAILABLE { get; set; } = true;

        [NotMapped]
        public DateOnly? CHECKIN_DATE { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [NotMapped]
        public DateOnly? CHECKOUT_DATE { get; set; } = DateOnly.FromDateTime(DateTime.Now);

     
    }
}
