using System;
using System.Collections.Generic;

namespace WebAPI.Repository.Models;

public partial class TblRegistrationMembership
{
    public string MembershipId { get; set; }

    public string AccountId { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public DateTime? ExprirationDate { get; set; }

    public bool? RegistrationStatus { get; set; }

    public virtual TblAccount Account { get; set; }

    public virtual TblMembership Membership { get; set; }
}
