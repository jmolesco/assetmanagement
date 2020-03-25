using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AM.API.Migrations
{
    public partial class AddedAssetTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adapter = table.Column<string>(maxLength: 20, nullable: true),
                    AssetTag = table.Column<string>(maxLength: 20, nullable: true),
                    AssignedTo = table.Column<string>(maxLength: 50, nullable: true),
                    Battery = table.Column<string>(maxLength: 20, nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    DRNo = table.Column<string>(maxLength: 15, nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "date", nullable: true),
                    HardDiskId = table.Column<int>(nullable: true),
                    HostName = table.Column<string>(maxLength: 20, nullable: true),
                    IPAddress = table.Column<string>(maxLength: 20, nullable: true),
                    MacAddress = table.Column<string>(maxLength: 20, nullable: true),
                    ManufacturerId = table.Column<int>(nullable: true),
                    MemoryId = table.Column<int>(nullable: true),
                    ModelId = table.Column<int>(nullable: true),
                    PONo = table.Column<string>(maxLength: 15, nullable: true),
                    ProcessorId = table.Column<int>(nullable: true),
                    SINo = table.Column<string>(maxLength: 15, nullable: true),
                    SerialNo = table.Column<string>(maxLength: 20, nullable: true),
                    Status = table.Column<int>(nullable: true),
                    SupplierId = table.Column<int>(nullable: true),
                    VideoCardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assets_HardDiskSizes_HardDiskId",
                        column: x => x.HardDiskId,
                        principalTable: "HardDiskSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assets_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assets_MemorySizes_MemoryId",
                        column: x => x.MemoryId,
                        principalTable: "MemorySizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assets_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assets_Processors_ProcessorId",
                        column: x => x.ProcessorId,
                        principalTable: "Processors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assets_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assets_VideoCardSizes_VideoCardId",
                        column: x => x.VideoCardId,
                        principalTable: "VideoCardSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_CategoryId",
                table: "Assets",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_HardDiskId",
                table: "Assets",
                column: "HardDiskId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_ManufacturerId",
                table: "Assets",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_MemoryId",
                table: "Assets",
                column: "MemoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_ModelId",
                table: "Assets",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_ProcessorId",
                table: "Assets",
                column: "ProcessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_SupplierId",
                table: "Assets",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_VideoCardId",
                table: "Assets",
                column: "VideoCardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");
        }
    }
}
