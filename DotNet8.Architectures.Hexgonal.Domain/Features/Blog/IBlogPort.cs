namespace DotNet8.Architectures.Hexgonal.Domain.Features.Blog;

#region IBlogPort

public interface IBlogPort
{
	Task<Result<BlogListModelV1>> GetBlogAsync(int pageNo, int pageSize, CancellationToken cancellationToken);
}

#endregion