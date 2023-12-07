using System;
using System.Collections.Generic;

namespace WebAPI.Repository.Models;

public partial class TblCourseSchedule
{
    public int? CourseId { get; set; }

    public int CourseScheduleId { get; set; }

    public string? DayOfWeek { get; set; }

    public TimeSpan? StartTime { get; set; }

    public TimeSpan? EndTime { get; set; }

    public bool? IsActive { get; set; }

    public virtual TblCourse Course { get; set; }

    public virtual ICollection<TblRegistrationCourse> TblRegistrationCourses { get; set; } = new List<TblRegistrationCourse>();
}
