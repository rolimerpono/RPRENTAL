using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ApplicationUser : IdentityUser
    {

        public string USER_NAME { get; set; }

        public DateTime? CREATED_DATE { get; set; } 

    }
}
