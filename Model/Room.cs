using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Model
{
    public class Room
    {
        public Room()
        {          
            Description = "";
            RoomName = "";
            RoomPrice = 0;
            MaxOccupancy = 0;
            ImageUrl = "https://placehold.co/600x400";      
            CreatedDate = DateTime.Now;           
        }


        [Key]
        public int RoomId { get; set; }   

        [Required]
        public string RoomName { get; set; }

        public string? Description { get; set; } = "";

        [Range(10,150)]
        public required double RoomPrice { get; set; }

     
        [Range(1,10)]
        public required int MaxOccupancy { get; set; }

        public string? ImageUrl { get; set; }

 
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

        [ValidateNever]
        public IEnumerable<RoomAmenity> RoomAmenities { get; set; }

        [ValidateNever]
        [NotMapped]
        public IFormFile? Image { get; set; }

        [NotMapped]
        public Boolean IsRoomAvailable { get; set; } = true;

        [NotMapped]
        public DateOnly? CheckinDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [NotMapped]
        public DateOnly? CheckoutDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

     
    }
}
