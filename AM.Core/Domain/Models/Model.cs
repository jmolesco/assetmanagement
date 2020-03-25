using AM.Core.Helper.Lengths;
using System.ComponentModel.DataAnnotations;

namespace AM.Core.Domain.Models
{
    public class Model : BaseDomain
    {

        [Required]
        [MaxLength(MaxLengthHelper.ModelNameMaxLength)]
        public string Name { get; set; }

    }
}
