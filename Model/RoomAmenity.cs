using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RoomAmenity
    {
     

        [Key]
        public int ID { get; set; }
   
        public int ROOM_ID { get; set; }

        [ForeignKey("AMENITY")]
        public int AMENITY_ID { get; set; }

        [ValidateNever]

        public AmenityOnly? AMENITY { get; set; }

  

       
    }
}
