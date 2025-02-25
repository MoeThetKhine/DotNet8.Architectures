namespace DotNet8.Architectures.Microservices.Blog.Features.Blog;

[Route("api/[controller]")]
[ApiController]
public class BlogController : BaseController
{
	private readonly DA_Blog _dA_Blog;

	public BlogController(DA_Blog dA_Blog)
	{
		_dA_Blog = dA_Blog;
	}

	#region GetBlogs

	[HttpGet]
	public async Task<IActionResult> GetBlogs(int pageNo, int pageSize, CancellationToken cancellationToken)
	{
		var result = await _dA_Blog.GetBlogsAsync(pageNo, pageSize, cancellationToken);
		return Content(result);
	}

	#endregion

	#region GetBlogById

	[HttpGet("{id}")]
	public async Task<IActionResult> GetBlogById(int id, CancellationToken cancellationToken)
	{
		var result = await _dA_Blog.GetBlogByIdAsync(id, cancellationToken);
		return Content(result);
	}

	#endregion

	#region CreateBlog

	[HttpPost]
	public async Task<IActionResult> CreateBlog([FromBody] BlogRequestModel blogRequest, CancellationToken cancellationToken)
	{
		var result = await _dA_Blog.AddBlogAsync(blogRequest, cancellationToken);
		return Content(result);
	}

	#endregion

	#region UpdateBlog

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateBlog([FromBody] BlogRequestModel blogRequest, int id , CancellationToken cancellationToken)
	{
		var result = await _dA_Blog.UpdateBlogAsync(blogRequest, id, cancellationToken);
		return Content(result);
	}

	#endregion

	[HttpPatch("{id}")]
	public async Task<IActionResult> PatchBlog([FromBody] BlogRequestModel blogRequest, int id, CancellationToken cancellationToken)
	{
		var result = await _dA_Blog.PatchBlogAsync(blogRequest, id, cancellationToken);
		return Content(result);

	}

}
