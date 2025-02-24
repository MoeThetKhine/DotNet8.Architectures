namespace DotNet8.Architectures.Microservices.Blog.Features.Blog;

public class DA_Blog
{
	private readonly AppDbContext _context;

	public DA_Blog(AppDbContext context)
	{
		_context = context;
	}

	#region GetBlogsAsync

	public async Task<Result<BlogListModelV1>> GetBlogsAsync(int pageNo, int pageSize, CancellationToken cancellationToken)
	{
		Result<BlogListModelV1> result;

		try
		{
			var query = _context.Tbl_Blogs.OrderByDescending(x => x.BlogId);
			var lst = await query
				.Paginate(pageNo, pageSize)
				.ToListAsync(cancellationToken: cancellationToken);
			var totalCount = await query.CountAsync(cancellationToken: cancellationToken);
			var pageCount = totalCount / pageSize;

			if(totalCount % pageSize > 0)
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

	#endregion

	#region GetBlogByIdAsync

	public async Task<Result<BlogModel>> GetBlogByIdAsync(int id, CancellationToken cancellationToken)
	{
		Result<BlogModel> result;

		try
		{
			var blog = await _context.Tbl_Blogs.FindAsync(
				[id, cancellationToken],
				cancellationToken: cancellationToken
				);

			if(blog is null)
			{
				result = Result<BlogModel>.NotFound();
				goto result;
			}

			result = Result<BlogModel>.Success(new BlogModel()
			{
				BlogId = blog.BlogId,
				BlogTitle = blog.BlogTitle,
				BlogAuthor = blog.BlogAuthor,
				BlogContent = blog.BlogContent,
			}
			);

		}
		catch(Exception ex)
		{
			result= Result<BlogModel>.Failure(ex);
		}
		result:
		return result;
	}

	#endregion

}
