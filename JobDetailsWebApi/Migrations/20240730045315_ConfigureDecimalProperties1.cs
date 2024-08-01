using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobDetailsWebApi.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureDecimalProperties1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalExperience = table.Column<int>(type: "int", nullable: false),
                    CurrentCtc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpectedCtc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReasonForJobChange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoticePeriod = table.Column<int>(type: "int", nullable: false),
                    CurrentCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UploadCv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobDetails", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobDetails");
        }
    }
}
