using DotNet8.Architectures.DbServices.Models;
using DotNet8.Architectures.DTO.Features.Blog;
using DotNet8.Architectures.DTO.PageSetting;
using DotNet8.Architectures.ModularMonolithic.Modules.Domain.Features.Blog;
using DotNet8.Architectures.Shared;
using DotNet8.Architectures.Utils;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.Architectures.ModularMonolithic.Modules.Infrastructure.Features.Blog;

public class BlogRepository : IBlogRepository
{
	private readonly AppDbContext _context;

	public BlogRepository(AppDbContext context)
	{
		_context = context;
	}

	#region GetBlogsAsync

	public async Task<Result<BlogListModelV1>> GetBlogsAsync(int pageNo, int pageSize, CancellationToken cancellationToken)
	{
		Result<BlogListModelV1> result;

		try
		{
			var query = _context.Tbl_Blogs.OrderByDescending(x=> x.BlogId);
			var lst = await query.Paginate(pageNo, pageSize)
				.ToListAsync(cancellationToken : cancellationToken);

			var totalCount = await query.CountAsync(cancellationToken: cancellationToken);
			var pageCount = totalCount / pageSize;

			if(totalCount %  pageSize > 0)
			{
				pageCount++;
			}

			var pageSettingModel = new PageSettingModel(pageNo, pageSize, totalCount);
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
		}

		catch (Exception ex)
		{
			result = Result<BlogListModelV1>.Failure(ex);
		}
		return result;
	}

	#endregion

}
