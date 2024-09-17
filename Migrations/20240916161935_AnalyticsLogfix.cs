using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AnalyticsLogfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AnalyticsLogs",
                table: "AnalyticsLogs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AnalyticsLogs");

            migrationBuilder.AddColumn<Guid>(
                name: "AnalyticsLogID",
                table: "AnalyticsLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnalyticsLogs",
                table: "AnalyticsLogs",
                column: "AnalyticsLogID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AnalyticsLogs",
                table: "AnalyticsLogs");

            migrationBuilder.DropColumn(
                name: "AnalyticsLogID",
                table: "AnalyticsLogs");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AnalyticsLogs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnalyticsLogs",
                table: "AnalyticsLogs",
                column: "Id");
        }
    }
}
