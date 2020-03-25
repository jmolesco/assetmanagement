using AM.API.DTOs.Users;
using AM.API.Helpers;
using AM.API.Services.Users;
using AM.Core.Domain.Users;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AM.API.Controllers
{
    [Route("api/Users")]
    public class UsersController : BaseController
    {

        #region FIELDS

        /// <summary>
        /// User Service
        /// </summary>
        private readonly IUserService _service;

        /// <summary>
        /// Automapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// AppSettings
        /// </summary>
        private readonly AppSettings _appSettings;

        #endregion

        public UsersController(IMapper mapper, IUserService userService,
                               IOptions<AppSettings> appSettings)
        {
            _mapper = mapper;
            _service = userService;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Auntheticate User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <response code="200">User was authorized.</response>
        /// <response code="401">Unauthorized user.</response>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateUser user)
        {
            var authenticatedUser = _service.Authenticate(user);
            if(authenticatedUser == null)
            {
                return Unauthorized();
            }

            return Ok(_service.GenerateToken(authenticatedUser, _appSettings));
        }

        /// <summary>
        /// Adds new User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <response code="200">User was saved.</response>
        /// <response code="400">Invalid inputs.</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpPost]
        public IActionResult Add([FromBody]AddUser user)
        {
            var mappedUser = _mapper.Map<User>(user);

            var response = _service.Add(mappedUser, user.Password);
            return Ok(response);
        }

        /// <summary>
        /// Get all Users
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
        /// Gets User by Id
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns></returns>
        /// <response code="200">Returns User record</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = _service.GetById(id);
            return Ok(response);
        }

        /// <summary>
        /// Updates User
        /// </summary>
        /// <param name="id">User Id</param>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <response code="200">User record was updated.</response>
        /// <response code="400">Invalid inputs.</response>
        /// <response code="401">Unauthorized user.</response>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UpdateUser user)
        {
            var response = _service.Update(id, user, user.Password, _mapper);
            return Ok(response);
        }

    }

}