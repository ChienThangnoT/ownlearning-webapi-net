using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityAuthentication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCategory",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    category_is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategory", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "tblMembership",
                columns: table => new
                {
                    membership_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    membership_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    membership_duration = table.Column<int>(type: "int", nullable: true),
                    membership_price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    membership_description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    membership_discours = table.Column<int>(type: "int", nullable: true),
                    membership_is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMembership", x => x.membership_id);
                });

            migrationBuilder.CreateTable(
                name: "tblRole",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRole", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "tblAccount",
                columns: table => new
                {
                    account_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_img = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    account_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    account_password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    account_email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    account_phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    account_is_active = table.Column<bool>(type: "bit", nullable: true),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    social_id = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: true),
                    create_date = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    biography = table.Column<string>(type: "nchar(700)", fixedLength: true, maxLength: 700, nullable: true),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAccount", x => x.account_id);
                    table.ForeignKey(
                        name: "FK_tblAccount_tblRole",
                        column: x => x.role_id,
                        principalTable: "tblRole",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblBillMembership",
                columns: table => new
                {
                    bill_mem_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    membership_id = table.Column<int>(type: "int", nullable: false),
                    account_id = table.Column<int>(type: "int", nullable: false),
                    bill_status = table.Column<int>(type: "int", nullable: true),
                    bill_is_active = table.Column<bool>(type: "bit", nullable: true),
                    bill_value = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    bill_discount = table.Column<int>(type: "int", nullable: true),
                    bill_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    order_code = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    payment_method = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    payment_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBillMembership", x => x.bill_mem_id);
                    table.ForeignKey(
                        name: "FK_tblBillMembership_tblAccount",
                        column: x => x.account_id,
                        principalTable: "tblAccount",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblBillMembership_tblMembership",
                        column: x => x.membership_id,
                        principalTable: "tblMembership",
                        principalColumn: "membership_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblBlog",
                columns: table => new
                {
                    blog_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    blog_title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    blog_detail = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    account_id = table.Column<int>(type: "int", nullable: false),
                    blog_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    blog_img = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBlog", x => x.blog_id);
                    table.ForeignKey(
                        name: "FK_tblBlog_tblAccount",
                        column: x => x.account_id,
                        principalTable: "tblAccount",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCourse",
                columns: table => new
                {
                    course_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    course_detail = table.Column<string>(type: "text", nullable: true),
                    course_duration = table.Column<int>(type: "int", nullable: true),
                    course_img = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    course_price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    course_is_active = table.Column<bool>(type: "bit", nullable: true),
                    account_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCourse", x => x.course_id);
                    table.ForeignKey(
                        name: "FK_tblCourse_tblAccount",
                        column: x => x.account_id,
                        principalTable: "tblAccount",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCourse_tblCategory",
                        column: x => x.category_id,
                        principalTable: "tblCategory",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblRegistrationMembership",
                columns: table => new
                {
                    membership_id = table.Column<int>(type: "int", nullable: false),
                    account_id = table.Column<int>(type: "int", nullable: false),
                    registration_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    expriration_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    registration_status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRegistrationMembership", x => new { x.membership_id, x.account_id });
                    table.ForeignKey(
                        name: "FK_tblRegistrationMembership_tblAccount",
                        column: x => x.account_id,
                        principalTable: "tblAccount",
                        principalColumn: "account_id");
                    table.ForeignKey(
                        name: "FK_tblRegistrationMembership_tblMembership",
                        column: x => x.membership_id,
                        principalTable: "tblMembership",
                        principalColumn: "membership_id");
                });

            migrationBuilder.CreateTable(
                name: "tblComment",
                columns: table => new
                {
                    blog_id = table.Column<int>(type: "int", nullable: false),
                    comment_content = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    comment_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    account_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_tblComment_tblAccount",
                        column: x => x.account_id,
                        principalTable: "tblAccount",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblComment_tblBlog",
                        column: x => x.blog_id,
                        principalTable: "tblBlog",
                        principalColumn: "blog_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblBill",
                columns: table => new
                {
                    bill_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    account_id = table.Column<int>(type: "int", nullable: false),
                    bill_status = table.Column<int>(type: "int", nullable: true),
                    bill_is_active = table.Column<bool>(type: "bit", nullable: true),
                    bill_value = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    bill_discount = table.Column<int>(type: "int", nullable: true),
                    bill_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    order_code = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    payment_method = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    payment_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBill", x => x.bill_id);
                    table.ForeignKey(
                        name: "FK_tblBill_tblAccount",
                        column: x => x.account_id,
                        principalTable: "tblAccount",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblBill_tblCourse",
                        column: x => x.course_id,
                        principalTable: "tblCourse",
                        principalColumn: "course_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCourseSchedule",
                columns: table => new
                {
                    course_schedule_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    day_of_week = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    start_time = table.Column<TimeSpan>(type: "time", nullable: true),
                    end_time = table.Column<TimeSpan>(type: "time", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCourseSchedule", x => x.course_schedule_id);
                    table.ForeignKey(
                        name: "FK_tblCourseSchedule_tblCourse",
                        column: x => x.course_id,
                        principalTable: "tblCourse",
                        principalColumn: "course_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCourseWishlist",
                columns: table => new
                {
                    course_id = table.Column<int>(type: "int", nullable: false),
                    account_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCourseWishlist", x => new { x.course_id, x.account_id });
                    table.ForeignKey(
                        name: "FK_tblCourseWishlist_tblAccount",
                        column: x => x.account_id,
                        principalTable: "tblAccount",
                        principalColumn: "account_id");
                    table.ForeignKey(
                        name: "FK_tblCourseWishlist_tblCourse",
                        column: x => x.course_id,
                        principalTable: "tblCourse",
                        principalColumn: "course_id");
                });

            migrationBuilder.CreateTable(
                name: "tblRegistrationCourse",
                columns: table => new
                {
                    registration_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    account_id = table.Column<int>(type: "int", nullable: false),
                    registration_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    end_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    course_status = table.Column<int>(type: "int", nullable: true),
                    course_schedule_id = table.Column<int>(type: "int", nullable: false),
                    registration_status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRegistrationCourse", x => x.registration_id);
                    table.ForeignKey(
                        name: "FK_tblRegistrationCourse_tblAccount",
                        column: x => x.account_id,
                        principalTable: "tblAccount",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblRegistrationCourse_tblCourse",
                        column: x => x.course_id,
                        principalTable: "tblCourse",
                        principalColumn: "course_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblRegistrationCourse_tblCourseSchedule",
                        column: x => x.course_schedule_id,
                        principalTable: "tblCourseSchedule",
                        principalColumn: "course_schedule_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblClassSchedule",
                columns: table => new
                {
                    class_schedule_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    registration_id = table.Column<int>(type: "int", nullable: false),
                    class_date = table.Column<DateTime>(type: "date", nullable: true),
                    slot_start_time = table.Column<TimeSpan>(type: "time", nullable: true),
                    slot_end_time = table.Column<TimeSpan>(type: "time", nullable: true),
                    class_status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblClassSchedule", x => x.class_schedule_id);
                    table.ForeignKey(
                        name: "FK_tblClassSchedule_tblRegistrationCourse",
                        column: x => x.registration_id,
                        principalTable: "tblRegistrationCourse",
                        principalColumn: "registration_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblRatingCourse",
                columns: table => new
                {
                    registration_id = table.Column<int>(type: "int", nullable: false),
                    rating_star = table.Column<int>(type: "int", nullable: true),
                    feedback = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    course_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRatingCourse", x => x.registration_id);
                    table.ForeignKey(
                        name: "FK_tblRatingCourse_tblCourse",
                        column: x => x.course_id,
                        principalTable: "tblCourse",
                        principalColumn: "course_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblRatingCourse_tblRegistrationCourse",
                        column: x => x.registration_id,
                        principalTable: "tblRegistrationCourse",
                        principalColumn: "registration_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAccount_role_id",
                table: "tblAccount",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblBill_account_id",
                table: "tblBill",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblBill_course_id",
                table: "tblBill",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblBillMembership_account_id",
                table: "tblBillMembership",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblBillMembership_membership_id",
                table: "tblBillMembership",
                column: "membership_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblBlog_account_id",
                table: "tblBlog",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblClassSchedule_registration_id",
                table: "tblClassSchedule",
                column: "registration_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblComment_account_id",
                table: "tblComment",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblComment_blog_id",
                table: "tblComment",
                column: "blog_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblCourse_account_id",
                table: "tblCourse",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblCourse_category_id",
                table: "tblCourse",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblCourseSchedule_course_id",
                table: "tblCourseSchedule",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblCourseWishlist_account_id",
                table: "tblCourseWishlist",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblRatingCourse_course_id",
                table: "tblRatingCourse",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblRegistrationCourse_account_id",
                table: "tblRegistrationCourse",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblRegistrationCourse_course_id",
                table: "tblRegistrationCourse",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblRegistrationCourse_course_schedule_id",
                table: "tblRegistrationCourse",
                column: "course_schedule_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblRegistrationMembership_account_id",
                table: "tblRegistrationMembership",
                column: "account_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblBill");

            migrationBuilder.DropTable(
                name: "tblBillMembership");

            migrationBuilder.DropTable(
                name: "tblClassSchedule");

            migrationBuilder.DropTable(
                name: "tblComment");

            migrationBuilder.DropTable(
                name: "tblCourseWishlist");

            migrationBuilder.DropTable(
                name: "tblRatingCourse");

            migrationBuilder.DropTable(
                name: "tblRegistrationMembership");

            migrationBuilder.DropTable(
                name: "tblBlog");

            migrationBuilder.DropTable(
                name: "tblRegistrationCourse");

            migrationBuilder.DropTable(
                name: "tblMembership");

            migrationBuilder.DropTable(
                name: "tblCourseSchedule");

            migrationBuilder.DropTable(
                name: "tblCourse");

            migrationBuilder.DropTable(
                name: "tblAccount");

            migrationBuilder.DropTable(
                name: "tblCategory");

            migrationBuilder.DropTable(
                name: "tblRole");
        }
    }
}
