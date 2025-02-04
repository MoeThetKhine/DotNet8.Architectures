using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Architectures.Hexgonal.Application.Features.Blog.GetBlogById
{
	public class GetBlogIdQuery : IRequest<Result<BlogModel>>
	{
		public int BlogId {  get; set; }

		public GetBlogIdQuery(int blogId)
		{
			BlogId = blogId;
		}	
	}
}
