﻿// <auto-generated />
using System;
using MentoriaFinanceiro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MentoriaFinanceiro.API.Migrations
{
    [DbContext(typeof(SqlContext))]
    [Migration("20220107164032_Mudanca-nome-tabela-operacao")]
    partial class Mudancanometabelaoperacao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MentoriaFinanceiro.Domain.Entities.Conta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cd_seq_conta_corrente")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Agencia")
                        .HasColumnName("ds_agencia")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<bool>("Ativo")
                        .HasColumnName("st_ativo")
                        .HasColumnType("bit");

                    b.Property<string>("ContaCorrente")
                        .HasColumnName("ds_contacorrente")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("DataAbertura")
                        .HasColumnName("dt_abertura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataUltimaMovimentacao")
                        .HasColumnName("dt_ultima_movimentacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("PessoaId")
                        .HasColumnName("cd_pessoa_fisica")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorAbertura")
                        .HasColumnName("nu_valor_abertura")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("ValorSaldoAtual")
                        .HasColumnName("nu_saldo_atual")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId")
                        .IsUnique();

                    b.ToTable("tb_conta_corrente","financeiro");
                });

            modelBuilder.Entity("MentoriaFinanceiro.Domain.Entities.Movimentacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cd_seq_movimentacao")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnName("st_ativo")
                        .HasColumnType("bit");

                    b.Property<int>("ContaId")
                        .HasColumnName("cd_conta_corrente")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataMovimentacao")
                        .HasColumnName("dt_movimentacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescricaoMovimentacao")
                        .HasColumnName("ds_descricao_movimento")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("OperacaoId")
                        .HasColumnName("cd_operacao")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorMovimentacao")
                        .HasColumnName("nu_valor_movimento")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("ContaId")
                        .IsUnique();

                    b.HasIndex("OperacaoId")
                        .IsUnique();

                    b.ToTable("tb_movimentacao","financeiro");
                });

            modelBuilder.Entity("MentoriaFinanceiro.Domain.Entities.Operacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cd_seq_operacao")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnName("st_ativo")
                        .HasColumnType("bit");

                    b.Property<string>("NomeOperacao")
                        .HasColumnName("no_operacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoMovimentacao")
                        .IsRequired()
                        .HasColumnName("tp_movimentacao")
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.ToTable("tb_operacao","financeiro");
                });

            modelBuilder.Entity("MentoriaFinanceiro.Domain.Entities.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cod_seq_pessoa_fisica")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnName("st_ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Cpf")
                        .HasColumnName("nu_cpf")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnName("dt_nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnName("no_pessoa")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("Sexo")
                        .HasColumnName("nu_sexo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tb_pessoa_fisica","financeiro");
                });

            modelBuilder.Entity("MentoriaFinanceiro.Domain.Entities.Conta", b =>
                {
                    b.HasOne("MentoriaFinanceiro.Domain.Entities.Pessoa", "Pessoa")
                        .WithOne("Conta")
                        .HasForeignKey("MentoriaFinanceiro.Domain.Entities.Conta", "PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MentoriaFinanceiro.Domain.Entities.Movimentacao", b =>
                {
                    b.HasOne("MentoriaFinanceiro.Domain.Entities.Conta", "Conta")
                        .WithOne("Movimentacao")
                        .HasForeignKey("MentoriaFinanceiro.Domain.Entities.Movimentacao", "ContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MentoriaFinanceiro.Domain.Entities.Operacao", "Operacao")
                        .WithOne("Movimentacao")
                        .HasForeignKey("MentoriaFinanceiro.Domain.Entities.Movimentacao", "OperacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
