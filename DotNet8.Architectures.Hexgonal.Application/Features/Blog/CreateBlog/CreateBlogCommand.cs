namespace DotNet8.Architectures.Hexgonal.Application.Features.Blog.CreateBlog;

#region CreateBlogCommand

public class CreateBlogCommand : IRequest<Result<BlogModel>>
{
	public BlogRequestModel requestModel;

	public CreateBlogCommand(BlogRequestModel requestModel)
	{
		this.requestModel = requestModel;
	}
}

#endregion
