using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanProject.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class createdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 11, 28, 0, 55, 17, 88, DateTimeKind.Local).AddTicks(1920), new DateTime(2024, 11, 28, 0, 55, 17, 89, DateTimeKind.Local).AddTicks(6318) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 11, 28, 0, 52, 7, 804, DateTimeKind.Local).AddTicks(8615), new DateTime(2024, 11, 28, 0, 52, 7, 805, DateTimeKind.Local).AddTicks(7302) });
        }
    }
}
