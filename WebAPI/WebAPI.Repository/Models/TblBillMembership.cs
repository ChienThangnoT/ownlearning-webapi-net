using System;
using System.Collections.Generic;

namespace WebAPI.Repository.Models;

public partial class TblBillMembership
{
    public int? MembershipId { get; set; }

    public int? AccountId { get; set; }

    public int BillMemId { get; set; }

    public int? BillStatus { get; set; }

    public bool? BillIsActive { get; set; }

    public decimal? BillValue { get; set; }

    public int? BillDiscount { get; set; }

    public DateTime? BillDate { get; set; }

    public string OrderCode { get; set; }

    public string PaymentMethod { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual TblAccount Account { get; set; }

    public virtual TblMembership Membership { get; set; }
}
