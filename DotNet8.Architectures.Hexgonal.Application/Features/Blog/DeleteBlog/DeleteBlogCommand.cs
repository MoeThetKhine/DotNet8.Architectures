using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Architectures.Hexgonal.Application.Features.Blog.DeleteBlog
{
	public class DeleteBlogCommand : IRequest<Result<BlogModel>>
	{
		public int BlogId {  get; set; }

		public DeleteBlogCommand(int blogId)
		{
			BlogId = blogId;
		}
	}
}
