using DotNet8.Architectures.Extensions;

namespace DotNet8.Architectures.Hexgonal.Infracture.Features.Blog;

public class BlogAdapter : IBlogPort
{
	private readonly AppDbContext _context;

	public BlogAdapter(AppDbContext context)
	{
		_context = context;
	}

	#region GetBlogAsync

	public async Task<Result<BlogListModelV1>> GetBlogAsync(int pageNo, int pageSize, CancellationToken cancellationToken)
	{
		Result<BlogListModelV1> result;

		try
		{
			var query = _context.Tbl_Blogs.OrderByDescending(x => x.BlogId);
			var lst = await query.Paginate(pageNo,pageSize)
				.ToListAsync(cancellationToken: cancellationToken);
			var totalCount = await query.CountAsync(cancellationToken);
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
			var blog = await _context.Tbl_Blogs.FindAsync([id, cancellationToken], cancellationToken: cancellationToken);

			if (blog is null)
			{
				result = Result<BlogModel>.NotFound();
				goto result;
			}

			result = Result<BlogModel>.Success(new BlogModel()
			{
				BlogId = blog.BlogId,
				BlogTitle = blog.BlogTitle,
				BlogAuthor = blog.BlogAuthor,
				BlogContent = blog.BlogContent
			});
		}
		catch(Exception ex)
		{
			result = Result<BlogModel>.Failure(ex);
		}

		result:
		return result;
	}

	#endregion

	#region CreateBlogAsync

	public async Task<Result<BlogModel>> CreateBlogAsync(BlogRequestModel blogRequest, CancellationToken cancellationToken)
	{
		Result<BlogModel> result;

		try
		{
			await _context.Tbl_Blogs.AddAsync(blogRequest.ToEntity(), cancellationToken);
			await _context.SaveChangesAsync(cancellationToken);

			result = Result<BlogModel>.Success();
		}
		catch (Exception ex)
		{
			result = Result<BlogModel>.Failure(ex);
		}

	result:
		return result;
	}

	#endregion

	#region UpdateBlogAsync

	public async Task<Result<BlogModel>> UpdateBlogAsync(int id, BlogRequestModel requestModel, CancellationToken cancellationToken)
	{
		Result<BlogModel> result;

		try
		{
			var blog = await _context.Tbl_Blogs.FindAsync([id, cancellationToken], cancellationToken: cancellationToken);

			if(blog is null)
			{
				result = Result<BlogModel>.NotFound();
				goto result;
			}

			blog.BlogTitle = requestModel.BlogTitle;
			blog.BlogAuthor = requestModel.BlogAuthor;
			blog.BlogContent = requestModel.BlogContent;

			_context.Tbl_Blogs.Update(blog);
			await _context.SaveChangesAsync(cancellationToken);

			result = Result<BlogModel>.UpdateSuccess();

		}
		catch(Exception ex)
		{
			result = Result<BlogModel>.Failure(ex);
		}
	result:
		return result;
	}

	#endregion

	#region PatchBlogAsync

	public async Task<Result<BlogModel>> PatchBlogAsync(BlogRequestModel requestModel, int id, CancellationToken cancellationToken)
	{
		Result<BlogModel> result;

		try
		{
			var blog = await _context.Tbl_Blogs.FindAsync([id,cancellationToken],cancellationToken: cancellationToken);

			#region Validation

			if (blog is null)
			{
				result = Result<BlogModel>.NotFound();
				goto result;
			}

			if(!requestModel.BlogTitle.IsNullOrEmpty())
			{
				blog.BlogTitle = requestModel.BlogTitle;
			}

			if (!requestModel.BlogAuthor.IsNullOrEmpty())
			{
				blog.BlogAuthor = requestModel.BlogAuthor;
			}
			if(!requestModel.BlogContent.IsNullOrEmpty())
			{
				blog.BlogContent = requestModel.BlogContent;
			}

			#endregion

			_context.Tbl_Blogs.Update(blog);
			await _context.SaveChangesAsync(cancellationToken);

			result = Result<BlogModel>.UpdateSuccess();
		}
		catch (Exception ex)
		{
			result = Result<BlogModel>.Failure(ex);
		}

	result:
		return result;
	}

	#endregion

	#region DeleteBlogAsync

	public async Task<Result<BlogModel>> DeleteBlogAsync(int id, CancellationToken cancellationToken)
	{
		Result<BlogModel> result;

		try
		{
			var blog = await _context.Tbl_Blogs.FindAsync([id, cancellationToken],cancellationToken: cancellationToken);
			if(blog is null)
			{
				result = Result<BlogModel>.NotFound();
				goto result;
			}

			_context.Tbl_Blogs.Remove(blog);
			await _context.SaveChangesAsync(cancellationToken);

			result = Result<BlogModel>.DeleteSuccess();
		}
		catch (Exception ex)
		{
			result = Result<BlogModel>.Failure(ex);
		}

	result:
		return result;
	}

	#endregion
}
