using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Book_Store.Migrations
{
    /// <inheritdoc />
    public partial class modify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_instructors_Departments_dept_id",
                table: "instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_instructors_courses_crs_id",
                table: "instructors");

            migrationBuilder.AlterColumn<int>(
                name: "dept_id",
                table: "instructors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "crs_id",
                table: "instructors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_instructors_Departments_dept_id",
                table: "instructors",
                column: "dept_id",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_instructors_courses_crs_id",
                table: "instructors",
                column: "crs_id",
                principalTable: "courses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_instructors_Departments_dept_id",
                table: "instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_instructors_courses_crs_id",
                table: "instructors");

            migrationBuilder.AlterColumn<int>(
                name: "dept_id",
                table: "instructors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "crs_id",
                table: "instructors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_instructors_Departments_dept_id",
                table: "instructors",
                column: "dept_id",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_instructors_courses_crs_id",
                table: "instructors",
                column: "crs_id",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
