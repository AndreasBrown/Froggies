using Microsoft.EntityFrameworkCore.Migrations;

namespace Froggies.Web.DB.Migrations
{
    public partial class FirstLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Cells" },
                values: new object[] { 1, "[[\"G\",\"N\",\"E\",\"N\",\"E\"],[\"N\",\"G\",\"N\",\"E\",\"N\"],[\"E\",\"N\",\"G\",\"N\",\"E\"],[\"N\",\"R\",\"N\",\"E\",\"N\"],[\"E\",\"N\",\"E\",\"N\",\"E\"]]" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
