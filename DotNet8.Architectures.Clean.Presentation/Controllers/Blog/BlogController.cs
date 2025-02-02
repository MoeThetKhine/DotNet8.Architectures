using DotNet8.Architectures.Clean.Application.Features.Blog.UpdateBlog;

namespace DotNet8.Architectures.Clean.Presentation.Controllers.Blog;

[Route("api/[controller]")]
[ApiController]
public class BlogController : BaseController
{
	private readonly IMediator _mediator;

	public BlogController(IMediator mediator)
	{
		_mediator = mediator;
	}

	#region GetBlogAsync

	[HttpGet]
	public async Task<IActionResult> GetBlogAsync(int pageNo, int pageSize, CancellationToken cancellationToken)
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
		var result = await _mediator.Send(query,cancellationToken);

		return Content(result);
	}

	#endregion

	#region CreateBlogAsync

	[HttpPost]
	public async Task<IActionResult> CreateBlogAsync([FromBody] BlogRequestModel requestModel, CancellationToken cancellationToken)
	{
		var command = new CreateBlogCommand(requestModel);
		var result = await _mediator.Send(command, cancellationToken);	

		return Content(result);
	}

	#endregion

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateBlog([FromBody]BlogRequestModel requestModel, int id,CancellationToken cancellationToken)
	{
		var command = new UpdateBlogCommand( requestModel , id);
		var result = await _mediator.Send(command,cancellationToken);

		return Content(result);
	}

}
