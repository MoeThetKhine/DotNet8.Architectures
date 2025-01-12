namespace DotNet8.Architectures.Presentation.Controllers.Blog;

[Route("api/[controller]")]
[ApiController]
public class BlogController : BaseController
{
    private readonly BL_Blog _bL_Blog;

    public BlogController(BL_Blog bL_Blog)
    {
        _bL_Blog = bL_Blog;
    }

    #region GetBlogAsync

    [HttpGet]
    public async Task<IActionResult> GetBlogAsync(int pageNo, int pageSize , CancellationToken cancellationToken)
    {
        var result = await _bL_Blog.GetBlogAsync(pageNo, pageSize, cancellationToken);
        return Content(result);
    }

    #endregion

    #region CreateBlogAsync

    [HttpPost]
    public async Task<IActionResult> CreateBlogAsync([FromBody] BlogRequestModel blogRequest, CancellationToken cancellationToken)
    {
        var result = await _bL_Blog.AddBlogAsync(blogRequest, cancellationToken);
        return Content(result);
    }

    #endregion

    #region PatchBlogAsync

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchBlogAsync([FromBody] int id , BlogRequestModel blogRequest, CancellationToken cancellationToken)
    {
        var result = await _bL_Blog.PatchBlogAsync(id, blogRequest, cancellationToken);
        return Content(result);
    }

    #endregion

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBlogAsync([FromBody] int id , BlogRequestModel blogRequest , CancellationToken cancellationToken)
    {
        var result = await _bL_Blog.UpdateBlogAsync(id, blogRequest, cancellationToken); 
        return Content(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBlogAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _bL_Blog.DeleteBlogAsync(id, cancellationToken);
        return Content(result);
    }
}
