using AM.Core.Helper.Lengths;
using System.ComponentModel.DataAnnotations;

namespace AM.API.DTOs.Categories
{
    public class AddCategory
    {

        [Required]
        [MaxLength(MaxLengthHelper.CategoryNameMaxLength)]
        public string Name { get; set; }

    }
}
