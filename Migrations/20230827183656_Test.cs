using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceProject_WebApp_1_1.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TickerSymbol",
                table: "TickerList",
                newName: "TickerList");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TickerList",
                table: "TickerList",
                newName: "TickerSymbol");
        }
    }
}
