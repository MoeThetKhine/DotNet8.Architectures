using DotNet8.Architectures.ModularMonolithic.Modules.Application.Features.Blog.DeleteBlog;
using DotNet8.Architectures.ModularMonolithic.Modules.Application.Features.Blog.PatchBlog;

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

	#region UpdateBlog

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateBlog([FromBody] BlogRequestModel requestModel, int id , CancellationToken cancellationToken)
	{
		var command = new UpdateBlogCommand(requestModel, id);
		var result = await _mediator.Send(command,cancellationToken);

		return Content(result);
	}

	#endregion

	[HttpPatch("{id}")]
	public async Task<IActionResult> PatchBlog([FromBody] BlogRequestModel requestModel, int id, CancellationToken cancellationToken)
	{
		var command = new PatchBlogCommand(requestModel, id);
		var result = await _mediator.Send(command, cancellationToken);
		return Content(result);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteBlog(int id, CancellationToken cancellationToken)
	{
		var command = new DeleteBlogCommand(id);
		var result = await _mediator.Send(command, cancellationToken);
		return Content(result);
	}

}
