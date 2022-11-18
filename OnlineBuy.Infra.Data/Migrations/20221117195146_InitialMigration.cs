using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBuy.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    idperson = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Ssn = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.idperson);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    idproduct = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    CodErp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.idproduct);
                });

            migrationBuilder.CreateTable(
                name: "purchase",
                columns: table => new
                {
                    idpurchase = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idproduct = table.Column<int>(type: "int", nullable: false),
                    idperson = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchase", x => x.idpurchase);
                    table.ForeignKey(
                        name: "FK_purchase_person_idperson",
                        column: x => x.idperson,
                        principalTable: "person",
                        principalColumn: "idperson",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchase_product_idproduct",
                        column: x => x.idproduct,
                        principalTable: "product",
                        principalColumn: "idproduct",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_purchase_idperson",
                table: "purchase",
                column: "idperson");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_idproduct",
                table: "purchase",
                column: "idproduct");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "purchase");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "product");
        }
    }
}
