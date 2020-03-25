using AM.Core.Helper.Lengths;
using System.ComponentModel.DataAnnotations;

namespace AM.API.DTOs.Sizes.Memory
{
    public class AddMemory
    {

        [Required]
        [MaxLength(MaxLengthHelper.MemorySizeMaxLength)]
        public string Size { get; set; }

    }
}
