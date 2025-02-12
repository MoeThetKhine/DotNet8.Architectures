namespace DotNet8.Architectures.ModularMonolithic.Modules.Application.Features.Blog.DeleteBlog;

public class DeleteBlogCommand : IRequest<Result<BlogModel>>
{
	public int BlogId { get; set; }

	#region DeleteBlogCommand

	public DeleteBlogCommand(int blogId)
	{
		BlogId = blogId;
	}

	#endregion

}
