using AM.API.DTOs.Manufacturers;
using AM.API.Helpers;
using AM.Core.Domain.Manufacturers;
using AutoMapper;

namespace AM.API.Services.Manufacturers
{
    public interface IManufacturerService
    {

        /// <summary>
        /// Add new Manufacturer
        /// </summary>
        /// <param name="manufacturer">Manufacturer</param>
        /// <returns></returns>
        object Add(Manufacturer manufacturer);

        /// <summary>
        /// Get all Manufacturers
        /// </summary>
        /// <param name="criteria">Search criterias</param>
        /// <param name="appSettings">AppSettings</param>
        /// <returns></returns>
        object GetAll(GetAll criteria, AppSettings appSettings);

        /// <summary>
        /// Get Manufacturer by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        object GetById(int id);

        /// <summary>
        /// Update Manufacturer record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="manufacturer">Manufacturer</param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        object Update(int id, UpdateManufacturer manufacturer, IMapper mapper);

        object Delete(int id);


    }
}
