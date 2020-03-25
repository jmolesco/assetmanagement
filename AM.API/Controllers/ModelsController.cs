using AM.API.DTOs.Models;
using AM.API.Helpers;
using AM.API.Services.Models;
using AM.Core.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AM.API.Controllers
{
    [Route("api/Models")]
    public class ModelsController : BaseController
    {

        #region FIELDS

        /// <summary>
        /// Model Service
        /// </summary>
        private readonly IModelService _service;

        /// <summary>
        /// Automapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// AppSettings
        /// </summary>
        private readonly AppSettings _appSettings;

        #endregion

        public ModelsController(IMapper mapper, IModelService modelService,
                                IOptions<AppSettings> appSettings)
        {
            _mapper = mapper;
            _service = modelService;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Adds new Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">Model was saved.</response>
        /// <response code="400">Invalid inputs.</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpPost]
        public IActionResult Add([FromBody]AddModel model)
        {
            var mappedModel = _mapper.Map<Model>(model);

            var response = _service.Add(mappedModel);
            return Ok(response);
        }

        /// <summary>
        /// Get all Models
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
        /// Gets Model by Id
        /// </summary>
        /// <param name="id">Model Id</param>
        /// <returns></returns>
        /// <response code="200">Returns Model record</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = _service.GetById(id);
            return Ok(response);
        }

        /// <summary>
        /// Updates Model
        /// </summary>
        /// <param name="id">Model Id</param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">Model record was updated.</response>
        /// <response code="400">Invalid inputs.</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UpdateModel model)
        {
            var response = _service.Update(id, model, _mapper);
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