using AM.API.DTOs.Sizes;
using AM.API.Helpers;
using AM.Core.Domain.Sizes;
using AM.API.DTOs.Sizes.HardDisk;
using AutoMapper;

namespace AM.API.Services.Sizes
{
    public interface IHardDiskSizeService
    {

        /// <summary>
        /// Add new HardDisk
        /// </summary>
        /// <param name="hardDisk">HardDisk</param>
        /// <returns></returns>
        object Add(HardDisk hardDisk);

        /// <summary>
        /// Get all HardDisks
        /// </summary>
        /// <param name="criteria">Search criterias</param>
        /// <param name="appSettings">AppSettings</param>
        /// <returns></returns>
        object GetAll(GetAll criteria, AppSettings appSettings);

        /// <summary>
        /// Get HardDisk by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        object GetById(int id);

        /// <summary>
        /// Update HardDisk record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hardDisk">HardDisk</param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        object Update(int id, UpdateHardDisk hardDisk, IMapper mapper);
        object Delete(int id);
    }
}
