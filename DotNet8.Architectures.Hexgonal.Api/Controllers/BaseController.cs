namespace DotNet8.Architectures.Hexgonal.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{

	#region Content

	public IActionResult Content(Object obj)
	{
		return Content(obj.ToJson(), "application/json");
	}

	#endregion

}
