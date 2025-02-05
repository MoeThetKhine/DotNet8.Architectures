namespace DotNet8.Architectures.Hexgonal.Application.Features.Blog.UpdateBlog;

public class UpdateBlogCommand : IRequest<Result<BlogModel>>
{
	public BlogRequestModel requestModel { get; set; }
	public int BlogId {  get; set; }

	#region UpdateBlogCommand

	public UpdateBlogCommand(BlogRequestModel requestModel, int blogId)
	{
		this.requestModel = requestModel;
		BlogId = blogId;
	}

	#endregion

}
