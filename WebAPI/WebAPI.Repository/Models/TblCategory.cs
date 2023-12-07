using System;
using System.Collections.Generic;

namespace WebAPI.Repository.Models;

public partial class TblCategory
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public bool? CategoryIsActive { get; set; }

    public virtual ICollection<TblCourse> TblCourses { get; set; } = new List<TblCourse>();
}
