using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MentoriaFinanceiro.Domain.Core.Interfaces.Repositories;
using MentoriaFinanceiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace MentoriaFinanceiro.Infrastructure.Data.Repositories
{
    public class RepositoryMovimentacao : RepositoryBase<Movimentacao>, IRepositoryMovimentacao
    {
        private readonly SqlContext sqlContext;

        public RepositoryMovimentacao(SqlContext sqlContext) : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
        public decimal SaldoAnterior(int contaID, DateTime dataInicio)
        {
            var query = from movimentacao in sqlContext.Set<Movimentacao>()
                        .Where<Movimentacao>(m => m.ContaId == contaID)
                        .Where<Movimentacao>(m => m.DataMovimentacao <= dataInicio)
                        join oper in sqlContext.Set<Operacao>() on movimentacao.OperacaoId equals oper.Id
                        select new { movimentacao, oper };
            var saldoAnterior = query.Where(prop => prop.oper.TipoMovimentacao == 'C').Sum(prop => prop.movimentacao.ValorMovimentacao) -
                 query.Where(prop => prop.oper.TipoMovimentacao == 'D').Sum(prop => prop.movimentacao.ValorMovimentacao);


            return saldoAnterior;

        }

        public decimal SaldoPeriodo(int contaID, DateTime dataFim)
        {
            var query = from movimentacao in sqlContext.Set<Movimentacao>()
                        .Where<Movimentacao>(m => m.ContaId == contaID)
                        .Where<Movimentacao>(m => m.DataMovimentacao <= dataFim)
                        join oper in sqlContext.Set<Operacao>() on movimentacao.OperacaoId equals oper.Id
                        select new { movimentacao, oper };
            var saldoAnterior = query.Where(prop => prop.oper.TipoMovimentacao == 'C').Sum(prop => prop.movimentacao.ValorMovimentacao) -
                 query.Where(prop => prop.oper.TipoMovimentacao == 'D').Sum(prop => prop.movimentacao.ValorMovimentacao);


            return saldoAnterior;

        }

        public List<ExtratoMovimentacao> GetMovimentacao(int contaID, DateTime dataInicio, DateTime dataFim)
        {
            var query = from movimentacao in sqlContext.Set<Movimentacao>()
                        .Where<Movimentacao>(m => m.ContaId == contaID)
                            .Where<Movimentacao>(m => m.DataMovimentacao >= dataInicio)
                            .Where<Movimentacao>(m => m.DataMovimentacao <= dataFim)
                        join oper in sqlContext.Set<Operacao>() on movimentacao.OperacaoId equals oper.Id
                        select new ExtratoMovimentacao
                        {
                            ContaId = movimentacao.ContaId,
                            DataMovimentacao = movimentacao.DataMovimentacao,
                            DescricaoMovimentacao = movimentacao.DescricaoMovimentacao,
                            ValorMovimentacao = movimentacao.ValorMovimentacao,
                            TipoMovimentacao = oper.TipoMovimentacao,
                            NomeOperacao = oper.NomeOperacao
                        };

            var lista = query.ToList();
            return lista;

        }
    }
}
