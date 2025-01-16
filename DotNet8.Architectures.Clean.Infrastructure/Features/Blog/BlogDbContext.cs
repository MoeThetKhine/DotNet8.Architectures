using DotNet8.Architectures.BusinessLogic.Features.Blog;

namespace DotNet8.Architectures.Clean.Infrastructure.Features.Blog;

#region BlogDbContext

public class BlogDbContext : DbContext
{
    public BlogDbContext(DbContextOptions options)
   : base(options) { }

    public DbSet<BL_Blog> Tbl_Blogs { get; set; }
}

#endregion