namespace DotNet8.Architectures.Hexgonal.Api.Controllers.Blog;

[Route("api/[controller]")]
[ApiController]
public class BlogController : BaseController
{
	private readonly IMediator _mediator;

	public BlogController(IMediator mediator)
	{
		_mediator = mediator;
	}

	#region Get Blogs

	[HttpGet]
	public async Task<IActionResult> GetBlogs(int pageNo, int pageSize, CancellationToken cancellationToken)
	{
		var query = new GetBlogListQuery(pageNo,pageSize);
		var result = await _mediator.Send(query, cancellationToken);

		return Content(result);
	}

	#endregion

	#region Get Blog By Id

	[HttpGet("{id}")]
	public async Task<IActionResult> GetBlogById(int id,CancellationToken cancellationToken)
	{
		var query = new GetBlogByIdQuery(id);
		var result = await _mediator.Send(query,cancellationToken);
		return Content(result);
	}

	#endregion

	#region Create Blog

	public async Task<IActionResult> CreateBlog([FromBody] BlogRequestModel requestModel, CancellationToken cancellationToken)
	{
		var command = new CreateBlogCommand(requestModel);
		var result = await _mediator.Send(command, cancellationToken);
	
		return Content(result);
	}

	#endregion

	#region Update Blog

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateBlog([FromBody]int id, BlogRequestModel requestModel, CancellationToken cancellationToken)
	{
		var command = new UpdateBlogCommand(requestModel, id);
		var result = await _mediator.Send(command,cancellationToken);

		return Content(result);
	}

	#endregion

	#region PatchBlog

	[HttpPatch("{id}")]
	public async Task<IActionResult> PatchBlog([FromBody] BlogRequestModel requestModel, int id , CancellationToken cancellationToken)
	{
		var command = new PatchBlogCommand(requestModel, id);
		var result = await _mediator.Send(command, cancellationToken);
		return Content(result);
	}

	#endregion

}
