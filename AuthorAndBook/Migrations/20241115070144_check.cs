using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthorAndBook.Migrations
{
    /// <inheritdoc />
    public partial class check : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AuthorDetails_AuthorId",
                table: "AuthorDetails");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorDetails_AuthorId",
                table: "AuthorDetails",
                column: "AuthorId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AuthorDetails_AuthorId",
                table: "AuthorDetails");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorDetails_AuthorId",
                table: "AuthorDetails",
                column: "AuthorId");
        }
    }
}
