using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        }

        [Key]
        public int ID { get; set; }

        public string AMENITY_NAME { get; set; }        


    }
}
