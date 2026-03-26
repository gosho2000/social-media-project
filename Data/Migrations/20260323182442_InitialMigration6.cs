using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseSocialMedia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UploaderId",
                table: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "UploaderId",
                table: "Posts",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UploaderId",
                table: "Posts",
                column: "UploaderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UploaderId",
                table: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "UploaderId",
                table: "Posts",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UploaderId",
                table: "Posts",
                column: "UploaderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
