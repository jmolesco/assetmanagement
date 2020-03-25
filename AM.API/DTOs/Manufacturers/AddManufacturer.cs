using AM.Core.Helper.Lengths;
using System.ComponentModel.DataAnnotations;

namespace AM.API.DTOs.Manufacturers
{
    public class AddManufacturer
    {

        [Required]
        [MaxLength(MaxLengthHelper.ManufacturerNameMaxLength)]
        public string Name { get; set; }
        
    }
}
