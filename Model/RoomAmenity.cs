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

        [ForeignKey("ROOMS")]
        public int ROOM_ID { get; set; }

        [ValidateNever]
        public Room? ROOMS { get; set; }


        [ForeignKey("AMENITY")]
        [Required]
        public int AMENITY_ID { get; set; }
     
        public Amenity? AMENITY { get; set; }

        [ValidateNever]
        [NotMapped]
        public string? AMENITY_NAME { get; set; }


      


    }
}
