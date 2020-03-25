using AM.API.DTOs.Sizes;
using AM.API.Helpers;
using AM.Core.Domain.Sizes;
using AM.Core.Helper.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using AM.API.DTOs.Sizes.VideoCard;

namespace AM.API.Services.Sizes
{
    public class VideoCardSizeService : IVideoCardSizeService
    {

        private readonly DataContext _context;

        public VideoCardSizeService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public object Add(VideoCard videoCard)
        {
            _context.VideoCardSizes.Add(videoCard);
            _context.SaveChanges();

            return new SuccessResponse();
        }

        public object GetAll(GetAll criteria, AppSettings appSettings)
        {
            var records = _context.VideoCardSizes.AsNoTracking()
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
            var record = _context.VideoCardSizes.AsNoTracking()
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

        public object Update(int id, UpdateVideoCard updateVideoCard, IMapper mapper)
        {

            var videoCard = _context.VideoCardSizes.AsNoTracking()
                                       .Where(p => p.Id == id)
                                       .FirstOrDefault();

            if (videoCard == null)
            {
                var error = new ErrorResponse();
                error.ErrorMessages.Add(MessageHelper.RecordToBeUpdatedNotFound);

                return error;
            }
            else
            {
                var mappedVideoCard = mapper.Map(updateVideoCard, videoCard);
                mappedVideoCard.DateUpdated = DateTime.Now;

                _context.Update(mappedVideoCard);
                _context.SaveChanges();

                return new SuccessResponse();
            }

        }

        public object Delete(int id)
        {
            var videocard = _context.VideoCardSizes.AsNoTracking()
                                 .Where(p => p.Id == id)
                                 .Select(p => new VideoCard
                                 {
                                     Id = p.Id,
                                     Size = p.Size
                                 })
                                 .FirstOrDefault();

            _context.VideoCardSizes.Remove(videocard);
            _context.SaveChanges();

            return new SuccessResponse();
        }
    }
}
