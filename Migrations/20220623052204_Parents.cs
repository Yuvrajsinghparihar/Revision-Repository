using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Revision.Migrations
{
    public partial class Parents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parents_Info",
                columns: table => new
                {
                    Parents_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parents_Phone = table.Column<long>(type: "bigint", nullable: false),
                    Parents_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parents_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents_Info", x => x.Parents_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parents_Info");
        }
    }
}
