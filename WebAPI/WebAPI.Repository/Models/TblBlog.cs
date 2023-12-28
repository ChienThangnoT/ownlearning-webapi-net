using System;
using System.Collections.Generic;

namespace WebAPI.Repository.Models;

public partial class TblBlog
{
    public int BlogId { get; set; }

    public string? BlogTitle { get; set; }

    public string? BlogDetail { get; set; }

    public string? AccountId { get; set; }

    public DateTime? BlogDate { get; set; }

    public string? BlogImg { get; set; }

    public virtual TblAccount Account { get; set; }
}
