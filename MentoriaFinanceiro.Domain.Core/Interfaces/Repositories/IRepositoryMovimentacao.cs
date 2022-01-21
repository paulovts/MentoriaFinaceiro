using System;
using System.Collections.Generic;
using System.Linq;
using MentoriaFinanceiro.Domain.Entities;

namespace MentoriaFinanceiro.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryMovimentacao : IRepositoryBase<Movimentacao>
    {
        decimal SaldoAnterior(int ContaID, DateTime dataInicio);
        decimal SaldoPeriodo(int ContaID, DateTime dataFIm);
        List<ExtratoMovimentacao> GetMovimentacao(int ContaID, DateTime dataInicio, DateTime dataFIm);
    }
}
