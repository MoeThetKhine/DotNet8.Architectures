using System.ComponentModel.DataAnnotations;

namespace DotNet8.Architectures.DbServices.Models;

#region TblBlog

public partial class TblBlog
{
    [Key]
    public int BlogId { get; set; }

    public string BlogTitle { get; set; } = null!;

    public string BlogAuthor { get; set; } = null!;

    public string BlogContent { get; set; } = null!;

    public bool DeleteFlag { get; set; }
}

#endregion