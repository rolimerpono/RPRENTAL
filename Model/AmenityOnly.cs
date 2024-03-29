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
    public class AmenityOnly
    {
        public AmenityOnly()
        {
            ID = 0;
            AMENITY_NAME = string.Empty;
            IS_CHECK = false;
       
        }

        [Key]
        public int ID { get; set; }

        public string AMENITY_NAME { get; set; }

        [NotMapped]
        [ValidateNever]
        public Boolean IS_CHECK { get; set; }


    }
}
