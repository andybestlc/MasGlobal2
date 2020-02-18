using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MasGlobal.Model.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalaryType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    salary = table.Column<int>(nullable: false),
                    salaryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_SalaryType_salaryId",
                        column: x => x.salaryId,
                        principalTable: "SalaryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SalaryType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Hourly Salary" });

            migrationBuilder.InsertData(
                table: "SalaryType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Montly Salary" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "salary", "salaryId" },
                values: new object[] { 1, "Mark", 1, 1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "salary", "salaryId" },
                values: new object[] { 2, "Stephan", 1000, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_salaryId",
                table: "Employees",
                column: "salaryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "SalaryType");
        }
    }
}
