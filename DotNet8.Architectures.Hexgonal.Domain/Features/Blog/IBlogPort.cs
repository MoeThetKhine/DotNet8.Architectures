using DotNet8.Architectures.DTO.Features.Blog;
using DotNet8.Architectures.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Architectures.Hexgonal.Domain.Features.Blog
{
	public interface IBlogPort
	{
		Task<Result<BlogListModelV1>> GetBlogAsync(int pageNo, int pageSize, CancellationToken cancellationToken);
	}
}
	