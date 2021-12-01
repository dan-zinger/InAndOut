using Microsoft.EntityFrameworkCore.Migrations;

namespace InAndOut1.Migrations
{
    public partial class UpdateExpenseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Item",
                table: "Expenses");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Expenses",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<string>(
                name: "ExpenseName",
                table: "Expenses",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpenseName",
                table: "Expenses");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "Expenses",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "Item",
                table: "Expenses",
                type: "varchar(50)",
                nullable: true);
        }
    }
}
