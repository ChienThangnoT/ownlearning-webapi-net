using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repository.Models;

public partial class AllActorsFemaleInJapanContext : DbContext
{
    public AllActorsFemaleInJapanContext()
    {
    }

    public AllActorsFemaleInJapanContext(DbContextOptions<AllActorsFemaleInJapanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAccount> TblAccounts { get; set; }

    public virtual DbSet<TblBill> TblBills { get; set; }

    public virtual DbSet<TblBillMembership> TblBillMemberships { get; set; }

    public virtual DbSet<TblBlog> TblBlogs { get; set; }

    public virtual DbSet<TblCategory> TblCategories { get; set; }

    public virtual DbSet<TblClassSchedule> TblClassSchedules { get; set; }

    public virtual DbSet<TblComment> TblComments { get; set; }

    public virtual DbSet<TblCourse> TblCourses { get; set; }

    public virtual DbSet<TblCourseSchedule> TblCourseSchedules { get; set; }

    public virtual DbSet<TblMembership> TblMemberships { get; set; }

    public virtual DbSet<TblRatingCourse> TblRatingCourses { get; set; }

    public virtual DbSet<TblRegistrationCourse> TblRegistrationCourses { get; set; }

    public virtual DbSet<TblRegistrationMembership> TblRegistrationMemberships { get; set; }

    public virtual DbSet<TblRole> TblRoles { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=tcp:allactorsfemaleinjapandbserver.database.windows.net,1433;uid=ThangNC32;pwd=Thienthanh3101@;database=AllActorsFemaleInJapan;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAccount>(entity =>
        {
            entity.HasKey(e => e.AccountId);

            entity.ToTable("tblAccount");

            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AccountEmail)
                .HasMaxLength(50)
                .HasColumnName("account_email");
            entity.Property(e => e.AccountImg)
                .HasMaxLength(255)
                .HasColumnName("account_img");
            entity.Property(e => e.AccountIsActive).HasColumnName("account_is_active");
            entity.Property(e => e.AccountName)
                .HasMaxLength(30)
                .HasColumnName("account_name");
            entity.Property(e => e.AccountPassword)
                .HasMaxLength(30)
                .HasColumnName("account_password");
            entity.Property(e => e.AccountPhone)
                .HasMaxLength(12)
                .HasColumnName("account_phone");
            entity.Property(e => e.Biography)
                .HasMaxLength(700)
                .IsFixedLength()
                .HasColumnName("biography");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("create_date");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.SocialId)
                .HasMaxLength(21)
                .HasColumnName("social_id");

            entity.HasOne(d => d.Role).WithMany(p => p.TblAccounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_tblAccount_tblRole");
        });

        modelBuilder.Entity<TblBill>(entity =>
        {
            entity.HasKey(e => e.BillId);

            entity.ToTable("tblBill");

            entity.Property(e => e.BillId).HasColumnName("bill_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.BillDate)
                .HasColumnType("datetime")
                .HasColumnName("bill_date");
            entity.Property(e => e.BillDiscount).HasColumnName("bill_discount");
            entity.Property(e => e.BillIsActive).HasColumnName("bill_is_active");
            entity.Property(e => e.BillStatus).HasColumnName("bill_status");
            entity.Property(e => e.BillValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("bill_value");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.OrderCode)
                .HasMaxLength(15)
                .HasColumnName("order_code");
            entity.Property(e => e.PaymentDate)
                .HasColumnType("datetime")
                .HasColumnName("payment_date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(20)
                .HasColumnName("payment_method");

            entity.HasOne(d => d.Account).WithMany(p => p.TblBills)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_tblBill_tblAccount");

            entity.HasOne(d => d.Course).WithMany(p => p.TblBills)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_tblBill_tblCourse");
        });

        modelBuilder.Entity<TblBillMembership>(entity =>
        {
            entity.HasKey(e => e.BillMemId);

            entity.ToTable("tblBillMembership");

            entity.Property(e => e.BillMemId).HasColumnName("bill_mem_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.BillDate)
                .HasColumnType("datetime")
                .HasColumnName("bill_date");
            entity.Property(e => e.BillDiscount).HasColumnName("bill_discount");
            entity.Property(e => e.BillIsActive).HasColumnName("bill_is_active");
            entity.Property(e => e.BillStatus).HasColumnName("bill_status");
            entity.Property(e => e.BillValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("bill_value");
            entity.Property(e => e.MembershipId).HasColumnName("membership_id");
            entity.Property(e => e.OrderCode)
                .HasMaxLength(15)
                .HasColumnName("order_code");
            entity.Property(e => e.PaymentDate)
                .HasColumnType("datetime")
                .HasColumnName("payment_date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(20)
                .HasColumnName("payment_method");

            entity.HasOne(d => d.Account).WithMany(p => p.TblBillMemberships)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_tblBillMembership_tblAccount");

            entity.HasOne(d => d.Membership).WithMany(p => p.TblBillMemberships)
                .HasForeignKey(d => d.MembershipId)
                .HasConstraintName("FK_tblBillMembership_tblMembership");
        });

        modelBuilder.Entity<TblBlog>(entity =>
        {
            entity.HasKey(e => e.BlogId);

            entity.ToTable("tblBlog");

            entity.Property(e => e.BlogId).HasColumnName("blog_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.BlogDate)
                .HasColumnType("datetime")
                .HasColumnName("blog_date");
            entity.Property(e => e.BlogDetail)
                .HasMaxLength(3000)
                .HasColumnName("blog_detail");
            entity.Property(e => e.BlogImg)
                .HasMaxLength(255)
                .HasColumnName("blog_img");
            entity.Property(e => e.BlogTitle)
                .HasMaxLength(50)
                .HasColumnName("blog_title");

            entity.HasOne(d => d.Account).WithMany(p => p.TblBlogs)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_tblBlog_tblAccount");
        });

        modelBuilder.Entity<TblCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId);

            entity.ToTable("tblCategory");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryIsActive).HasColumnName("category_is_active");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(20)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<TblClassSchedule>(entity =>
        {
            entity.HasKey(e => e.ClassScheduleId);

            entity.ToTable("tblClassSchedule");

            entity.Property(e => e.ClassScheduleId).HasColumnName("class_schedule_id");
            entity.Property(e => e.ClassDate)
                .HasColumnType("date")
                .HasColumnName("class_date");
            entity.Property(e => e.ClassStatus).HasColumnName("class_status");
            entity.Property(e => e.RegistrationId).HasColumnName("registration_id");
            entity.Property(e => e.SlotEndTime).HasColumnName("slot_end_time");
            entity.Property(e => e.SlotStartTime).HasColumnName("slot_start_time");

            entity.HasOne(d => d.Registration).WithMany(p => p.TblClassSchedules)
                .HasForeignKey(d => d.RegistrationId)
                .HasConstraintName("FK_tblClassSchedule_tblRegistrationCourse");
        });

        modelBuilder.Entity<TblComment>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblComment");

            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.BlogId).HasColumnName("blog_id");
            entity.Property(e => e.CommentContent)
                .HasMaxLength(255)
                .HasColumnName("comment_content");
            entity.Property(e => e.CommentDate)
                .HasColumnType("datetime")
                .HasColumnName("comment_date");

            entity.HasOne(d => d.Account).WithMany()
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_tblComment_tblAccount");

            entity.HasOne(d => d.Blog).WithMany()
                .HasForeignKey(d => d.BlogId)
                .HasConstraintName("FK_tblComment_tblBlog");
        });

        modelBuilder.Entity<TblCourse>(entity =>
        {
            entity.HasKey(e => e.CourseId);

            entity.ToTable("tblCourse");

            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CourseDetail)
                .HasColumnType("text")
                .HasColumnName("course_detail");
            entity.Property(e => e.CourseDuration).HasColumnName("course_duration");
            entity.Property(e => e.CourseImg)
                .HasMaxLength(255)
                .HasColumnName("course_img");
            entity.Property(e => e.CourseIsActive).HasColumnName("course_is_active");
            entity.Property(e => e.CoursePrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("course_price");
            entity.Property(e => e.CourseTitle)
                .HasMaxLength(50)
                .HasColumnName("course_title");

            entity.HasOne(d => d.Account).WithMany(p => p.TblCourses)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_tblCourse_tblAccount");

            entity.HasOne(d => d.Category).WithMany(p => p.TblCourses)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_tblCourse_tblCategory");

            entity.HasMany(d => d.Accounts).WithMany(p => p.Courses)
                .UsingEntity<Dictionary<string, object>>(
                    "TblCourseWishlist",
                    r => r.HasOne<TblAccount>().WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_tblCourseWishlist_tblAccount"),
                    l => l.HasOne<TblCourse>().WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_tblCourseWishlist_tblCourse"),
                    j =>
                    {
                        j.HasKey("CourseId", "AccountId");
                        j.ToTable("tblCourseWishlist");
                        j.IndexerProperty<int>("CourseId").HasColumnName("course_id");
                        j.IndexerProperty<int>("AccountId").HasColumnName("account_id");
                    });
        });

        modelBuilder.Entity<TblCourseSchedule>(entity =>
        {
            entity.HasKey(e => e.CourseScheduleId);

            entity.ToTable("tblCourseSchedule");

            entity.Property(e => e.CourseScheduleId).HasColumnName("course_schedule_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.DayOfWeek)
                .HasMaxLength(20)
                .HasColumnName("day_of_week");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.StartTime).HasColumnName("start_time");

            entity.HasOne(d => d.Course).WithMany(p => p.TblCourseSchedules)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_tblCourseSchedule_tblCourse");
        });

        modelBuilder.Entity<TblMembership>(entity =>
        {
            entity.HasKey(e => e.MembershipId);

            entity.ToTable("tblMembership");

            entity.Property(e => e.MembershipId).HasColumnName("membership_id");
            entity.Property(e => e.MembershipDescription)
                .HasMaxLength(255)
                .HasColumnName("membership_description");
            entity.Property(e => e.MembershipDiscours).HasColumnName("membership_discours");
            entity.Property(e => e.MembershipDuration).HasColumnName("membership_duration");
            entity.Property(e => e.MembershipIsActive).HasColumnName("membership_is_active");
            entity.Property(e => e.MembershipName)
                .HasMaxLength(50)
                .HasColumnName("membership_name");
            entity.Property(e => e.MembershipPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("membership_price");
        });

        modelBuilder.Entity<TblRatingCourse>(entity =>
        {
            entity.HasKey(e => e.RegistrationId);

            entity.ToTable("tblRatingCourse");

            entity.Property(e => e.RegistrationId)
                .ValueGeneratedNever()
                .HasColumnName("registration_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Feedback)
                .HasMaxLength(50)
                .HasColumnName("feedback");
            entity.Property(e => e.RatingStar).HasColumnName("rating_star");

            entity.HasOne(d => d.Course).WithMany(p => p.TblRatingCourses)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_tblRatingCourse_tblCourse");

            entity.HasOne(d => d.Registration).WithOne(p => p.TblRatingCourse)
                .HasForeignKey<TblRatingCourse>(d => d.RegistrationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblRatingCourse_tblRegistrationCourse");
        });

        modelBuilder.Entity<TblRegistrationCourse>(entity =>
        {
            entity.HasKey(e => e.RegistrationId);

            entity.ToTable("tblRegistrationCourse");

            entity.Property(e => e.RegistrationId).HasColumnName("registration_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CourseScheduleId).HasColumnName("course_schedule_id");
            entity.Property(e => e.CourseStatus).HasColumnName("course_status");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("end_date");
            entity.Property(e => e.RegistrationDate)
                .HasColumnType("datetime")
                .HasColumnName("registration_date");
            entity.Property(e => e.RegistrationStatus).HasColumnName("registration_status");

            entity.HasOne(d => d.Account).WithMany(p => p.TblRegistrationCourses)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_tblRegistrationCourse_tblAccount");

            entity.HasOne(d => d.Course).WithMany(p => p.TblRegistrationCourses)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_tblRegistrationCourse_tblCourse");

            entity.HasOne(d => d.CourseSchedule).WithMany(p => p.TblRegistrationCourses)
                .HasForeignKey(d => d.CourseScheduleId)
                .HasConstraintName("FK_tblRegistrationCourse_tblCourseSchedule");
        });

        modelBuilder.Entity<TblRegistrationMembership>(entity =>
        {
            entity.HasKey(e => new { e.MembershipId, e.AccountId });

            entity.ToTable("tblRegistrationMembership");

            entity.Property(e => e.MembershipId).HasColumnName("membership_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.ExprirationDate)
                .HasColumnType("datetime")
                .HasColumnName("expriration_date");
            entity.Property(e => e.RegistrationDate)
                .HasColumnType("datetime")
                .HasColumnName("registration_date");
            entity.Property(e => e.RegistrationStatus).HasColumnName("registration_status");

            entity.HasOne(d => d.Account).WithMany(p => p.TblRegistrationMemberships)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblRegistrationMembership_tblAccount");

            entity.HasOne(d => d.Membership).WithMany(p => p.TblRegistrationMemberships)
                .HasForeignKey(d => d.MembershipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblRegistrationMembership_tblMembership");
        });

        modelBuilder.Entity<TblRole>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.ToTable("tblRole");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(20)
                .HasColumnName("role_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
