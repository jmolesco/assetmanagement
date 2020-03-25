using AM.API.DTOs.Suppliers;
using AM.API.Helpers;
using AM.API.Services.Suppliers;
using AM.Core.Domain.Suppliers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AM.API.Controllers
{
    [Route("api/Suppliers")]
    public class SuppliersController : BaseController
    {

        #region FIELDS

        /// <summary>
        /// Supplier Service
        /// </summary>
        private readonly ISupplierService _service;

        /// <summary>
        /// Automapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// AppSettings
        /// </summary>
        private readonly AppSettings _appSettings;


        #endregion

        public SuppliersController(IMapper mapper, ISupplierService supplierService,
                                   IOptions<AppSettings> appSettings)
        {
            _mapper = mapper;
            _service = supplierService;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Adds new Supplier
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        /// <response code="200">Supplier was saved.</response>
        /// <response code="400">Invalid inputs.</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpPost]
        public IActionResult Add([FromBody]AddSupplier supplier)
        {
            var mappedSupplier = _mapper.Map<Supplier>(supplier);

            var response = _service.Add(mappedSupplier);
            return Ok(response);
        }

        /// <summary>
        /// Get all Suppliers
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
        /// Gets Supplier by Id
        /// </summary>
        /// <param name="id">Supplier Id</param>
        /// <returns></returns>
        /// <response code="200">Returns Supplier record</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = _service.GetById(id);
            return Ok(response);
        }

        /// <summary>
        /// Updates Supplier
        /// </summary>
        /// <param name="id">Supplier Id</param>
        /// <param name="supplier"></param>
        /// <returns></returns>
        /// <response code="200">Supplier record was updated.</response>
        /// <response code="400">Invalid inputs.</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UpdateSupplier supplier)
        {
            var response = _service.Update(id, supplier, _mapper);
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