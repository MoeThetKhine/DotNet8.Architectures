namespace DotNet8.Architectures.Clean.Domain.Features.Blog
{
    public interface IBlogRepository
    {
        Task <Result<BlogListModelV1>> GetBlogAsync(int pageNo, int pageSize, CancellationToken cancellationToken);
        
    }
}
