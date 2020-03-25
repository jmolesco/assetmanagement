using AM.API.DTOs.Processors;
using AM.API.Helpers;
using AM.Core.Domain.Processors;
using AM.Core.Helper.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AM.API.Services.Processors
{
    public class ProcessorService : IProcessorService
    {

        private readonly DataContext _context;

        public ProcessorService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public object Add(Processor processor)
        {
            _context.Processors.Add(processor);
            _context.SaveChanges();

            return new SuccessResponse();
        }

        public object GetAll(GetAll criteria, AppSettings appSettings)
        {
            var records = _context.Processors.AsNoTracking()
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
            var record = _context.Processors.AsNoTracking()
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

        public object Update(int id, UpdateProcessor updateProcessor, IMapper mapper)
        {

            var processor = _context.Processors.AsNoTracking()
                                       .Where(p => p.Id == id)
                                       .FirstOrDefault();

            if (processor == null)
            {
                var error = new ErrorResponse();
                error.ErrorMessages.Add(MessageHelper.RecordToBeUpdatedNotFound);

                return error;
            }
            else
            {
                var mappedProcessor = mapper.Map(updateProcessor, processor);
                mappedProcessor.DateUpdated = DateTime.Now;

                _context.Update(mappedProcessor);
                _context.SaveChanges();

                return new SuccessResponse();
            }

        }
        public object Delete(int id)
        {
            var processor = _context.Processors.AsNoTracking()
                                 .Where(p => p.Id == id)
                                 .Select(p => new Processor
                                 {
                                     Id = p.Id,
                                     Name = p.Name
                                 })
                                 .FirstOrDefault();

            _context.Processors.Remove(processor);
            _context.SaveChanges();

            return new SuccessResponse();
        }
    }
}
