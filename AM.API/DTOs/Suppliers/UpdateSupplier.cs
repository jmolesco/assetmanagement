using AM.Core.Helper.Lengths;
using System.ComponentModel.DataAnnotations;

namespace AM.API.DTOs.Suppliers
{
    public class UpdateSupplier
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLengthHelper.SupplierNameMaxLength)]
        public string Name { get; set; }

    }
}
