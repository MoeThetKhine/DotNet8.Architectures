using DotNet8.Architectures.DTO.Features.Blog;
using DotNet8.Architectures.Hexgonal.Domain.Features.Blog;
using DotNet8.Architectures.Utils;
using DotNet8.Architectures.Utils.Resources;
using MediatR;

namespace DotNet8.Architectures.Hexgonal.Application.Features.Blog.GetBlogList
{
	public class GetBlogListQueryHandler : IRequestHandler<GetBlogListQuery, Result<BlogListModelV1>>
	{
		private readonly IBlogPort _blogPort;

		public GetBlogListQueryHandler(IBlogPort blogPort)
		{
			_blogPort = blogPort;
		}

		public async Task<Result<BlogListModelV1>> Handle(GetBlogListQuery request, CancellationToken cancellationToken)
		{
			Result<BlogListModelV1> result;

			try
			{
				if(request.PageNo <= 0)
				{
					result = Result<BlogListModelV1>.Fail(MessageResource.InvalidPageNo);
					goto result;
				}

				if(request.PageSize <= 0)
				{
					result = Result<BlogListModelV1>.Fail(MessageResource.InvalidPageSize);
					goto result;
				}

				result = await _blogPort.GetBlogAsync(request.PageNo, request.PageSize, cancellationToken);

			}
			catch (Exception ex)
			{
				result = Result<BlogListModelV1>.Failure(ex);
			}
			result:
			return result;
		}
	}
}
