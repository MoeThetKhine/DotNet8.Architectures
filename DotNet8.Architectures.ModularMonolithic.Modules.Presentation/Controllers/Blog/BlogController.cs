using DotNet8.Architectures.DTO.Features.Blog;
using DotNet8.Architectures.ModularMonolithic.Modules.Application.Features.Blog.CreateBlog;

namespace DotNet8.Architectures.ModularMonolithic.Modules.Presentation.Controllers.Blog;

[Route("api/[controller]")]
[ApiController]
public class BlogController : BaseController
{
	private readonly IMediator _mediator;

	public BlogController(IMediator mediator)
	{
		_mediator = mediator;
	}

	#region GetBlogs

	[HttpGet]
	public async Task<IActionResult> GetBlogs(int pageNo, int pageSize, CancellationToken cancellationToken)
	{
		var query = new GetBlogListQuery(pageNo, pageSize);
		var result = await _mediator.Send(query, cancellationToken);

		return Content(result);
	}

	#endregion

	#region GetBlogById

	[HttpGet("{id}")]
	public async Task<IActionResult> GetBlogById(int id, CancellationToken cancellationToken)
	{
		var query = new GetBlogByIdQuery(id);
		var result = await _mediator.Send(query, cancellationToken);

		return Content(result);
	}

	#endregion

	#region CreateBlog

	[HttpPost]
	public async Task<IActionResult> CreateBlog([FromBody] BlogRequestModel requestModel, CancellationToken cancellationToken)
	{
		var command = new CreateBlogCommand(requestModel); ;
		var result = await _mediator.Send(command, cancellationToken);

		return Content(result);
	}

	#endregion

}
