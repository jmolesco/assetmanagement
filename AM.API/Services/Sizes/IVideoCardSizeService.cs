using AM.API.DTOs.Sizes;
using AM.API.Helpers;
using AM.API.DTOs.Sizes.VideoCard;
using AM.Core.Domain.Sizes;
using AutoMapper;

namespace AM.API.Services.Sizes
{
    public interface IVideoCardSizeService
    {

        /// <summary>
        /// Add new VideoCard
        /// </summary>
        /// <param name="videoCard">VideoCard</param>
        /// <returns></returns>
        object Add(VideoCard videoCard);

        /// <summary>
        /// Get all VideoCards
        /// </summary>
        /// <param name="criteria">Search criterias</param>
        /// <param name="appSettings">AppSettings</param>
        /// <returns></returns>
        object GetAll(GetAll criteria, AppSettings appSettings);

        /// <summary>
        /// Get VideoCard by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        object GetById(int id);

        /// <summary>
        /// Update VideoCard record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="videoCard">VideoCard</param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        object Update(int id, UpdateVideoCard videoCard, IMapper mapper);

        object Delete(int id);

    }
}
