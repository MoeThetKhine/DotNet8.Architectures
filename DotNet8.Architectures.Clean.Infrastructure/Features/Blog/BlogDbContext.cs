using DotNet8.Architectures.DbServices.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.Architectures.Clean.Infrastructure.Features.Blog;

public class BlogDbContext : DbContext
{
	public BlogDbContext(DbContextOptions options) : base(options) { }

	public DbSet<TblBlog> Tbl_Blogs { get; set; }
}
