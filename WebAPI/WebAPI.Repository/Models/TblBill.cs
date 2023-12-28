using System;
using System.Collections.Generic;

namespace WebAPI.Repository.Models;

public partial class TblBill
{
    public int? CourseId { get; set; }

    public string? AccountId { get; set; }

    public int BillId { get; set; }

    public int? BillStatus { get; set; }

    public bool? BillIsActive { get; set; }

    public decimal? BillValue { get; set; }

    public int? BillDiscount { get; set; }

    public DateTime? BillDate { get; set; }

    public string OrderCode { get; set; }

    public string PaymentMethod { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual TblAccount Account { get; set; }

    public virtual TblCourse Course { get; set; }
}
