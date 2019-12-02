using Microsoft.EntityFrameworkCore.Migrations;

namespace GPCalculator.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lastname = table.Column<string>(nullable: false),
                    Firstname = table.Column<string>(nullable: false),
                    Regno = table.Column<string>(maxLength: 11, nullable: false),
                    Department = table.Column<string>(nullable: false),
                    Level = table.Column<string>(nullable: true),
                    Session = table.Column<string>(nullable: false),
                    Semester = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");
        }
    }
}
