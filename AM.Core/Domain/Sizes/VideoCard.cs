using AM.Core.Helper.Lengths;
using System.ComponentModel.DataAnnotations;

namespace AM.Core.Domain.Sizes
{
    public class VideoCard : BaseDomain
    {

        [Required]
        [MaxLength(MaxLengthHelper.VideoCardSizeMaxLength)]
        public string Size { get; set; }

    }
}
