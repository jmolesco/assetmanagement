using AM.Core.Helper.Lengths;
using System.ComponentModel.DataAnnotations;

namespace AM.API.DTOs.Sizes.VideoCard
{
    public class UpdateVideoCard
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLengthHelper.VideoCardSizeMaxLength)]
        public string Size { get; set; }

    }
}
