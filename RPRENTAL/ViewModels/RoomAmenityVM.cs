using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using System.Runtime.InteropServices;

namespace RPRENTAL.ViewModels
{
    public class RoomAmenityVM
    {

        public RoomAmenityVM()
        {
            RoomId = 0;
            RoomName = string.Empty;
            Amenities = new List<Amenity>();


        }

 

        [ValidateNever]
        public int RoomId { get; set; }
        public string RoomName { get; set; }
       
        public List<Amenity> Amenities { get; set; }
        public List<Room> RoomList { get; set; }
        public List<RoomAmenity> RoomAmenity { get; set; }



     

      
    }
}
