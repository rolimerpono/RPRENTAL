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
        public int AMENITY_ID { get; set; }        

        public required string AMENITY_NAME { get; set;}

        public string? DESCRIPTION { get; set; }

        [ForeignKey(nameof(ROOM_ID))]
        public int ROOM_ID { get; set; }

        [ValidateNever]
        public Room ROOM { get; set; }
    }
}
