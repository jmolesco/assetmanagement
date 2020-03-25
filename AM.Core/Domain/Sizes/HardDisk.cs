using AM.Core.Helper.Lengths;
using System.ComponentModel.DataAnnotations;

namespace AM.Core.Domain.Sizes
{
    public class HardDisk : BaseDomain
    {

        [Required]
        [MaxLength(MaxLengthHelper.HardDiskSizeMaxLength)]
        public string Size { get; set; }

    }
}
