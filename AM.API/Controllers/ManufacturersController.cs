using AM.API.DTOs.Manufacturers;
using AM.API.Helpers;
using AM.API.Services.Manufacturers;
using AM.Core.Domain.Manufacturers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AM.API.Controllers
{
    [Route("api/Manufacturers")]
    public class ManufacturersController : BaseController
    {

        #region FIELDS

        /// <summary>
        /// Manufacturer Service
        /// </summary>
        private readonly IManufacturerService _service;

        /// <summary>
        /// Automapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// AppSettings
        /// </summary>
        private readonly AppSettings _appSettings;

        #endregion

        public ManufacturersController(IMapper mapper, IManufacturerService manufacturerService,
                                       IOptions<AppSettings> appSettings)
        {
            _mapper = mapper;
            _service = manufacturerService;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Adds new Manufacturer
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <returns></returns>
        /// <response code="200">Manufacturer was saved.</response>
        /// <response code="400">Invalid inputs.</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpPost]
        public IActionResult Add([FromBody]AddManufacturer manufacturer)
        {
            var mappedManufacturer = _mapper.Map<Manufacturer>(manufacturer);

            var response = _service.Add(mappedManufacturer);
            return Ok(response);
        }

        /// <summary>
        /// Get all Manufacturers
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
        /// Gets Manufacturer by Id
        /// </summary>
        /// <param name="id">Manufacturer Id</param>
        /// <returns></returns>
        /// <response code="200">Returns Manufacturer record</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = _service.GetById(id);
            return Ok(response);
        }

        /// <summary>
        /// Updates Manufacturer
        /// </summary>
        /// <param name="id">Manufacturer Id</param>
        /// <param name="manufacturer"></param>
        /// <returns></returns>
        /// <response code="200">Manufacturer record was updated.</response>
        /// <response code="400">Invalid inputs.</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UpdateManufacturer manufacturer)
        {
            var response = _service.Update(id, manufacturer, _mapper);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = _service.Delete(id);
            return Ok(response);
        }


    }
}