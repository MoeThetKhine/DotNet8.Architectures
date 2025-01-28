using DotNet8.Architectures.DTO.Features.Blog;
using DotNet8.Architectures.Utils;
using MediatR;

namespace DotNet8.Architectures.Clean.Application.Features.Blog.GetBlogList
{
	public class GetBlogListQuery : IRequest<Result<BlogListModelV1>>
	{
		public int PageNo {  get; set; }
		public int PageSize {  get; set; }

		public GetBlogListQuery(int pageNo, int pageSize)
		{
			PageNo = pageNo;
			PageSize = pageSize;
		}
	}
}
