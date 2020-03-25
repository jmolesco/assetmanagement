using AM.API.DTOs.Assets;
using AM.API.Helpers;
using AM.API.Services.Assets;
using AM.Core.Domain.Assets;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AM.API.Controllers
{
    [Route("api/Assets")]
    public class AssetsController : BaseController
    {

        #region FIELDS

        /// <summary>
        /// Asset Service
        /// </summary>
        private readonly IAssetService _service;

        /// <summary>
        /// Automapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// AppSettings
        /// </summary>
        private readonly AppSettings _appSettings;

        #endregion

        public AssetsController(IMapper mapper, IAssetService assetService,
                                IOptions<AppSettings> appSettings)
        {
            _mapper = mapper;
            _service = assetService;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Adds new Asset
        /// </summary>
        /// <param name="asset"></param>
        /// <returns></returns>
        /// <response code="200">Asset was saved.</response>
        /// <response code="400">Invalid inputs.</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpPost]
        public IActionResult Add([FromBody]AddAsset asset)
        {
            var mappedAsset = _mapper.Map<Asset>(asset);

            var response = _service.Add(mappedAsset);
            return Ok(response);
        }

        /// <summary>
        /// Get all Assets
        /// </summary>
        /// <param name="criteria">Search criterias</param>
        /// <returns></returns>
        /// <response code="401">Unauthorized user.</response>
        [HttpGet]
        public IActionResult GetAll(GetAll criteria)
        {
            var response = _service.GetAll(criteria, _appSettings);
            return Ok(response);
        }

        /// <summary>
        /// Gets Asset by Id
        /// </summary>
        /// <param name="id">Asset Id</param>
        /// <returns></returns>
        /// <response code="200">Returns Asset record</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = _service.GetById(id);
            return Ok(response);
        }

        /// <summary>
        /// Updates Asset
        /// </summary>
        /// <param name="id">Asset Id</param>
        /// <param name="asset"></param>
        /// <returns></returns>
        /// <response code="200">Asset record was updated.</response>
        /// <response code="400">Invalid inputs.</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UpdateAsset asset)
        {
            var response = _service.Update(id, asset, _mapper);
            return Ok(response);
        }

    }
}