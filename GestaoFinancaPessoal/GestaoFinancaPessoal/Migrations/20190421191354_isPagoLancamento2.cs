﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoFinancaPessoal.Migrations
{
    public partial class isPagoLancamento2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recorrente_Lancamento_LancamentoId",
                table: "Recorrente");

            migrationBuilder.DropIndex(
                name: "IX_Recorrente_LancamentoId",
                table: "Recorrente");

            migrationBuilder.DropColumn(
                name: "LancamentoId",
                table: "Recorrente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LancamentoId",
                table: "Recorrente",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recorrente_LancamentoId",
                table: "Recorrente",
                column: "LancamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recorrente_Lancamento_LancamentoId",
                table: "Recorrente",
                column: "LancamentoId",
                principalTable: "Lancamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
