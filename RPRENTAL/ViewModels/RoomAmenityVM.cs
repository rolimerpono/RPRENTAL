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
            ROOM_ID = 0;
            ROOM_NAME = string.Empty;
            AMENITIES = new List<Amenity>();


        }

 

        [ValidateNever]
        public int ROOM_ID { get; set; }
        public string ROOM_NAME { get; set; }

       
        public List<Amenity> AMENITIES { get; set; }
        public List<Room> ROOM_LIST { get; set; }

        public List<RoomAmenity> ROOM_AMENITY { get; set; }



     

      
    }
}
