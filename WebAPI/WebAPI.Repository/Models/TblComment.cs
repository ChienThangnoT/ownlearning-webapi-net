using System;
using System.Collections.Generic;

namespace WebAPI.Repository.Models;

public partial class TblComment
{
    public int? BlogId { get; set; }

    public string CommentContent { get; set; }

    public DateTime? CommentDate { get; set; }

    public int? AccountId { get; set; }

    public virtual TblAccount Account { get; set; }

    public virtual TblBlog Blog { get; set; }
}
