using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CastleIncInventory.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComputerManufacturers",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SerialRegex = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerManufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComputerStatuses",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocalizedName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ComputerManufacturerId = table.Column<uint>(type: "INTEGER", nullable: false),
                    SerialNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Specifications = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WarrantyExpirationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Computers_ComputerManufacturers_ComputerManufacturerId",
                        column: x => x.ComputerManufacturerId,
                        principalTable: "ComputerManufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkComputerStatuses",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ComputerId = table.Column<uint>(type: "INTEGER", nullable: false),
                    ComputerStatusId = table.Column<uint>(type: "INTEGER", nullable: false),
                    AssignDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkComputerStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkComputerStatuses_ComputerStatuses_ComputerStatusId",
                        column: x => x.ComputerStatusId,
                        principalTable: "ComputerStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkComputerStatuses_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkComputerUsers",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<uint>(type: "INTEGER", nullable: false),
                    ComputerId = table.Column<uint>(type: "INTEGER", nullable: false),
                    AssignDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AssignEndDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkComputerUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkComputerUsers_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkComputerUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Computers_ComputerManufacturerId",
                table: "Computers",
                column: "ComputerManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkComputerStatuses_ComputerId",
                table: "LinkComputerStatuses",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkComputerStatuses_ComputerStatusId",
                table: "LinkComputerStatuses",
                column: "ComputerStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkComputerUsers_ComputerId",
                table: "LinkComputerUsers",
                column: "ComputerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LinkComputerUsers_UserId",
                table: "LinkComputerUsers",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkComputerStatuses");

            migrationBuilder.DropTable(
                name: "LinkComputerUsers");

            migrationBuilder.DropTable(
                name: "ComputerStatuses");

            migrationBuilder.DropTable(
                name: "Computers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ComputerManufacturers");
        }
    }
}
