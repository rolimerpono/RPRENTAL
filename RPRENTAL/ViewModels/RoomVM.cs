using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Model;

namespace RPRENTAL.ViewModels
{
    public class RoomVM
    {
        [ValidateNever]
        public Room? ROOM { get; set; }       

        
    }
}
