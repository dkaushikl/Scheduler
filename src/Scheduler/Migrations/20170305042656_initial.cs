using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scheduler.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "User",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Avatar = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Profession = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_User", x => x.Id); });

            migrationBuilder.CreateTable(
                "Schedule",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<int>(nullable: false),
                    DateCreated =
                    table.Column<DateTime>(nullable: false,
                        defaultValue: new DateTime(2017, 3, 5, 9, 56, 55, 386, DateTimeKind.Local)),
                    DateUpdated =
                    table.Column<DateTime>(nullable: false,
                        defaultValue: new DateTime(2017, 3, 5, 9, 56, 55, 418, DateTimeKind.Local)),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    TimeEnd = table.Column<DateTime>(nullable: false),
                    TimeStart = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        "FK_Schedule_User_CreatorId",
                        x => x.CreatorId,
                        "User",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Attendee",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ScheduleId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendee", x => x.Id);
                    table.ForeignKey(
                        "FK_Attendee_Schedule_ScheduleId",
                        x => x.ScheduleId,
                        "Schedule",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Attendee_User_UserId",
                        x => x.UserId,
                        "User",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Attendee_ScheduleId",
                "Attendee",
                "ScheduleId");

            migrationBuilder.CreateIndex(
                "IX_Attendee_UserId",
                "Attendee",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_Schedule_CreatorId",
                "Schedule",
                "CreatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Attendee");

            migrationBuilder.DropTable(
                "Schedule");

            migrationBuilder.DropTable(
                "User");
        }
    }
}