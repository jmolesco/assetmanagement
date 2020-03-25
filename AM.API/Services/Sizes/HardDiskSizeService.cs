using AM.API.Helpers;
using AM.Core.Domain.Sizes;
using AM.Core.Helper.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using AM.API.DTOs.Sizes.HardDisk;

namespace AM.API.Services.Sizes
{
    public class HardDiskSizeService : IHardDiskSizeService
    {

        private readonly DataContext _context;

        public HardDiskSizeService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public object Add(HardDisk hardDisk)
        {
            _context.HardDiskSizes.Add(hardDisk);
            _context.SaveChanges();

            return new SuccessResponse();
        }

        public object GetAll(GetAll criteria, AppSettings appSettings)
        {
            var records = _context.HardDiskSizes.AsNoTracking()
                                  .Select(p => new
                                  {
                                      p.Id,
                                      p.Size
                                  });


            records = records.OrderByDescending(p => p.Id);

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
            var record = _context.HardDiskSizes.AsNoTracking()
                                 .Where(p => p.Id == id)
                                 .Select(p => new
                                 {
                                     p.Id,
                                     p.Size
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

        public object Update(int id, UpdateHardDisk updateHardDisk, IMapper mapper)
        {

            var hardDisk = _context.HardDiskSizes.AsNoTracking()
                                       .Where(p => p.Id == id)
                                       .FirstOrDefault();

            if (hardDisk == null)
            {
                var error = new ErrorResponse();
                error.ErrorMessages.Add(MessageHelper.RecordToBeUpdatedNotFound);

                return error;
            }
            else
            {
                var mappedHardDisk = mapper.Map(updateHardDisk, hardDisk);
                mappedHardDisk.DateUpdated = DateTime.Now;

                _context.Update(mappedHardDisk);
                _context.SaveChanges();

                return new SuccessResponse();
            }

        }

        public object Delete(int id)
        {
            var harddisk = _context.HardDiskSizes.AsNoTracking()
                                 .Where(p => p.Id == id)
                                 .Select(p => new HardDisk
                                 {
                                     Id = p.Id,
                                     Size = p.Size
                                 })
                                 .FirstOrDefault();

            _context.HardDiskSizes.Remove(harddisk);
            _context.SaveChanges();

            return new SuccessResponse();
        }

    }
}
