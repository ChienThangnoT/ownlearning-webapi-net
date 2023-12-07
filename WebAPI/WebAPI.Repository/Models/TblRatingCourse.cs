using System;
using System.Collections.Generic;

namespace WebAPI.Repository.Models;

public partial class TblRatingCourse
{
    public int RegistrationId { get; set; }

    public int? RatingStar { get; set; }

    public string? Feedback { get; set; }

    public int? CourseId { get; set; }

    public virtual TblCourse Course { get; set; }

    public virtual TblRegistrationCourse Registration { get; set; }
}
