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
    public  class RoomNumber
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoomNo { get; set; }

        public string? Description { get; set; }


        [ForeignKey("Room")]     
        public int RoomId { get; set; }

        [ValidateNever]
        public Room? Room { get;set; }        

    }
}
