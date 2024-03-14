using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Room
    {

        [Key]
        public int ROOM_ID { get; set; }

        public required string ROOM_NAME { get; set; }

        public string? DESCRIPTION { get; set; }

        public double ROOM_PRICE { get; set; }

        public int MAX_OCCUPANCY { get; set; }

        public string? IMAGE_URL { get; set; }

        [NotMapped]
        public IFormFile? IMAGE { get; set; }

        public DateTime? CREATED_DATE { get; set; }

        public DateTime? UPDATED_DATE { get; set; }

        [ValidateNever]
        public IEnumerable<Amenity> ROOM_AMENITIES { get; set; }

        [NotMapped]
        public Boolean IS_ROOM_AVAILABLE { get; set; }

        


    }
}
