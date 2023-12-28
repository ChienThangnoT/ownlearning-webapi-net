using System;
using System.Collections.Generic;

namespace WebAPI.Repository.Models;

public partial class TblCourse
{
    public int CourseId { get; set; }

    public string? CourseTitle { get; set; }

    public string? CourseDetail { get; set; }

    public int? CourseDuration { get; set; }

    public string? CourseImg { get; set; }

    public int? CategoryId { get; set; }

    public decimal? CoursePrice { get; set; }

    public bool? CourseIsActive { get; set; }

    public string? AccountId { get; set; }

    public virtual TblAccount Account { get; set; }

    public virtual TblCategory Category { get; set; }

    public virtual ICollection<TblBill> TblBills { get; set; } = new List<TblBill>();

    public virtual ICollection<TblCourseSchedule> TblCourseSchedules { get; set; } = new List<TblCourseSchedule>();

    public virtual ICollection<TblRatingCourse> TblRatingCourses { get; set; } = new List<TblRatingCourse>();

    public virtual ICollection<TblRegistrationCourse> TblRegistrationCourses { get; set; } = new List<TblRegistrationCourse>();

    public virtual ICollection<TblAccount> Accounts { get; set; } = new List<TblAccount>();
}
