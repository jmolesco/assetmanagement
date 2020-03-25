using AM.Core.Domain.Assets;
using AM.Core.Helper.Lengths;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AM.API.DTOs.Assets
{
    public class AddAsset
    {

        #region Foreign Keys

        /// <summary>
        /// Supplier.Id
        /// </summary>
        [DisplayName("Supplier")]
        public int? SupplierId { get; set; }

        /// <summary>
        /// Model.Id
        /// </summary>
        [Required]
        [DisplayName("Model")]
        public int? ModelId { get; set; }

        /// <summary>
        /// Processor.Id
        /// </summary>
        [DisplayName("Processor")]
        public int? ProcessorId { get; set; }

        /// <summary>
        /// Memory.Id
        /// </summary>
        [DisplayName("Memory Size")]
        public int? MemoryId { get; set; }

        /// <summary>
        /// VideoCard.Id
        /// </summary>
        [DisplayName("Video Card Size")]
        public int? VideoCardId { get; set; }

        /// <summary>
        /// HardDisk.Id
        /// </summary>
        [DisplayName("Hard Disk Size")]
        public int? HardDiskId { get; set; }

        /// <summary>
        /// Manufacturer.Id
        /// </summary>
        [DisplayName("Manufacturer")]
        public int? ManufacturerId { get; set; }

        /// <summary>
        /// Category.Id
        /// </summary>
        [DisplayName("Category")]
        public int? CategoryId { get; set; }

        #endregion

        [MaxLength(MaxLengthHelper.SerialNoMaxLength)]
        public string SerialNo { get; set; }

        [Required]
        [MaxLength(MaxLengthHelper.AssetTagMaxLength)]
        public string AssetTag { get; set; }

        [MaxLength(MaxLengthHelper.BatteryMaxLength)]
        public string Battery { get; set; }

        [MaxLength(MaxLengthHelper.AdapterMaxLength)]
        public string Adapter { get; set; }

        [Required]
        [DisplayName("Asset Name")]
        [MaxLength(MaxLengthHelper.AssetNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(MaxLengthHelper.AssignedToMaxLength)]
        public string AssignedTo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DeliveryDate { get; set; }

        [MaxLength(MaxLengthHelper.PONoMaxLength)]
        public string PONo { get; set; }

        [MaxLength(MaxLengthHelper.DRNoMaxLength)]
        public string DRNo { get; set; }

        [MaxLength(MaxLengthHelper.SINoMaxLength)]
        public string SINo { get; set; }

        [MaxLength(MaxLengthHelper.MacAddressMaxLength)]
        public string MacAddress { get; set; }

        [MaxLength(MaxLengthHelper.IPAddressMaxLength)]
        public string IPAddress { get; set; }

        [Required]
        public StatusType? Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PurchaseDate { get; set; }

        public decimal? PurchaseCost { get; set; }

        [MaxLength(MaxLengthHelper.WarrantyMaxLength)]
        public string Warranty { get; set; }

        [MaxLength(MaxLengthHelper.NotesMaxLength)]
        public string Notes { get; set; }

    }
}
