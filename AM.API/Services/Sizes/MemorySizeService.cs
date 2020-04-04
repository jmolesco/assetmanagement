using AM.API.Helpers;
using AM.Core.Domain.Sizes;
using AM.Core.Helper.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using AM.API.DTOs.Sizes.Memory;
using AM.Core.Helper.Extensions;

namespace AM.API.Services.Sizes
{
    public class MemorySizeService : IMemorySizeService
    {

        private readonly DataContext _context;

        public MemorySizeService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public object Add(Memory manufacturer)
        {
            _context.MemorySizes.Add(manufacturer);
            _context.SaveChanges();

            return new SuccessResponse();
        }

        public object GetAll(GetAll criteria, AppSettings appSettings)
        {
            var records = _context.MemorySizes.AsNoTracking()
                                  .Select(p => new
                                  {
                                      p.Id,
                                      p.Size
                                  });


            if (criteria.Keyword.HasValue())
            {
                if (criteria.SearchBy.HasValue)
                {
                    records = records.Where(p => p.Size.Contains(criteria.Keyword));
                }
            }

            if (criteria.OrderBy.HasValue)
            {
                if (criteria.OrderBy == 1) // ID
                {
                    if (criteria.OrderType == 1) // asc
                        records = records.OrderByDescending(p => p.Id);
                    else
                        records = records.OrderBy(p => p.Id);
                }
                else // NAME
                {
                    if (criteria.OrderType == 1) // asc
                        records = records.OrderByDescending(p => p.Size);
                    else
                        records = records.OrderBy(p => p.Size);

                }
            }
            else
            {
                records = records.OrderByDescending(p => p.Id);
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
            var record = _context.MemorySizes.AsNoTracking()
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

        public object Update(int id, UpdateMemory updateMemory, IMapper mapper)
        {

            var manufacturer = _context.MemorySizes.AsNoTracking()
                                       .Where(p => p.Id == id)
                                       .FirstOrDefault();

            if (manufacturer == null)
            {
                var error = new ErrorResponse();
                error.ErrorMessages.Add(MessageHelper.RecordToBeUpdatedNotFound);

                return error;
            }
            else
            {
                var mappedMemory = mapper.Map(updateMemory, manufacturer);
                mappedMemory.DateUpdated = DateTime.Now;

                _context.Update(mappedMemory);
                _context.SaveChanges();

                return new SuccessResponse();
            }

        }

        public object Delete(int id)
        {
            var memory = _context.MemorySizes.AsNoTracking()
                                 .Where(p => p.Id == id)
                                 .Select(p => new Memory
                                 {
                                     Id = p.Id,
                                     Size = p.Size
                                 })
                                 .FirstOrDefault();

            _context.MemorySizes.Remove(memory);
            _context.SaveChanges();

            return new SuccessResponse();
        }

    }
}
