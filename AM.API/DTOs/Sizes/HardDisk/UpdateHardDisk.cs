using AM.Core.Helper.Lengths;
using System.ComponentModel.DataAnnotations;

namespace AM.API.DTOs.Sizes.HardDisk
{
    public class UpdateHardDisk
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLengthHelper.HardDiskSizeMaxLength)]
        public string Size { get; set; }

    }
}
