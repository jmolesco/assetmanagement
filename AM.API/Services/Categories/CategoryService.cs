using AM.API.DTOs.Categories;
using AM.API.Helpers;
using AM.Core.Domain.Categories;
using AM.Core.Helper.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AM.API.Services.Categories
{
    public class CategoryService : ICategoryService
    {

        private readonly DataContext _context;

        public CategoryService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public object Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return new SuccessResponse();
        }

        public object GetAll(GetAll criteria, AppSettings appSettings)
        {
            var records = _context.Categories.AsNoTracking()
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
            var record = _context.Categories.AsNoTracking()
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

        public object Update(int id, UpdateCategory updateCategory, IMapper mapper)
        {

            var category = _context.Categories.AsNoTracking()
                                       .Where(p => p.Id == id)
                                       .FirstOrDefault();

            if (category == null)
            {
                var error = new ErrorResponse();
                error.ErrorMessages.Add(MessageHelper.RecordToBeUpdatedNotFound);

                return error;
            }
            else
            {
                var mappedCategory = mapper.Map(updateCategory, category);
                mappedCategory.DateUpdated = DateTime.Now;

                _context.Update(mappedCategory);
                _context.SaveChanges();

                return new SuccessResponse();
            }

        }


        public object Delete(int id)
        {
            var category = _context.Categories.AsNoTracking()
                                 .Where(p => p.Id == id)
                                 .Select(p => new Category
                                 {
                                    Id = p.Id,
                                    Name = p.Name
                                 })
                                 .FirstOrDefault();
     
            _context.Categories.Remove(category);
            _context.SaveChanges();

            return new SuccessResponse();
        }
    }
}
