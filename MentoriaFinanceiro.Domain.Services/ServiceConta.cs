using DesafioMentoria.Domain.Core.Interfaces.Repositories;
using DesafioMentoria.Domain.Core.Interfaces.Services;
using DesafioMentoria.Domain.Entities;

namespace DesafioMentoria.Domain.Services
{
    public class ServiceConta : ServiceBase<Conta>, IServiceConta
    {
        private readonly IRepositoryConta repositoryConta;

        public ServiceConta(IRepositoryConta repositoryConta) : base(repositoryConta)
        {
            this.repositoryConta = repositoryConta;
        }
    }
}
