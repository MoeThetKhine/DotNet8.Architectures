namespace DotNet8.Architectures.Hexgonal.Application.Features.Blog.GetBlogById;

#region GetBlogIdQuery

public class GetBlogByIdQuery : IRequest<Result<BlogModel>>
{
	public int BlogId {  get; set; }

	public GetBlogByIdQuery(int blogId)
	{
		BlogId = blogId;
	}	
}

#endregion