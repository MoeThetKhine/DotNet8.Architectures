using DotNet8.Architectures.Clean.Domain.Features.Blog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Architectures.Clean.Infrastructure.Features.Blog
{
	public class BlogDbContext : DbContext
	{
		public BlogDbContext(DbContextOptions options) : base(options) { }

		public DbSet<Tbl_Blog> Tbl_Blogs { get; set; }
	}
}
