using AM.API.DTOs.Sizes.HardDisk;
using AM.API.DTOs.Sizes.Memory;
using AM.API.DTOs.Sizes.VideoCard;
using AM.API.Helpers;
using AM.API.Services.Sizes;
using AM.Core.Domain.Sizes;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AM.API.Controllers
{
    [Route("api/Sizes")]
    public class SizesController : BaseController
    {

        #region FIELDS

        /// <summary>
        /// HardDiskSize Service
        /// </summary>
        private readonly IHardDiskSizeService _hardDiskSizeService;

        /// <summary>
        /// MemorySize Service
        /// </summary>
        private readonly IMemorySizeService _memorySizeService;

        /// <summary>
        /// VideoCardSize Service
        /// </summary>
        private readonly IVideoCardSizeService _videoCardSizeService;

        /// <summary>
        /// Automapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// AppSettings
        /// </summary>
        private readonly AppSettings _appSettings;

        #endregion

        public SizesController(IMapper mapper, IHardDiskSizeService hardDiskSizeService,
                               IMemorySizeService memorySizeService, IVideoCardSizeService videoCardSizeService,
                               IOptions<AppSettings> appSettings)
        {
            _mapper = mapper;
            _hardDiskSizeService = hardDiskSizeService;
            _memorySizeService = memorySizeService;
            _videoCardSizeService = videoCardSizeService;
            _appSettings = appSettings.Value;
        }

        #region Hard Disk

        /// <summary>
        /// Adds new Hard Disk Size
        /// </summary>
        /// <param name="hardDiskSize"></param>
        /// <returns></returns>
        /// <response code="200">Hard Disk Size was saved.</response>
        /// <response code="400">Invalid inputs.</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpPost]
        [Route("harddisk")]
        public IActionResult AddHardDisk([FromBody]AddHardDisk hardDiskSize)
        {
            var mappedHardDiskSize = _mapper.Map<HardDisk>(hardDiskSize);

            var response = _hardDiskSizeService.Add(mappedHardDiskSize);
            return Ok(response);
        }

        /// <summary>
        /// Get all Hard Disk Sizes
        /// </summary>
        /// <param name="criteria">Search criterias</param>
        /// <returns></returns>
        /// <response code="401">Unauthorized user.</response>
        [HttpGet]
        [Route("harddisk")]
        public IActionResult GetAllHardDrives(DTOs.Sizes.HardDisk.GetAll criteria)
        {
            var response = _hardDiskSizeService.GetAll(criteria, _appSettings);
            return Ok(response);
        }

        /// <summary>
        /// Gets Hard Disk Size by Id
        /// </summary>
        /// <param name="id">Hard Disk Size Id</param>
        /// <returns></returns>
        /// <response code="200">Returns Hard Disk Size record</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpGet]
        [Route("harddisk/{id}")]
        public IActionResult GetHardDiskById(int id)
        {
            var response = _hardDiskSizeService.GetById(id);
            return Ok(response);
        }

        /// <summary>
        /// Updates Hard Disk Size
        /// </summary>
        /// <param name="id">Hard Disk Size Id</param>
        /// <param name="hardDiskSize"></param>
        /// <returns></returns>
        /// <response code="200">Hard Disk Size record was updated.</response>
        /// <response code="400">Invalid inputs.</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpPut]
        [Route("harddisk/{id}")]
        public IActionResult UpdateHardDisk(int id, [FromBody]UpdateHardDisk hardDiskSize)
        {
            var response = _hardDiskSizeService.Update(id, hardDiskSize, _mapper);
            return Ok(response);
        }

        [HttpDelete]
        [Route("harddisk/{id}")]
        public IActionResult DeleteHardDisk(int id)
        {
            var response = _hardDiskSizeService.Delete(id);
            return Ok(response);
        }

        #endregion

        #region Memory

        /// <summary>
        /// Adds new Memory Size
        /// </summary>
        /// <param name="memorySize"></param>
        /// <returns></returns>
        /// <response code="200">Memory Size was saved.</response>
        /// <response code="400">Invalid inputs.</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpPost]
        [Route("memory")]
        public IActionResult AddMemory([FromBody]AddMemory memorySize)
        {
            var mappedMemorySize = _mapper.Map<Memory>(memorySize);

            var response = _memorySizeService.Add(mappedMemorySize);
            return Ok(response);
        }

        /// <summary>
        /// Get all Memory Sizes
        /// </summary>
        /// <param name="criteria">Search criterias</param>
        /// <returns></returns>
        /// <response code="401">Unauthorized user.</response>
        [HttpGet]
        [Route("memory")]
        public IActionResult GetAllMemory(DTOs.Sizes.Memory.GetAll criteria)
        {
            var response = _memorySizeService.GetAll(criteria, _appSettings);
            return Ok(response);
        }

        /// <summary>
        /// Gets Memory Size by Id
        /// </summary>
        /// <param name="id">Memory Size Id</param>
        /// <returns></returns>
        /// <response code="200">Returns Memory Size record</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpGet]
        [Route("memory/{id}")]
        public IActionResult GetMemoryById(int id)
        {
            var response = _memorySizeService.GetById(id);
            return Ok(response);
        }

        /// <summary>
        /// Updates Memory Size
        /// </summary>
        /// <param name="id">Memory Size Id</param>
        /// <param name="memorySize"></param>
        /// <returns></returns>
        /// <response code="200">Memory Size record was updated.</response>
        /// <response code="400">Invalid inputs.</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpPut]
        [Route("memory/{id}")]
        public IActionResult UpdateMemory(int id, [FromBody]UpdateMemory memorySize)
        {
            var response = _memorySizeService.Update(id, memorySize, _mapper);
            return Ok(response);
        }


        [HttpDelete]
        [Route("memory/{id}")]
        public IActionResult DeleteMemory(int id)
        {
            var response = _memorySizeService.Delete(id);
            return Ok(response);
        }
        #endregion

        #region Video Card

        /// <summary>
        /// Adds new Video Card Size
        /// </summary>
        /// <param name="videoCardSize"></param>
        /// <returns></returns>
        /// <response code="200">Video Card Size was saved.</response>
        /// <response code="400">Invalid inputs.</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpPost]
        [Route("videocard")]
        public IActionResult AddVideoCard([FromBody]AddVideoCard videoCardSize)
        {
            var mappedVideoCardSize = _mapper.Map<VideoCard>(videoCardSize);

            var response = _videoCardSizeService.Add(mappedVideoCardSize);
            return Ok(response);
        }

        /// <summary>
        /// Get all Video Card Sizes
        /// </summary>
        /// <param name="criteria">Search criterias</param>
        /// <returns></returns>
        /// <response code="401">Unauthorized user.</response>
        [HttpGet]
        [Route("videocard")]
        public IActionResult GetAllVideoCards(DTOs.Sizes.VideoCard.GetAll criteria)
        {
            var response = _videoCardSizeService.GetAll(criteria, _appSettings);
            return Ok(response);
        }

        /// <summary>
        /// Gets Video Card Size by Id
        /// </summary>
        /// <param name="id">Video Card Size Id</param>
        /// <returns></returns>
        /// <response code="200">Returns Video Card Size record</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpGet]
        [Route("videocard/{id}")]
        public IActionResult GetVideoCardById(int id)
        {
            var response = _videoCardSizeService.GetById(id);
            return Ok(response);
        }

        /// <summary>
        /// Updates Video Card Size
        /// </summary>
        /// <param name="id">Video Card Size Id</param>
        /// <param name="videoCardSize"></param>
        /// <returns></returns>
        /// <response code="200">Video Card Size record was updated.</response>
        /// <response code="400">Invalid inputs.</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpPut]
        [Route("videocard/{id}")]
        public IActionResult UpdateVideoCard(int id, [FromBody]UpdateVideoCard videoCardSize)
        {
            var response = _videoCardSizeService.Update(id, videoCardSize, _mapper);
            return Ok(response);
        }

        [HttpDelete]
        [Route("videocard/{id}")]
        public IActionResult DeleteVideoCard(int id)
        {
            var response = _videoCardSizeService.Delete(id);
            return Ok(response);
        }

        #endregion

    }
}