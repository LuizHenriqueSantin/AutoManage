using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoManage.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixShadowKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Vehicles_VehicleId2",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "VehicleId2",
                table: "Sales",
                newName: "VehicleId1");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_VehicleId2",
                table: "Sales",
                newName: "IX_Sales_VehicleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Vehicles_VehicleId1",
                table: "Sales",
                column: "VehicleId1",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Vehicles_VehicleId1",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "VehicleId1",
                table: "Sales",
                newName: "VehicleId2");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_VehicleId1",
                table: "Sales",
                newName: "IX_Sales_VehicleId2");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Vehicles_VehicleId2",
                table: "Sales",
                column: "VehicleId2",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }
    }
}
