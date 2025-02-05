using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Architectures.Hexgonal.Application.Features.Blog.UpdateBlog
{
	public class UpdateBlogCommand : IRequest<Result<BlogModel>>
	{
		public BlogRequestModel requestModel { get; set; }
		public int BlogId {  get; set; }

		public UpdateBlogCommand(BlogRequestModel requestModel, int blogId)
		{
			this.requestModel = requestModel;
			BlogId = blogId;
		}
	}
}
