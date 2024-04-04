using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace RPRENTAL.ViewModels
{
    public class AmenityVM
    {
        public AmenityVM()
        {
            ID = 0;
            AMENITY_NAME = string.Empty;
        }
        public int ID { get; set; }
        public String AMENITY_NAME { get; set; }

      

    }
}
