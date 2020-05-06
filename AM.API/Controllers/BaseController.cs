using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AM.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    public class BaseController : Controller
    {
    }
}