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
        public string EMAIL { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string PASSWORD { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string CONFIRM_PASSWORD { get; set; }

        [Required]
        public string NAME { get; set; }
        public string? PHONE_NUBMER { get; set; }
        public string? REDIRECT_URL { get; set; }

        public string? ROLE { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? ROLE_LIST { get; set; }


    }
}
