namespace DotNet8.Architectures.ModularMonolithic.Modules.Application.Features.Blog.CreateBlog;

public class CreateBlogCommand : IRequest<Result<BlogModel>>
{
	public BlogRequestModel requestModel;

	#region CreateBlogCommand

	public CreateBlogCommand(BlogRequestModel requestModel)
	{
		this.requestModel = requestModel;
	}

	#endregion

}
