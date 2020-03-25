using AM.Core.Helper.Lengths;
using System.ComponentModel.DataAnnotations;

namespace AM.Core.Domain.Suppliers
{
    public class Supplier : BaseDomain
    {

        [Required]
        [MaxLength(MaxLengthHelper.SupplierNameMaxLength)]
        public string Name { get; set; }

    }
}
