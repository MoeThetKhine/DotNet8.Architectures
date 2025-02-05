namespace DotNet8.Architectures.Hexgonal.Application.Features.Blog.DeleteBlog
{
	public class DeleteBlogCommand : IRequest<Result<BlogModel>>
	{
		public int BlogId {  get; set; }

		public DeleteBlogCommand(int blogId)
		{
			BlogId = blogId;
		}
	}
}
