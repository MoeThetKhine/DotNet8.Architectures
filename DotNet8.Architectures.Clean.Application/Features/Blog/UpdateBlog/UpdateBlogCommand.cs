using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Architectures.Clean.Application.Features.Blog.UpdateBlog
{
	public class UpdateBlogCommand : IRequest<Result<BlogModel>>
	{
		public BlogRequestModel RequestModel { get; set; }
		public int BlogId {  get; set; }

		public UpdateBlogCommand(BlogRequestModel requestModel, int blogId)
		{
			RequestModel = requestModel;
			BlogId = blogId;
		}
	}
}
