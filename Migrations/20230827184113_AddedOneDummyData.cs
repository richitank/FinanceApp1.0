using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceProject_WebApp_1_1.Migrations
{
    /// <inheritdoc />
    public partial class AddedOneDummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TickerList",
                columns: new[] { "TickerList", "Active", "Cik", "Composite_Figi", "Currency_Name", "Last_Updated_Utc", "Locale", "Market", "Name", "Primary_Exchange", "Share_Class_Figi", "Type" },
                values: new object[] { "AAPL", true, null, null, "USD", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Apple Comapny", null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TickerList",
                keyColumn: "TickerList",
                keyValue: "AAPL");
        }
    }
}
