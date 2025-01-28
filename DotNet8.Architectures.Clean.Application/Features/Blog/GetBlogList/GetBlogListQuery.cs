namespace DotNet8.Architectures.Clean.Application.Features.Blog.GetBlogList;

public class GetBlogListQuery : IRequest<Result<BlogListModelV1>>
{
	public int PageNo {  get; set; }
	public int PageSize {  get; set; }

	#region GetBlogListQuery

	public GetBlogListQuery(int pageNo, int pageSize)
	{
		PageNo = pageNo;
		PageSize = pageSize;
	}

	#endregion

}
