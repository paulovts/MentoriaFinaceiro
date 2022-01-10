using DesafioMentoria.Domain.Core.Interfaces.Repositories;
using DesafioMentoria.Domain.Core.Interfaces.Services;
using DesafioMentoria.Domain.Entities;

namespace DesafioMentoria.Domain.Services
{
    public class ServiceMovimentacao : ServiceBase<Movimentacao> , IServiceMovimentacao
    {
        private readonly IRepositoryMovimentacao repositoryMovimentacao;
        public ServiceMovimentacao(IRepositoryMovimentacao repositoryMovimentacao) : base(repositoryMovimentacao)
        {
            this.repositoryMovimentacao = repositoryMovimentacao;
        }
    }
}
