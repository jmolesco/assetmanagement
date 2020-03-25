using AM.API.DTOs.Models;
using AM.API.Helpers;
using AM.Core.Domain.Models;
using AutoMapper;

namespace AM.API.Services.Models
{
    public interface IModelService
    {

        /// <summary>
        /// Add new Model
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns></returns>
        object Add(Model model);

        /// <summary>
        /// Get all Models
        /// </summary>
        /// <param name="criteria">Search criterias</param>
        /// <param name="appSettings">AppSettings</param>
        /// <returns></returns>
        object GetAll(GetAll criteria, AppSettings appSettings);

        /// <summary>
        /// Get Model by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        object GetById(int id);

        /// <summary>
        /// Update Model record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model">Model</param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        object Update(int id, UpdateModel model, IMapper mapper);

        object Delete(int id);

    }
}
