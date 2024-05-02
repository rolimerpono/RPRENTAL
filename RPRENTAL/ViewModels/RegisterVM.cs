using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace RPRENTAL.ViewModels
{
    public class RegisterVM
    {
      
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }     
        [Required]

        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Fullname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? RedirectUrl { get; set; }

        public string? Role { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? RoleList { get; set; }


    }
}
