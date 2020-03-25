using AM.Core.Helper.Lengths;
using System.ComponentModel.DataAnnotations;

namespace AM.API.DTOs.Models
{
    public class AddModel
    {

        [Required]
        [MaxLength(MaxLengthHelper.ModelNameMaxLength)]
        public string Name { get; set; }

    }
}
