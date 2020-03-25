using AM.API.DTOs.Assets;
using AM.API.Helpers;
using AM.Core.Domain.Assets;
using AM.Core.Helper.Extensions;
using AM.Core.Helper.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AM.API.Services.Assets
{
    public class AssetService : IAssetService
    {

        private readonly DataContext _context;

        public AssetService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public object Add(Asset asset)
        {
            _context.Assets.Add(asset);
            _context.SaveChanges();

            return new SuccessResponse();
        }

        public object GetAll(GetAll criteria, AppSettings appSettings)
        {
            var records = _context.Assets.AsNoTracking()
                                  .Include(p => p.Supplier).AsNoTracking()
                                  .Include(p => p.Model).AsNoTracking()
                                  .Include(p => p.Processor).AsNoTracking()
                                  .Include(p => p.Memory).AsNoTracking()
                                  .Include(p => p.VideoCard).AsNoTracking()
                                  .Include(p => p.HardDisk).AsNoTracking()
                                  .Include(p => p.Manufacturer).AsNoTracking()
                                  .Include(p => p.Category).AsNoTracking()
                                  .Select(p => new
                                  {
                                      p.Id,
                                      p.SerialNo,
                                      p.AssetTag,
                                      p.Battery,
                                      p.Adapter,
                                      p.Name,
                                      p.AssignedTo,
                                      p.DeliveryDate,
                                      p.SupplierId,
                                      SupplierName = p.Supplier.Name,
                                      p.ModelId,
                                      ModelName = p.Model.Name,
                                      p.ProcessorId,
                                      ProcessorName = p.Processor.Name,
                                      p.MemoryId,
                                      MemorySize = p.Memory.Size,
                                      p.VideoCardId,
                                      VideoCardSize = p.VideoCard.Size,
                                      p.HardDiskId,
                                      HardDiskSize = p.HardDisk.Size,
                                      p.PONo,
                                      p.DRNo,
                                      p.SINo,
                                      p.MacAddress,
                                      p.IPAddress,
                                      p.Status,
                                      StatusType = EnumExtension.GetName(Enum.GetName(typeof(StatusType), p.Status)),
                                      p.ManufacturerId,
                                      ManufacturerName = p.Manufacturer.Name,
                                      p.CategoryId,
                                      CategoryName = p.Category.Name,
                                      p.PurchaseDate,
                                      p.PurchaseCost,
                                      p.Warranty,
                                      p.Notes
                                  });

            //  Check if keyword is specified
            if(criteria.Keyword.HasValue())
            {

                //  Check if keyword length is more than 3 characters
                if (criteria.Keyword.Count() >= 3)
                {

                    //  Search records by keyword
                    records = records.Where
                                (
                                    p =>

                                    p.SerialNo.Contains(criteria.Keyword) ||

                                    p.AssetTag.Contains(criteria.Keyword) ||

                                    p.Battery.Contains(criteria.Keyword) ||

                                    p.Adapter.Contains(criteria.Keyword) ||

                                    p.Name.Contains(criteria.Keyword) ||

                                    p.AssignedTo.Contains(criteria.Keyword) ||

                                    p.SupplierName.Contains(criteria.Keyword) ||

                                    p.ModelName.Contains(criteria.Keyword) ||

                                    p.ProcessorName.Contains(criteria.Keyword) ||

                                    p.MemorySize.Contains(criteria.Keyword) ||

                                    p.VideoCardSize.Contains(criteria.Keyword) ||

                                    p.HardDiskSize.Contains(criteria.Keyword) ||

                                    p.PONo.Contains(criteria.Keyword) ||

                                    p.DRNo.Contains(criteria.Keyword) ||

                                    p.SINo.Contains(criteria.Keyword) ||

                                    p.MacAddress.Contains(criteria.Keyword) ||

                                    p.IPAddress.Contains(criteria.Keyword) ||

                                    p.ManufacturerName.Contains(criteria.Keyword) ||

                                    p.CategoryName.Contains(criteria.Keyword) ||

                                    p.Warranty.Contains(criteria.Keyword) ||

                                    p.Notes.Contains(criteria.Keyword)
                                );
                }
            }

            //  Check if orderby is defined
            if(criteria.OrderBy.HasValue)
            {

                //  Order records based on the orderby & ordertype parameters 
                //  set by the user

                if (criteria.OrderBy == OrderBy.Id)
                {
                    if (criteria.OrderType == OrderType.Descending)
                    {
                        records = records.OrderByDescending(p => p.Id);
                    }
                    else
                    {
                        records = records.OrderBy(p => p.Id);
                    }
                }
                else if (criteria.OrderBy == OrderBy.AssetTag)
                {
                    if (criteria.OrderType == OrderType.Descending)
                    {
                        records = records.OrderByDescending(p => p.AssetTag);
                    }
                    else
                    {
                        records = records.OrderBy(p => p.AssetTag);
                    }
                }
                else if (criteria.OrderBy == OrderBy.Name)
                {
                    if (criteria.OrderType == OrderType.Descending)
                    {
                        records = records.OrderByDescending(p => p.Name);
                    }
                    else
                    {
                        records = records.OrderBy(p => p.Name);
                    }
                }
                else if (criteria.OrderBy == OrderBy.Status)
                {
                    if (criteria.OrderType == OrderType.Descending)
                    {
                        records = records.OrderByDescending(p => p.Status);
                    }
                    else
                    {
                        records = records.OrderBy(p => p.Status);
                    }
                }
            }

            GetAllResponse response = null;

            //  Check if user don't want to show all records
            if (criteria.ShowAll == false)
            {
                response = new GetAllResponse(records.Count(), criteria.CurrentPage, appSettings.RecordDisplayPerPage);

                //  Check if CurrentPage is greater than TotalPage
                if (criteria.CurrentPage > response.TotalPage)
                {
                    var error = new ErrorResponse();
                    error.ErrorMessages.Add(MessageHelper.NoRecordFound);

                    //  Return no record found error
                    return error;
                }

                records = records.Skip((criteria.CurrentPage - 1) * appSettings.RecordDisplayPerPage)
                                    .Take(appSettings.RecordDisplayPerPage);
            }
            else
            {
                response = new GetAllResponse(records.Count());
            }

            response.List.AddRange(records);

            return response;
        }

        public object GetById(int id)
        {
            var record = _context.Assets.AsNoTracking()
                                 .Include(p => p.Supplier).AsNoTracking()
                                 .Include(p => p.Model).AsNoTracking()
                                 .Include(p => p.Processor).AsNoTracking()
                                 .Include(p => p.Memory).AsNoTracking()
                                 .Include(p => p.VideoCard).AsNoTracking()
                                 .Include(p => p.HardDisk).AsNoTracking()
                                 .Include(p => p.Manufacturer).AsNoTracking()
                                 .Include(p => p.Category).AsNoTracking()
                                 .Where(p => p.Id == id)
                                 .Select(p => new
                                 {
                                     p.Id,
                                     p.SerialNo,
                                     p.AssetTag,
                                     p.Battery,
                                     p.Adapter,
                                     p.Name,
                                     p.AssignedTo,
                                     p.DeliveryDate,
                                     p.SupplierId,
                                     SupplierName = p.Supplier.Name,
                                     p.ModelId,
                                     ModelName = p.Model.Name,
                                     p.ProcessorId,
                                     ProcessorName = p.Processor.Name,
                                     p.MemoryId,
                                     MemorySize = p.Memory.Size,
                                     p.VideoCardId,
                                     VideoCardSize = p.VideoCard.Size,
                                     p.HardDiskId,
                                     HardDiskSize = p.HardDisk.Size,
                                     p.PONo,
                                     p.DRNo,
                                     p.SINo,
                                     p.MacAddress,
                                     p.IPAddress,
                                     p.Status,
                                     StatusType = EnumExtension.GetName(Enum.GetName(typeof(StatusType), p.Status)),
                                     p.ManufacturerId,
                                     ManufacturerName = p.Manufacturer.Name,
                                     p.CategoryId,
                                     CategoryName = p.Category.Name,
                                     p.PurchaseDate,
                                     p.PurchaseCost,
                                     p.Warranty,
                                     p.Notes
                                 })
                                 .FirstOrDefault();

            if (record != null)
            {
                return record;
            }

            var error = new ErrorResponse();
            error.ErrorMessages.Add(MessageHelper.RecordNotFound);

            return error;
        }

        public object Update(int id, UpdateAsset updateAsset, IMapper mapper)
        {

            var asset = _context.Assets.AsNoTracking()
                                       .Where(p => p.Id == id)
                                       .FirstOrDefault();

            if (asset == null)
            {
                var error = new ErrorResponse();
                error.ErrorMessages.Add(MessageHelper.RecordToBeUpdatedNotFound);

                return error;
            }
            else
            {
                var mappedAsset = mapper.Map(updateAsset, asset);
                mappedAsset.DateUpdated = DateTime.Now;

                _context.Update(mappedAsset);
                _context.SaveChanges();

                return new SuccessResponse();
            }

        }

    }
}
