using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeaverStream.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Treads_TreadId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Treads");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "TreadId",
                table: "Posts",
                newName: "ThreadId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_TreadId",
                table: "Posts",
                newName: "IX_Posts_ThreadId");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Treads",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "MainText",
                table: "Posts",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Posts",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Messages",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Messages",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Treads_ThreadId",
                table: "Posts",
                column: "ThreadId",
                principalTable: "Treads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Treads_ThreadId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Treads");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "ThreadId",
                table: "Posts",
                newName: "TreadId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_ThreadId",
                table: "Posts",
                newName: "IX_Posts_TreadId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Treads",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "MainText",
                table: "Posts",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Posts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Posts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Messages",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Messages",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Treads_TreadId",
                table: "Posts",
                column: "TreadId",
                principalTable: "Treads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
