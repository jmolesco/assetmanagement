using AM.Core.Helper.Lengths;
using System.ComponentModel.DataAnnotations;

namespace AM.API.DTOs.Sizes.VideoCard
{
    public class AddVideoCard
    {

        [Required]
        [MaxLength(MaxLengthHelper.VideoCardSizeMaxLength)]
        public string Size { get; set; }

    }
}
