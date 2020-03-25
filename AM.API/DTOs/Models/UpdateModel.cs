using AM.Core.Helper.Lengths;
using System.ComponentModel.DataAnnotations;

namespace AM.API.DTOs.Models
{
    public class UpdateModel
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLengthHelper.ModelNameMaxLength)]
        public string Name { get; set; }

    }
}
