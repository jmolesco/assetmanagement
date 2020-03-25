using AM.Core.Helper.Lengths;
using System.ComponentModel.DataAnnotations;

namespace AM.API.DTOs.Categories
{
    public class UpdateCategory
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLengthHelper.CategoryNameMaxLength)]
        public string Name { get; set; }

    }
}
