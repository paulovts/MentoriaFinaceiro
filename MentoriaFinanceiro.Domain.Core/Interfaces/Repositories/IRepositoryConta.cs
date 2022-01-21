using MentoriaFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MentoriaFinanceiro.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryConta : IRepositoryBase<Conta>
    {
        int IsPessoaTemConta(int pessoaID);
        Conta GetConta(string agencia, string conta);
    }
}
