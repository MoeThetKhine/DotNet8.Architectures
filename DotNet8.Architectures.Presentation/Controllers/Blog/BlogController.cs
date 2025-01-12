using DotNet8.Architectures.DTO.Features.Blog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.Architectures.Presentation.Controllers.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : BaseController
    {
        private readonly BL_Blog _bL_Blog;

        public BlogController(BL_Blog bL_Blog)
        {
            _bL_Blog = bL_Blog;
        }
        [HttpGet]
        public async Task<IActionResult> GetBlogAsync(int pageNo, int pageSize , CancellationToken cancellationToken)
        {
            var result = await _bL_Blog.GetBlogAsync(pageNo, pageSize, cancellationToken);
            return Content(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogAsync([FromBody] BlogRequestModel blogRequest, CancellationToken cancellationToken)
        {
            var result = await _bL_Blog.AddBlogAsync(blogRequest, cancellationToken);
            return Content(result);
        }
    }
}
