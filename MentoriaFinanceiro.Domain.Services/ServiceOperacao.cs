using DesafioMentoria.Domain.Core.Interfaces.Repositories;
using DesafioMentoria.Domain.Core.Interfaces.Services;
using DesafioMentoria.Domain.Entities;

namespace DesafioMentoria.Domain.Services
{
    public class ServiceOperacao : ServiceBase<Operacao>, IServiceOperacao
    {
        private readonly IRepositoryOperacao repositoryOperacao;

        public ServiceOperacao(IRepositoryOperacao repositoryOperacao) : base(repositoryOperacao)
        {
            this.repositoryOperacao = repositoryOperacao;
        }
    }
}
