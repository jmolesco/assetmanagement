using AM.API.DTOs.Manufacturers;
using AM.API.Helpers;
using AM.Core.Domain.Manufacturers;
using AM.Core.Helper.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AM.API.Services.Manufacturers
{
    public class ManufacturerService : IManufacturerService
    {

        private readonly DataContext _context;

        public ManufacturerService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public object Add(Manufacturer manufacturer)
        {
            _context.Manufacturers.Add(manufacturer);
            _context.SaveChanges();

            return new SuccessResponse();
        }

        public object GetAll(GetAll criteria, AppSettings appSettings)
        {
            var records = _context.Manufacturers.AsNoTracking()
                                  .Select(p => new
                                  {
                                      p.Id,
                                      p.Name
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
            var record = _context.Manufacturers.AsNoTracking()
                                 .Where(p => p.Id == id)
                                 .Select(p => new
                                 {
                                     p.Id,
                                     p.Name
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

        public object Update(int id, UpdateManufacturer updateManufacturer, IMapper mapper)
        {

            var manufacturer = _context.Manufacturers.AsNoTracking()
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
                var mappedManufacturer = mapper.Map(updateManufacturer, manufacturer);
                mappedManufacturer.DateUpdated = DateTime.Now;

                _context.Update(mappedManufacturer);
                _context.SaveChanges();

                return new SuccessResponse();
            }

        }

        public object Delete(int id)
        {
            var manufacturer = _context.Manufacturers.AsNoTracking()
                                 .Where(p => p.Id == id)
                                 .Select(p => new Manufacturer
                                 {
                                     Id = p.Id,
                                     Name = p.Name
                                 })
                                 .FirstOrDefault();

            _context.Manufacturers.Remove(manufacturer);
            _context.SaveChanges();

            return new SuccessResponse();
        }


    }

    
}
