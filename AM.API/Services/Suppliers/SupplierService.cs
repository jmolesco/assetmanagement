using AM.API.DTOs.Suppliers;
using AM.API.Helpers;
using AM.Core.Domain.Suppliers;
using AM.Core.Helper.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AM.API.Services.Suppliers
{
    public class SupplierService : ISupplierService
    {

        private readonly DataContext _context;

        public SupplierService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public object Add(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            return new SuccessResponse();
        }

        public object GetAll(GetAll criteria, AppSettings appSettings)
        {
            var records = _context.Suppliers.AsNoTracking()
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
            var record = _context.Suppliers.AsNoTracking()
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

        public object Update(int id, UpdateSupplier updateSupplier, IMapper mapper)
        {

            var supplier = _context.Suppliers.AsNoTracking()
                                       .Where(p => p.Id == id)
                                       .FirstOrDefault();

            if (supplier == null)
            {
                var error = new ErrorResponse();
                error.ErrorMessages.Add(MessageHelper.RecordToBeUpdatedNotFound);

                return error;
            }
            else
            {
                var mappedSupplier = mapper.Map(updateSupplier, supplier);
                mappedSupplier.DateUpdated = DateTime.Now;

                _context.Update(mappedSupplier);
                _context.SaveChanges();

                return new SuccessResponse();
            }

        }

        public object Delete(int id)
        {
            var supplier = _context.Suppliers.AsNoTracking()
                                 .Where(p => p.Id == id)
                                 .Select(p => new Supplier
                                 {
                                     Id = p.Id,
                                     Name = p.Name
                                 })
                                 .FirstOrDefault();

            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();

            return new SuccessResponse();
        }

    }
}
