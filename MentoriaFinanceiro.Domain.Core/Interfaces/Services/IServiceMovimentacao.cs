using System;
using MentoriaFinanceiro.Domain.Entities;

namespace MentoriaFinanceiro.Domain.Core.Interfaces.Services
{
    public interface IServiceMovimentacao : IServiceBase<Movimentacao>
    {
        ExtratoBancario Extrato(Conta conta, DateTime dataInicio, DateTime dataFim);
    }
}
