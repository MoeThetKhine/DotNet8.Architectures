using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.Architectures.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult Content(object obj)
        {
            return Content(obj.ToJson(), "application/json");
        }
    }
}
