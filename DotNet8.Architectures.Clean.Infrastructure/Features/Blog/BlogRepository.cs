using DotNet8.Architectures.Clean.Domain.Features.Blog;
using DotNet8.Architectures.DTO.Features.Blog;
using DotNet8.Architectures.DTO.PageSetting;
using DotNet8.Architectures.Shared;
using DotNet8.Architectures.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Architectures.Clean.Infrastructure.Features.Blog
{
	public class BlogRepository : IBlogRepository
	{
		private readonly BlogDbContext _context;

		public BlogRepository(BlogDbContext context)
		{
			_context = context;
		}

		public async Task<Result<BlogListModelV1>> GetBlogsAsync(int pageNo, int pageSize, CancellationToken cancellationToken)
		{
			Result<BlogListModelV1> result;

			try
			{
				var query = _context.Tbl_Blogs.OrderByDescending(x => x.BlogId);
				var lst = await query.Paginate(pageNo,pageSize)
					.ToListAsync(cancellationToken : cancellationToken);

				var totalCount = await query.CountAsync(cancellationToken : cancellationToken);
				var pageCount = totalCount / pageSize;

				if (totalCount % pageSize > 0)
				{
					pageCount++;
				}

				var pageSettingModel = new PageSettingModel(pageNo, pageSize, pageCount, totalCount);
				var model = new BlogListModelV1()
				{
					DataLst = lst.Select(x => new BlogModel()
					{
						BlogId = x.BlogId,
						BlogTitle = x.BlogTitle,
						BlogAuthor = x.BlogAuthor,
						BlogContent = x.BlogContent,
					}).AsQueryable(),
					PageSetting = pageSettingModel
				};

				result = Result<BlogListModelV1>.Success(model);

			}
			catch (Exception ex)
			{
				result = Result<BlogListModelV1>.Failure(ex);
			}

			return result;
		}
	}
}
