using MentoriaFinanceiro.Domain.Core.Interfaces.Repositories;
using MentoriaFinanceiro.Domain.Core.Interfaces.Services;
using MentoriaFinanceiro.Domain.Entities;
using System;

namespace MentoriaFinanceiro.Domain.Services
{
    public class ServiceMovimentacao : ServiceBase<Movimentacao> , IServiceMovimentacao
    {
        private readonly IRepositoryMovimentacao repositoryMovimentacao;
        public ServiceMovimentacao(IRepositoryMovimentacao repositoryMovimentacao) : base(repositoryMovimentacao)
        {
            this.repositoryMovimentacao = repositoryMovimentacao;
        }
        public ExtratoBancario Extrato(Conta conta, DateTime dataInicio, DateTime dataFim)
        {
            var saldoAnterior = repositoryMovimentacao.SaldoAnterior(conta.Id, dataInicio);

            var saldoFinalPeriodo = repositoryMovimentacao.SaldoPeriodo(conta.Id, dataFim);

            var movimentacao = repositoryMovimentacao.GetMovimentacao(conta.Id, dataInicio, dataFim);

            var extrato = new ExtratoBancario();
            extrato.SaldoAnterior = saldoAnterior;
            extrato.SaldoFinalPeriodo = saldoFinalPeriodo;
            extrato.Movimentacao = movimentacao;

            return extrato;

        }
    }
}
