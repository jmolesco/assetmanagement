using AM.Core.Domain.Categories;
using AM.Core.Domain.Manufacturers;
using AM.Core.Domain.Models;
using AM.Core.Domain.Processors;
using AM.Core.Domain.Sizes;
using AM.Core.Domain.Suppliers;
using AM.Core.Helper.Lengths;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AM.Core.Domain.Assets
{
    public class Asset : BaseDomain
    {

        #region Foreign Keys

        /// <summary>
        /// Supplier.Id
        /// </summary>
        public int? SupplierId { get; set; }

        /// <summary>
        /// Model.Id
        /// </summary>
        [Required]
        public int? ModelId { get; set; }

        /// <summary>
        /// Processor.Id
        /// </summary>
        public int? ProcessorId { get; set; }

        /// <summary>
        /// Memory.Id
        /// </summary>
        public int? MemoryId { get; set; }

        /// <summary>
        /// VideoCard.Id
        /// </summary>
        public int? VideoCardId { get; set; }

        /// <summary>
        /// HardDisk.Id
        /// </summary>
        public int? HardDiskId { get; set; }

        /// <summary>
        /// Manufacturer.Id
        /// </summary>
        public int? ManufacturerId { get; set; }

        /// <summary>
        /// Category.Id
        /// </summary>
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

        #region Navigation Properties

        public Supplier Supplier { get; set; }

        public Model Model { get; set; }

        public Processor Processor { get; set; }

        public Memory Memory { get; set; }

        public VideoCard VideoCard { get; set; }

        public HardDisk HardDisk { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public Category Category { get; set; }

        #endregion

    }
}
