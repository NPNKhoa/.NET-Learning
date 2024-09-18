using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObjects.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Username);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Username", "Address", "Birthday", "Fullname", "Gender", "Password" },
                values: new object[,]
                {
                    { "Dung", "HCM", new DateTime(2008, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dung Dung", "Male", "5" },
                    { "Hoa", "CT", new DateTime(2020, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hoa Hoa", "Female", "1" },
                    { "Lan", "HCM", new DateTime(2004, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lan Lan", "Female", "2" },
                    { "Nam", "HN", new DateTime(2000, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nam Nam", "Male", "3" },
                    { "Tuan", "CT", new DateTime(2009, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tuan Tuan", "Male", "4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
