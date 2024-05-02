using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace RPRENTAL.ViewModels
{
    public class AmenityVM
    {
        public AmenityVM()
        {
            Id = 0;
            AmenityName = string.Empty;
        }
        public int Id { get; set; }
        public String AmenityName { get; set; }

      

    }
}
