using System;
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
