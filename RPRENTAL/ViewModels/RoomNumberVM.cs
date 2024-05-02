using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;

namespace RPRENTAL.ViewModels
{
    public class RoomNumberVM
    {
        [ValidateNever]
        public RoomNumber? RoomNumber { get;set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? RoomList { get; set; }

    }
}
