namespace DotNet8.Architectures.Clean.Infrastructure.Features.Blog;

#region BlogDbContext

public class BlogDbContext : DbContext
{
    public BlogDbContext(DbContextOptions options)
   : base(options) { }

    public DbSet<Tbl_Blog> Tbl_Blogs { get; set; }
}

#endregion