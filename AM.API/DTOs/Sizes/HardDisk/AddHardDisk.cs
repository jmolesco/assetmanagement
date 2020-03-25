using AM.Core.Helper.Lengths;
using System.ComponentModel.DataAnnotations;

namespace AM.API.DTOs.Sizes.HardDisk
{
    public class AddHardDisk
    {

        [Required]
        [MaxLength(MaxLengthHelper.HardDiskSizeMaxLength)]
        public string Size { get; set; }

    }
}
