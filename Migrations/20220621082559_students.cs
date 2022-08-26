using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Revision.Migrations
{
    public partial class students : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students_Info",
                columns: table => new
                {
                    Student_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Student_Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students_Info", x => x.Student_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students_Info");
        }
    }
}
