using DotNet8.Architectures.DTO.PageSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Architectures.DTO.Features.Blog
{
    public class BlogListModel
    {
        public IEnumerable<BlogModel> DataLst { get; set; }
        public PageSettingModel PageSetting { get; set; }
    }
}
