using AM.Core.Domain.Assets;
using AM.Core.Helper.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AM.API.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class TypesController : Controller
    {

        /// <summary>
        /// Get all Status Types
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("statustypes")]
        public IActionResult GetStatusTypes()
        {
            return Ok(EnumExtension.GetValues<StatusType>());
        }

        [HttpGet]
        [Route("assets_orderby")]
        public IActionResult GetAssetsOrderBy()
        {
            return Ok(EnumExtension.GetValues<OrderBy>());
        }

        [HttpGet]
        [Route("assets_ordertype")]
        public IActionResult GetAssetsOrderType()
        {
            return Ok(EnumExtension.GetValues<OrderType>());
        }

    }
}