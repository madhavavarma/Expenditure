using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Maddy.Apps.Expenditure.DataProvider.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenditureTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenditureTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenditures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(type: "date", nullable: false),
                    ExpenditureTypeId = table.Column<int>(nullable: false),
                    TransactionTypeId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenditures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenditures_ExpenditureTypes_ExpenditureTypeId",
                        column: x => x.ExpenditureTypeId,
                        principalTable: "ExpenditureTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenditures_TransactionTypes_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpenditureFilter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExpenditureId = table.Column<int>(nullable: false),
                    FilterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenditureFilter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenditureFilter_Expenditures_ExpenditureId",
                        column: x => x.ExpenditureId,
                        principalTable: "Expenditures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpenditureFilter_Filters_FilterId",
                        column: x => x.FilterId,
                        principalTable: "Filters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenditureFilter_ExpenditureId",
                table: "ExpenditureFilter",
                column: "ExpenditureId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenditureFilter_FilterId",
                table: "ExpenditureFilter",
                column: "FilterId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenditures_ExpenditureTypeId",
                table: "Expenditures",
                column: "ExpenditureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenditures_TransactionTypeId",
                table: "Expenditures",
                column: "TransactionTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenditureFilter");

            migrationBuilder.DropTable(
                name: "Expenditures");

            migrationBuilder.DropTable(
                name: "Filters");

            migrationBuilder.DropTable(
                name: "ExpenditureTypes");

            migrationBuilder.DropTable(
                name: "TransactionTypes");
        }
    }
}
