using AM.API.DTOs.Processors;
using AM.API.Helpers;
using AM.API.Services.Processors;
using AM.Core.Domain.Processors;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AM.API.Controllers
{
    [Route("api/Processors")]
    public class ProcessorsController : BaseController
    {

        #region FIELDS

        /// <summary>
        /// Processor Service
        /// </summary>
        private readonly IProcessorService _service;

        /// <summary>
        /// Automapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// AppSettings
        /// </summary>
        private readonly AppSettings _appSettings;

        #endregion

        public ProcessorsController(IMapper mapper, IProcessorService processorService,
                                    IOptions<AppSettings> appSettings)
        {
            _mapper = mapper;
            _service = processorService;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Adds new Processor
        /// </summary>
        /// <param name="processor"></param>
        /// <returns></returns>
        /// <response code="200">Processor was saved.</response>
        /// <response code="400">Invalid inputs.</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpPost]
        public IActionResult Add([FromBody]AddProcessor processor)
        {
            var mappedProcessor = _mapper.Map<Processor>(processor);

            var response = _service.Add(mappedProcessor);
            return Ok(response);
        }

        /// <summary>
        /// Get all Processors
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
        /// Gets Processor by Id
        /// </summary>
        /// <param name="id">Processor Id</param>
        /// <returns></returns>
        /// <response code="200">Returns Processor record</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = _service.GetById(id);
            return Ok(response);
        }

        /// <summary>
        /// Updates Processor
        /// </summary>
        /// <param name="id">Processor Id</param>
        /// <param name="processor"></param>
        /// <returns></returns>
        /// <response code="200">Processor record was updated.</response>
        /// <response code="400">Invalid inputs.</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UpdateProcessor processor)
        {
            var response = _service.Update(id, processor, _mapper);
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