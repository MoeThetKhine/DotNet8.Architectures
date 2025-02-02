using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Architectures.Clean.Application.Features.Blog.CreateBlog
{
	public class CreateBlogCommand : IRequest<Result<BlogModel>>
	{
		public BlogRequestModel requestModel;

		public CreateBlogCommand(BlogRequestModel requestModel)
		{
			this.requestModel = requestModel;
		}
	}

}
