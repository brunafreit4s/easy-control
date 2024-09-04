﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyControl.Api.Migrations
{
    /// <inheritdoc />
    public partial class CriarEntidadeAreceber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TituloAreceber",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorRecebido = table.Column<double>(type: "double precision", nullable: false),
                    DataRecebimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUsuario = table.Column<long>(type: "bigint", nullable: false),
                    IdNaturezaDeLancamento = table.Column<long>(type: "bigint", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    Observacao = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    ValorOriginal = table.Column<double>(type: "double precision", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataReferencia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataInativacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TituloAreceber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TituloAreceber_NaturezaDeLancamento_IdNaturezaDeLancamento",
                        column: x => x.IdNaturezaDeLancamento,
                        principalTable: "NaturezaDeLancamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TituloAreceber_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TituloAreceber_IdNaturezaDeLancamento",
                table: "TituloAreceber",
                column: "IdNaturezaDeLancamento");

            migrationBuilder.CreateIndex(
                name: "IX_TituloAreceber_IdUsuario",
                table: "TituloAreceber",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TituloAreceber");
        }
    }
}
