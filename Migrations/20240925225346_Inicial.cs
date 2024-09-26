using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGerenciamentoDeComandas.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cardapio",
                columns: table => new
                {
                    CardapioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disponibilidade = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cardapio", x => x.CardapioID);
                });

            migrationBuilder.CreateTable(
                name: "Comandas",
                columns: table => new
                {
                    ComandaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomeGarcom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mesa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comandas", x => x.ComandaID);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProduto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecoProduto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoID);
                });

            migrationBuilder.CreateTable(
                name: "CardapiosProdutos",
                columns: table => new
                {
                    CardapioProdutoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoID = table.Column<int>(type: "int", nullable: false),
                    CardapioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardapiosProdutos", x => x.CardapioProdutoID);
                    table.ForeignKey(
                        name: "FK_CardapiosProdutos_Cardapio_CardapioID",
                        column: x => x.CardapioID,
                        principalTable: "Cardapio",
                        principalColumn: "CardapioID");
                    table.ForeignKey(
                        name: "FK_CardapiosProdutos_Produtos_ProdutoID",
                        column: x => x.ProdutoID,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoID");
                });

            migrationBuilder.CreateTable(
                name: "ComandasProdutos",
                columns: table => new
                {
                    ComandaProdutoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoID = table.Column<int>(type: "int", nullable: false),
                    ComandaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComandasProdutos", x => x.ComandaProdutoID);
                    table.ForeignKey(
                        name: "FK_ComandasProdutos_Comandas_ComandaID",
                        column: x => x.ComandaID,
                        principalTable: "Comandas",
                        principalColumn: "ComandaID");
                    table.ForeignKey(
                        name: "FK_ComandasProdutos_Produtos_ProdutoID",
                        column: x => x.ProdutoID,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardapiosProdutos_CardapioID",
                table: "CardapiosProdutos",
                column: "CardapioID");

            migrationBuilder.CreateIndex(
                name: "IX_CardapiosProdutos_ProdutoID",
                table: "CardapiosProdutos",
                column: "ProdutoID");

            migrationBuilder.CreateIndex(
                name: "IX_ComandasProdutos_ComandaID",
                table: "ComandasProdutos",
                column: "ComandaID");

            migrationBuilder.CreateIndex(
                name: "IX_ComandasProdutos_ProdutoID",
                table: "ComandasProdutos",
                column: "ProdutoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardapiosProdutos");

            migrationBuilder.DropTable(
                name: "ComandasProdutos");

            migrationBuilder.DropTable(
                name: "Cardapio");

            migrationBuilder.DropTable(
                name: "Comandas");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
