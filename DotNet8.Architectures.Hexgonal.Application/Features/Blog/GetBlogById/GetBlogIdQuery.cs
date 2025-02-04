namespace DotNet8.Architectures.Hexgonal.Application.Features.Blog.GetBlogById;

#region GetBlogIdQuery

public class GetBlogIdQuery : IRequest<Result<BlogModel>>
{
	public int BlogId {  get; set; }

	public GetBlogIdQuery(int blogId)
	{
		BlogId = blogId;
	}	
}

#endregion