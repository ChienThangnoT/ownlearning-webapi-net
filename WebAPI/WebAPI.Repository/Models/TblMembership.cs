using System;
using System.Collections.Generic;

namespace WebAPI.Repository.Models;

public partial class TblMembership
{
    public int MembershipId { get; set; }

    public string? MembershipName { get; set; }

    public int? MembershipDuration { get; set; }

    public decimal? MembershipPrice { get; set; }

    public string MembershipDescription { get; set; }

    public int? MembershipDiscours { get; set; }

    public bool? MembershipIsActive { get; set; }

    public virtual ICollection<TblBillMembership> TblBillMemberships { get; set; } = new List<TblBillMembership>();

    public virtual ICollection<TblRegistrationMembership> TblRegistrationMemberships { get; set; } = new List<TblRegistrationMembership>();
}
