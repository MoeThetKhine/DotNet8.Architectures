using DotNet8.Architectures.DTO.PageSetting;

namespace DotNet8.Architectures.DTO.Features.Blog;


public class BlogListModel
{
    public IEnumerable<BlogModel> DataLst { get; set; }
    public PageSettingModel PageSetting { get; set; }
}

public class  BlogListModelV1
{

public IQueryable<BlogModel>DataLst { get; set; }
public PageSettingModel PageSetting { get; set; }

}
