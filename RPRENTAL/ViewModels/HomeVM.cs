using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RPRENTAL.ViewModels
{
    public class HomeVM
    {

        public int RoomId { get; set; }

        public string RoomName { get; set; }

        public string? Description { get; set; }

        public required double RoomPrice { get; set; }
    
        public required int MaxOccupancy { get; set; }

        public string? ImageUrl { get; set; }

        public IFormFile? Image { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public IEnumerable<RoomAmenity>? RoomAmenities { get; set; }
            
        public Boolean IsRoomAvailable { get; set; } = true;
    
        public DateOnly? CheckinDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public DateOnly? CheckoutDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);


    }
}
