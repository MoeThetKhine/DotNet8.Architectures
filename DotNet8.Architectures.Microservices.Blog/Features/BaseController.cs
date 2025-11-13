using DotNet8.Architectures.Shared;
namespace DotNet8.Architectures.Microservices.Blog.Features;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{

	#region Content

	protected IActionResult Content(object obj)
	{
		return Content(obj.ToJson(), "application/json");
	}

	#endregion
}
