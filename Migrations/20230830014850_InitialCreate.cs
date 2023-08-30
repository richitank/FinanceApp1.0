using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceProject_WebApp_1_1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickers",
                columns: table => new
                {
                    Ticker = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Cik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Composite_Figi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Last_Updated_Utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Locale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Market = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Primary_Exchange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Share_Class_Figi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickers", x => x.Ticker);
                });

            migrationBuilder.InsertData(
                table: "Tickers",
                columns: new[] { "Ticker", "Active", "Cik", "Composite_Figi", "Currency_Name", "Last_Updated_Utc", "Locale", "Market", "Name", "Primary_Exchange", "Share_Class_Figi", "Type" },
                values: new object[] { "AAPL", true, null, "88", "USD", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Apple Comapny", null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickers");
        }
    }
}
