using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clases_EjercicoEntregable.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "empleados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "empleados");
        }
    }
}
