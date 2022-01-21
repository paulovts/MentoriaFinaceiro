using MentoriaFinanceiro.Domain.Entities;

namespace MentoriaFinanceiro.Domain.Core.Interfaces.Services
{
    public interface IServiceConta : IServiceBase<Conta>
    {
        int IsPessoaTemConta(int pessoaID);
        Conta GetConta(string agencia, string conta);
    }
}
