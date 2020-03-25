using AM.Core.Helper.Lengths;
using System.ComponentModel.DataAnnotations;

namespace AM.Core.Domain.Sizes
{
    public class Memory : BaseDomain
    {

        [Required]
        [MaxLength(MaxLengthHelper.MemorySizeMaxLength)]
        public string Size { get; set; }

    }
}
