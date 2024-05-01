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
    public class ResetPassword
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }


        [ValidateNever]
        [NotMapped]
        public string Password { get; set; }


        [ValidateNever]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public string OTP { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;        

    }
}
