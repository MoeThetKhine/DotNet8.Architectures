using DotNet8.Architectures.DbServices.Models;
using DotNet8.Architectures.DTO.Features.Blog;
using System.Runtime.CompilerServices;

namespace DotNet8.Architectures.Extensions;

public static class Extension
{
    public static BlogModel ToModel(this TblBlog dataModel)
    {
        return new BlogModel
        {
            BlogId = dataModel.BlogId,
            BlogTitle = dataModel.BlogTitle,
            BlogAuthor = dataModel.BlogAuthor,
            BlogContent = dataModel.BlogContent,
            DeleteFlag = dataModel.DeleteFlag
        };
    }
}
