using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RPRENTAL.ViewModels
{
    public class HomeVM
    {

        public int ROOM_ID { get; set; }

        public string ROOM_NAME { get; set; }

        public string? DESCRIPTION { get; set; }

        public required double ROOM_PRICE { get; set; }
    
        public required int MAX_OCCUPANCY { get; set; }

        public string? IMAGE_URL { get; set; }


        public IFormFile? IMAGE { get; set; }

        public DateTime? CREATED_DATE { get; set; }

        public DateTime? UPDATED_DATE { get; set; }


        public IEnumerable<Amenity> ROOM_AMENITIES { get; set; }


        public Boolean IS_ROOM_AVAILABLE { get; set; } = true;

    
        public DateOnly? CHECKIN_DATE { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public DateOnly? CHECKOUT_DATE { get; set; } = DateOnly.FromDateTime(DateTime.Now);


    }
}
