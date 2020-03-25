using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AM.API.Migrations
{
    public partial class AddedIndexColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_VideoCardSizes_Id",
                table: "VideoCardSizes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCardSizes_Size",
                table: "VideoCardSizes",
                column: "Size");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCardSizes_Id_Size",
                table: "VideoCardSizes",
                columns: new[] { "Id", "Size" });

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_Id",
                table: "Suppliers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_Name",
                table: "Suppliers",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_Id_Name",
                table: "Suppliers",
                columns: new[] { "Id", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Processors_Id",
                table: "Processors",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Processors_Name",
                table: "Processors",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Processors_Id_Name",
                table: "Processors",
                columns: new[] { "Id", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Models_Id",
                table: "Models",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Models_Name",
                table: "Models",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Models_Id_Name",
                table: "Models",
                columns: new[] { "Id", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_MemorySizes_Id",
                table: "MemorySizes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MemorySizes_Size",
                table: "MemorySizes",
                column: "Size");

            migrationBuilder.CreateIndex(
                name: "IX_MemorySizes_Id_Size",
                table: "MemorySizes",
                columns: new[] { "Id", "Size" });

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_Id",
                table: "Manufacturers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_Name",
                table: "Manufacturers",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_Id_Name",
                table: "Manufacturers",
                columns: new[] { "Id", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_HardDiskSizes_Id",
                table: "HardDiskSizes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_HardDiskSizes_Size",
                table: "HardDiskSizes",
                column: "Size");

            migrationBuilder.CreateIndex(
                name: "IX_HardDiskSizes_Id_Size",
                table: "HardDiskSizes",
                columns: new[] { "Id", "Size" });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Id",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Id_Name",
                table: "Categories",
                columns: new[] { "Id", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_Id",
                table: "Assets",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_SerialNo_AssetTag_Name",
                table: "Assets",
                columns: new[] { "SerialNo", "AssetTag", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_Id_SerialNo_AssetTag_Name",
                table: "Assets",
                columns: new[] { "Id", "SerialNo", "AssetTag", "Name" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VideoCardSizes_Id",
                table: "VideoCardSizes");

            migrationBuilder.DropIndex(
                name: "IX_VideoCardSizes_Size",
                table: "VideoCardSizes");

            migrationBuilder.DropIndex(
                name: "IX_VideoCardSizes_Id_Size",
                table: "VideoCardSizes");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_Id",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_Name",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_Id_Name",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Processors_Id",
                table: "Processors");

            migrationBuilder.DropIndex(
                name: "IX_Processors_Name",
                table: "Processors");

            migrationBuilder.DropIndex(
                name: "IX_Processors_Id_Name",
                table: "Processors");

            migrationBuilder.DropIndex(
                name: "IX_Models_Id",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Models_Name",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Models_Id_Name",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_MemorySizes_Id",
                table: "MemorySizes");

            migrationBuilder.DropIndex(
                name: "IX_MemorySizes_Size",
                table: "MemorySizes");

            migrationBuilder.DropIndex(
                name: "IX_MemorySizes_Id_Size",
                table: "MemorySizes");

            migrationBuilder.DropIndex(
                name: "IX_Manufacturers_Id",
                table: "Manufacturers");

            migrationBuilder.DropIndex(
                name: "IX_Manufacturers_Name",
                table: "Manufacturers");

            migrationBuilder.DropIndex(
                name: "IX_Manufacturers_Id_Name",
                table: "Manufacturers");

            migrationBuilder.DropIndex(
                name: "IX_HardDiskSizes_Id",
                table: "HardDiskSizes");

            migrationBuilder.DropIndex(
                name: "IX_HardDiskSizes_Size",
                table: "HardDiskSizes");

            migrationBuilder.DropIndex(
                name: "IX_HardDiskSizes_Id_Size",
                table: "HardDiskSizes");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Id",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Name",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Id_Name",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Assets_Id",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_SerialNo_AssetTag_Name",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_Id_SerialNo_AssetTag_Name",
                table: "Assets");
        }
    }
}
