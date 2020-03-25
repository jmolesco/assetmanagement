using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AM.API.Migrations
{
    public partial class ModifiedAssetTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Assets_SerialNo_AssetTag_Name",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_Id_SerialNo_AssetTag_Name",
                table: "Assets");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Assets",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PurchaseCost",
                table: "Assets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchaseDate",
                table: "Assets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Warranty",
                table: "Assets",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "PurchaseCost",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "PurchaseDate",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "Warranty",
                table: "Assets");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_SerialNo_AssetTag_Name",
                table: "Assets",
                columns: new[] { "SerialNo", "AssetTag", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_Id_SerialNo_AssetTag_Name",
                table: "Assets",
                columns: new[] { "Id", "SerialNo", "AssetTag", "Name" });
        }
    }
}
