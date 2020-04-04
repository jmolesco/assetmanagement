using AM.API.DTOs.Models;
using AM.API.Helpers;
using AM.Core.Domain.Models;
using AM.Core.Helper.Extensions;
using AM.Core.Helper.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AM.API.Services.Models
{
    public class ModelService : IModelService
    {

        private readonly DataContext _context;

        public ModelService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public object Add(Model model)
        {
            _context.Models.Add(model);
            _context.SaveChanges();

            return new SuccessResponse();
        }

        public object GetAll(GetAll criteria, AppSettings appSettings)
        {
            var records = _context.Models.AsNoTracking()
                                  .Select(p => new
                                  {
                                      p.Id,
                                      p.Name
                                  });

            if (criteria.Keyword.HasValue())
            {
                if (criteria.SearchBy.HasValue)
                {
                    records = records.Where(p => p.Name.Contains(criteria.Keyword));
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
                        records = records.OrderByDescending(p => p.Name);
                    else
                        records = records.OrderBy(p => p.Name);

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
            var record = _context.Models.AsNoTracking()
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

        public object Update(int id, UpdateModel updateModel, IMapper mapper)
        {

            var model = _context.Models.AsNoTracking()
                                       .Where(p => p.Id == id)
                                       .FirstOrDefault();

            if (model == null)
            {
                var error = new ErrorResponse();
                error.ErrorMessages.Add(MessageHelper.RecordToBeUpdatedNotFound);

                return error;
            }
            else
            {
                var mappedModel = mapper.Map(updateModel, model);
                mappedModel.DateUpdated = DateTime.Now;

                _context.Update(mappedModel);
                _context.SaveChanges();

                return new SuccessResponse();
            }

        }

        public object Delete(int id)
        {
            var models = _context.Models.AsNoTracking()
                                 .Where(p => p.Id == id)
                                 .Select(p => new Model
                                 {
                                     Id = p.Id,
                                     Name = p.Name
                                 })
                                 .FirstOrDefault();

            _context.Models.Remove(models);
            _context.SaveChanges();

            return new SuccessResponse();
        }


    }
}
