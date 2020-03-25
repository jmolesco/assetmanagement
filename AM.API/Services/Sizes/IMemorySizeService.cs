using AM.API.DTOs.Sizes;
using AM.API.DTOs.Sizes.Memory;
using AM.API.Helpers;
using AM.Core.Domain.Sizes;
using AutoMapper;

namespace AM.API.Services.Sizes
{
    public interface IMemorySizeService
    {

        /// <summary>
        /// Add new Memory
        /// </summary>
        /// <param name="memory">Memory</param>
        /// <returns></returns>
        object Add(Memory memory);

        /// <summary>
        /// Get all Memorys
        /// </summary>
        /// <param name="criteria">Search criterias</param>
        /// <param name="appSettings">AppSettings</param>
        /// <returns></returns>
        object GetAll(GetAll criteria, AppSettings appSettings);

        /// <summary>
        /// Get Memory by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        object GetById(int id);

        /// <summary>
        /// Update Memory record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="memory">Memory</param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        object Update(int id, UpdateMemory memory, IMapper mapper);

        object Delete(int id);

    }
}
