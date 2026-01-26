using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoManage.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixShadowKeyFinalVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Sellers_SellerId1",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Vehicles_VehicleId1",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_SellerId1",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_VehicleId1",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "SellerId1",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "VehicleId1",
                table: "Sales");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SellerId1",
                table: "Sales",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleId1",
                table: "Sales",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_SellerId1",
                table: "Sales",
                column: "SellerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_VehicleId1",
                table: "Sales",
                column: "VehicleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Sellers_SellerId1",
                table: "Sales",
                column: "SellerId1",
                principalTable: "Sellers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Vehicles_VehicleId1",
                table: "Sales",
                column: "VehicleId1",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }
    }
}
