using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NET6EmployeeDatabaseCRUDApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddedImagesPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                schema: "dbo",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                schema: "dbo",
                table: "Employee");
        }
    }
}
