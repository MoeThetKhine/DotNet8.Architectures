using DotNet8.Architectures.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.Architectures.Hexgonal.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BaseController : ControllerBase
	{
		public IActionResult Content(Object obj)
		{
			return Content(obj.ToJson(), "application/json");
		}
	}
}
