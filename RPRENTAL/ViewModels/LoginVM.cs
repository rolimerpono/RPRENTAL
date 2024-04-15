using Microsoft.AspNetCore.Antiforgery;
using System.ComponentModel.DataAnnotations;

namespace RPRENTAL.ViewModels
{
    public class LoginVM
    {
        [Required]       
        public string EMAIL { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string PASSWORD { get; set; }

        public Boolean IS_REMEMBER { get; set; } = false;
        public string? REDIRECT_URL { get; set; }
    }
}
