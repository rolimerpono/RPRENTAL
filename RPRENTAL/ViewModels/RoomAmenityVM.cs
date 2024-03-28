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
            AMENITIES = new List<AmenityOnly>();


        }

 

        [ValidateNever]
        public int ROOM_ID { get; set; }
        public string ROOM_NAME { get; set; }

        public List<AmenityOnly> AMENITIES { get; set; }



     

      
    }
}
