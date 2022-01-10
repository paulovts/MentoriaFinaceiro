using DesafioMentoria.Domain.Core.Interfaces.Repositories;
using DesafioMentoria.Domain.Core.Interfaces.Services;
using DesafioMentoria.Domain.Entities;

namespace DesafioMentoria.Domain.Services
{
    public class ServicePessoa : ServiceBase<Pessoa>, IServicePessoa
    {
        private readonly IRepositoryPessoa repositoryPessoa;

        public ServicePessoa(IRepositoryPessoa repositoryPessoa) : base(repositoryPessoa)
        {
            this.repositoryPessoa = repositoryPessoa;
        }
     }
}
