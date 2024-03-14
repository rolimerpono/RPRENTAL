using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public  class Amenity
    {

       [Key]    
        public int AMENITY_ID { get; set; }        

        public required string AMENITY_NAME { get; set;}

        public string? DESCRIPTION { get; set; }

      
        public int ROOM_ID { get; set; }

     
        [ForeignKey("ROOM_ID")]
        [ValidateNever]
        public Room? ROOM { get; set; }
    }
}
