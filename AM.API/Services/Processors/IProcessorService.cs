using AM.API.DTOs.Processors;
using AM.API.Helpers;
using AM.Core.Domain.Processors;
using AutoMapper;

namespace AM.API.Services.Processors
{
    public interface IProcessorService
    {

        /// <summary>
        /// Add new Processor
        /// </summary>
        /// <param name="processor">Processor</param>
        /// <returns></returns>
        object Add(Processor processor);

        /// <summary>
        /// Get all Processors
        /// </summary>
        /// <param name="criteria">Search criterias</param>
        /// <param name="appSettings">AppSettings</param>
        /// <returns></returns>
        object GetAll(GetAll criteria, AppSettings appSettings);

        /// <summary>
        /// Get Processor by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        object GetById(int id);

        /// <summary>
        /// Update Processor record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="processor">Processor</param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        object Update(int id, UpdateProcessor processor, IMapper mapper);

        object Delete(int id);

    }
}
