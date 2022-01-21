using MentoriaFinanceiro.Domain.Core.Interfaces.Repositories;
using MentoriaFinanceiro.Domain.Core.Interfaces.Services;
using MentoriaFinanceiro.Domain.Entities;

namespace MentoriaFinanceiro.Domain.Services
{
    public class ServiceConta : ServiceBase<Conta>, IServiceConta
    {
        private readonly IRepositoryConta repositoryConta;

        public ServiceConta(IRepositoryConta repositoryConta) : base(repositoryConta)
        {
            this.repositoryConta = repositoryConta;
        }

        public int IsPessoaTemConta(int pessoaID)
        {
            return this.repositoryConta.IsPessoaTemConta(pessoaID);
        }

        public Conta GetConta(string agencia, string conta)
        {
            return this.repositoryConta.GetConta(agencia, conta);
        }
    }
}
