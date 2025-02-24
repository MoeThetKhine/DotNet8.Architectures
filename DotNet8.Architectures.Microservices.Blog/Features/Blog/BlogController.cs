using Microsoft.AspNetCore.Mvc;

namespace DotNet8.Architectures.Microservices.Blog.Features.Blog
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogController : ControllerBase
	{
		private readonly DA_Blog _dA_Blog;

		public BlogController(DA_Blog dA_Blog)
		{
			_dA_Blog = dA_Blog;
		}


	}
}
