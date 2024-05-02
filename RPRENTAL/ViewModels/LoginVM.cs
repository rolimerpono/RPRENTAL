using Microsoft.AspNetCore.Antiforgery;
using System.ComponentModel.DataAnnotations;

namespace RPRENTAL.ViewModels
{
    public class LoginVM
    {
        [Required]       
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        public Boolean IsRemember { get; set; } = false;
        public string? RedirectUrl { get; set; }
    }
}
