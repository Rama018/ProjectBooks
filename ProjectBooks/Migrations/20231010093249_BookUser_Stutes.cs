using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectBooks.Migrations
{
    /// <inheritdoc />
    public partial class BookUser_Stutes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StutesId",
                table: "BookUser",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Stutes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StutesName = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stutes", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookUser_StutesId",
                table: "BookUser",
                column: "StutesId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookUser_Stutes_StutesId",
                table: "BookUser",
                column: "StutesId",
                principalTable: "Stutes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookUser_Stutes_StutesId",
                table: "BookUser");

            migrationBuilder.DropTable(
                name: "Stutes");

            migrationBuilder.DropIndex(
                name: "IX_BookUser_StutesId",
                table: "BookUser");

            migrationBuilder.DropColumn(
                name: "StutesId",
                table: "BookUser");
        }
    }
}
