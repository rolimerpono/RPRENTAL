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
            ROOM_LIST = new List<Room>();
            ROOM_AMENITY = new List<AmenityOnly>();
        }


        [ValidateNever]
        public IEnumerable<Room> ROOM_LIST { get; set; }

        [ValidateNever]    
        public IEnumerable<AmenityOnly> ROOM_AMENITY { get; set; }

        [ValidateNever]
        public Boolean IS_CHECK { get; set; }

      
    }
}
