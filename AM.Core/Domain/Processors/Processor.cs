using AM.Core.Helper.Lengths;
using System.ComponentModel.DataAnnotations;

namespace AM.Core.Domain.Processors
{
    public class Processor : BaseDomain
    {

        [Required]
        [MaxLength(MaxLengthHelper.ProcessorNameMaxLength)]
        public string Name { get; set; }

    }
}
