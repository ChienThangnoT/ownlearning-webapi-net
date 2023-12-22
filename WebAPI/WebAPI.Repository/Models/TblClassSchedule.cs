using System;
using System.Collections.Generic;

namespace WebAPI.Repository.Models;

public partial class TblClassSchedule
{
    public int? RegistrationId { get; set; }

    public int ClassScheduleId { get; set; }

    public DateTime? ClassDate { get; set; }

    public TimeSpan? SlotStartTime { get; set; }

    public TimeSpan? SlotEndTime { get; set; }

    public int? ClassStatus { get; set; }

    public virtual TblRegistrationCourse Registration { get; set; }
}
