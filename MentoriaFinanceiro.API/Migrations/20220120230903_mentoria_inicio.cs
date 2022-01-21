using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MentoriaFinanceiro.API.Migrations
{
    public partial class mentoria_inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "financeiro");

            migrationBuilder.CreateTable(
                name: "tb_operacao",
                schema: "financeiro",
                columns: table => new
                {
                    cd_seq_operacao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    no_operacao = table.Column<string>(nullable: true),
                    tp_movimentacao = table.Column<string>(nullable: false),
                    st_ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_operacao", x => x.cd_seq_operacao);
                });

            migrationBuilder.CreateTable(
                name: "tb_pessoa_fisica",
                schema: "financeiro",
                columns: table => new
                {
                    cod_seq_pessoa_fisica = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    no_pessoa = table.Column<string>(maxLength: 200, nullable: true),
                    nu_cpf = table.Column<string>(maxLength: 11, nullable: true),
                    dt_nascimento = table.Column<DateTime>(nullable: true),
                    nu_sexo = table.Column<int>(nullable: false),
                    st_ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_pessoa_fisica", x => x.cod_seq_pessoa_fisica);
                });

            migrationBuilder.CreateTable(
                name: "tb_conta_corrente",
                schema: "financeiro",
                columns: table => new
                {
                    cd_seq_conta_corrente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cd_pessoa_fisica = table.Column<int>(nullable: false),
                    ds_agencia = table.Column<string>(maxLength: 20, nullable: true),
                    ds_contacorrente = table.Column<string>(maxLength: 20, nullable: true),
                    dt_abertura = table.Column<DateTime>(nullable: true),
                    nu_valor_abertura = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    nu_saldo_atual = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    dt_ultima_movimentacao = table.Column<DateTime>(nullable: true),
                    st_ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_conta_corrente", x => x.cd_seq_conta_corrente);
                    table.ForeignKey(
                        name: "FK_tb_conta_corrente_tb_pessoa_fisica_cd_pessoa_fisica",
                        column: x => x.cd_pessoa_fisica,
                        principalSchema: "financeiro",
                        principalTable: "tb_pessoa_fisica",
                        principalColumn: "cod_seq_pessoa_fisica",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_movimentacao",
                schema: "financeiro",
                columns: table => new
                {
                    cd_seq_movimentacao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cd_conta_corrente = table.Column<int>(nullable: false),
                    cd_operacao = table.Column<int>(nullable: false),
                    dt_movimentacao = table.Column<DateTime>(nullable: true),
                    nu_valor_movimento = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ds_descricao_movimento = table.Column<string>(maxLength: 500, nullable: true),
                    st_ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_movimentacao", x => x.cd_seq_movimentacao);
                    table.ForeignKey(
                        name: "FK_tb_movimentacao_tb_conta_corrente_cd_conta_corrente",
                        column: x => x.cd_conta_corrente,
                        principalSchema: "financeiro",
                        principalTable: "tb_conta_corrente",
                        principalColumn: "cd_seq_conta_corrente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_movimentacao_tb_operacao_cd_operacao",
                        column: x => x.cd_operacao,
                        principalSchema: "financeiro",
                        principalTable: "tb_operacao",
                        principalColumn: "cd_seq_operacao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_conta_corrente_cd_pessoa_fisica",
                schema: "financeiro",
                table: "tb_conta_corrente",
                column: "cd_pessoa_fisica",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_movimentacao_cd_conta_corrente",
                schema: "financeiro",
                table: "tb_movimentacao",
                column: "cd_conta_corrente",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_tb_movimentacao_cd_operacao",
                schema: "financeiro",
                table: "tb_movimentacao",
                column: "cd_operacao",
                unique: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_movimentacao",
                schema: "financeiro");

            migrationBuilder.DropTable(
                name: "tb_conta_corrente",
                schema: "financeiro");

            migrationBuilder.DropTable(
                name: "tb_operacao",
                schema: "financeiro");

            migrationBuilder.DropTable(
                name: "tb_pessoa_fisica",
                schema: "financeiro");
        }
    }
}
