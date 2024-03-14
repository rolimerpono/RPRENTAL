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
    public  class ROOMNUMBER
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ROOM_NUMBER { get; set; }

        //RELATIONSHIP//

        [ForeignKey(nameof(ROOM_ID))]
        public int ROOM_ID { get; set; }

        [ValidateNever]

        public Room? ROOM { get;set; }

        //
        public string? DESCRIPTION { get; set; }


    }
}
