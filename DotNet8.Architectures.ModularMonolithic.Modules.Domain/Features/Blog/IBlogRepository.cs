using DotNet8.Architectures.DTO.Features.Blog;
using DotNet8.Architectures.Utils;

namespace DotNet8.Architectures.ModularMonolithic.Modules.Domain.Features.Blog
{
	public interface IBlogRepository
	{
		Task<Result<BlogListModelV1>> GetBlogsAsync(int pageNo, int pageSize, CancellationToken cancellationToken);
	}
}
