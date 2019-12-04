using Microsoft.EntityFrameworkCore.Migrations;

namespace GPCalculator.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseName",
                table: "Results",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Unit = table.Column<int>(maxLength: 2, nullable: false),
                    Grade = table.Column<string>(maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Name);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_CourseName",
                table: "Results",
                column: "CourseName");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Course_CourseName",
                table: "Results",
                column: "CourseName",
                principalTable: "Course",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Course_CourseName",
                table: "Results");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Results_CourseName",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "CourseName",
                table: "Results");
        }
    }
}
