namespace DotNet8.Architectures.Clean.Domain.Features.Blog;

#region IBlogRepository

public interface IBlogRepository
{
	Task<Result<BlogListModelV1>> GetBlogsAsync(int pageNo, int pageSize, CancellationToken cancellationToken);
}

#endregion