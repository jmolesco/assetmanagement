using AM.API.DTOs.Assets;
using AM.API.Helpers;
using AM.Core.Domain.Assets;
using AutoMapper;

namespace AM.API.Services.Assets
{
    public interface IAssetService
    {

        /// <summary>
        /// Add new Asset
        /// </summary>
        /// <param name="asset">Asset</param>
        /// <returns></returns>
        object Add(Asset asset);

        /// <summary>
        /// Get all Assets
        /// </summary>
        /// <param name="criteria">Search criterias</param>
        /// <param name="appSettings">AppSettings</param>
        /// <returns></returns>
        object GetAll(GetAll criteria, AppSettings appSettings);

        /// <summary>
        /// Get Asset by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        object GetById(int id);

        /// <summary>
        /// Update Asset record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="asset">Asset</param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        object Update(int id, UpdateAsset asset, IMapper mapper);

    }
}
