using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoManage.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixUniqueCpf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Owners_CpfCnpj",
                table: "Owners",
                column: "CpfCnpj",
                unique: true,
                filter: "[CpfCnpj] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Owners_CpfCnpj",
                table: "Owners");
        }
    }
}
