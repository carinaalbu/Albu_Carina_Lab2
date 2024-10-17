using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Albu_Carina_Lab2.Migrations
{
    /// <inheritdoc />
    public partial class Authors3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Authors",
                newName: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Authors",
                newName: "Id");
        }
    }
}
