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
    public class Amenity
    {
        public Amenity()
        {
            AmenityId = 0;
            AmenityName = string.Empty;
            IsCheck = false;
       
        }

        [Key]       
        public int AmenityId { get; set; }

        public string AmenityName { get; set; }

        [NotMapped]
        [ValidateNever]
        public Boolean IsCheck { get; set; }


    }
}
