namespace DotNet8.Architectures.Hexgonal.Application.Features.Blog.GetBlogById;

public class GetBlogIdQueryHandler : IRequestHandler<GetBlogByIdQuery, Result<BlogModel>>
{
	private readonly IBlogPort _blogPort;

	public GetBlogIdQueryHandler(IBlogPort blogPort)
	{
		_blogPort = blogPort;
	}

	#region Handle

	public async Task<Result<BlogModel>> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
	{
		Result<BlogModel> result;

		if (request.BlogId <= 0)
		{
			result = Result<BlogModel>.Fail(MessageResource.InvalidId);
			goto result;
		}

		result = await _blogPort.GetBlogByIdAsync(request.BlogId, cancellationToken);
			
		result:
		return result;
	}

	#endregion

}
