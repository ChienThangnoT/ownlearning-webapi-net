using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Repository.Models;

public partial class TblAccount : IdentityUser
{
    public int AccountId { get; set; }

    public string? AccountImg { get; set; }
                                                                                                              
    public string? AccountName { get; set; }

    public string? AccountEmail { get; set; }

    public string? AccountPhone { get; set; }

    public bool? AccountIsActive { get; set; }

    public string? SocialId { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? Biography { get; set; }

    public virtual ICollection<TblBillMembership> TblBillMemberships { get; set; } = new List<TblBillMembership>();

    public virtual ICollection<TblBill> TblBills { get; set; } = new List<TblBill>();

    public virtual ICollection<TblBlog> TblBlogs { get; set; } = new List<TblBlog>();

    public virtual ICollection<TblCourse> TblCourses { get; set; } = new List<TblCourse>();

    public virtual ICollection<TblRegistrationCourse> TblRegistrationCourses { get; set; } = new List<TblRegistrationCourse>();

    public virtual ICollection<TblRegistrationMembership> TblRegistrationMemberships { get; set; } = new List<TblRegistrationMembership>();

    public virtual ICollection<TblCourse> Courses { get; set; } = new List<TblCourse>();
}
