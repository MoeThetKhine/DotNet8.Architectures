namespace DotNet8.Architectures.ModularMonolithic.Modules.Application.Features.Blog.UpdateBlog;

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
