namespace DotNet8.Architectures.Hexgonal.Domain.Features.Blog;

#region IBlogPort

public interface IBlogPort
{
	Task<Result<BlogListModelV1>> GetBlogAsync(int pageNo, int pageSize, CancellationToken cancellationToken);

	Task<Result<BlogModel>> GetBlogByIdAsync(int id, CancellationToken cancellationToken);

	Task<Result<BlogModel>> CreateBlogAsync(BlogRequestModel blogRequest, CancellationToken cancellationToken);

	Task<Result<BlogModel>> UpdateBlogAsync(int id ,BlogRequestModel requestModel, CancellationToken cancellationToken);

	Task<Result<BlogModel>> PatchBlogAsync(BlogRequestModel requestModel, int id , CancellationToken cancellationToken);
}

#endregion