using AM.Core.Helper.Lengths;
using System.ComponentModel.DataAnnotations;

namespace AM.Core.Domain.Manufacturers
{
    public class Manufacturer : BaseDomain
    {

        [Required]
        [MaxLength(MaxLengthHelper.ManufacturerNameMaxLength)]
        public string Name { get; set; }
        
    }
}
