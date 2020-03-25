using AM.Core.Helper.Lengths;
using System.ComponentModel.DataAnnotations;

namespace AM.Core.Domain.Categories
{
    public class Category : BaseDomain
    {

        [Required]
        [MaxLength(MaxLengthHelper.CategoryNameMaxLength)]
        public string Name { get; set; }

    }
}
