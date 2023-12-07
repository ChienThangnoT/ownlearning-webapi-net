using System;
using System.Collections.Generic;

namespace WebAPI.Repository.Models;

public partial class TblRegistrationCourse
{
    public int? CourseId { get; set; }

    public int? AccountId { get; set; }

    public int RegistrationId { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? CourseStatus { get; set; }

    public int? CourseScheduleId { get; set; }

    public bool? RegistrationStatus { get; set; }

    public virtual TblAccount Account { get; set; }

    public virtual TblCourse Course { get; set; }

    public virtual TblCourseSchedule CourseSchedule { get; set; }

    public virtual ICollection<TblClassSchedule> TblClassSchedules { get; set; } = new List<TblClassSchedule>();

    public virtual TblRatingCourse TblRatingCourse { get; set; }
}
