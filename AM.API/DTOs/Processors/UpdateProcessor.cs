using AM.Core.Helper.Lengths;
using System.ComponentModel.DataAnnotations;

namespace AM.API.DTOs.Processors
{
    public class UpdateProcessor
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLengthHelper.ProcessorNameMaxLength)]
        public string Name { get; set; }

    }
}
