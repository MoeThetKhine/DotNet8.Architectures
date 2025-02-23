using DotNet8.Architectures.DbServices.Models;

namespace DotNet8.Architectures.Microservices.Blog.Features.Blog
{
	public class DA_Blog
	{
		private readonly AppDbContext _context;

		public DA_Blog(AppDbContext context)
		{
			_context = context;
		}
	}
}
