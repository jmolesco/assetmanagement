using AM.API.DTOs.Categories;
using AM.API.Helpers;
using AM.API.Services.Categories;
using AM.Core.Domain.Categories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AM.API.Controllers
{
    [Route("api/Categories")]
    public class CategoriesController : BaseController
    {

        #region FIELDS

        /// <summary>
        /// Category Service
        /// </summary>
        private readonly ICategoryService _service;

        /// <summary>
        /// Automapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// AppSettings
        /// </summary>
        private readonly AppSettings _appSettings;

        #endregion

        public CategoriesController(IMapper mapper, ICategoryService categoryService,
                                    IOptions<AppSettings> appSettings)
        {
            _mapper = mapper;
            _service = categoryService;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Adds new Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        /// <response code="200">Category was saved.</response>
        /// <response code="400">Invalid inputs.</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpPost]
        public IActionResult Add([FromBody]AddCategory category)
        {
            var mappedCategory = _mapper.Map<Category>(category);

            var response = _service.Add(mappedCategory);
            return Ok(response);
        }


        /// <summary>
        /// Get all Categories
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
        /// Gets Category by Id
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns></returns>
        /// <response code="200">Returns Category record</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = _service.GetById(id);
            return Ok(response);
        }

        /// <summary>
        /// Updates Category
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <param name="category"></param>
        /// <returns></returns>
        /// <response code="200">Category record was updated.</response>
        /// <response code="400">Invalid inputs.</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UpdateCategory category)
        {
            var response = _service.Update(id, category, _mapper);
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