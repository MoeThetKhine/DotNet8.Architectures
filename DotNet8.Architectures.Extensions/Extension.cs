using DotNet8.Architectures.DbServices.Models;
using DotNet8.Architectures.DTO.Features.Blog;

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

    public static TblBlog ToEntity(this BlogRequestModel model)
    {
        return new TblBlog
        {
            BlogTitle = model.BlogTitle,
            BlogAuthor = model.BlogAuthor,
            BlogContent = model.BlogContent
        };
    }
}
