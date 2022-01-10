using DesafioMentoria.Domain.Core.Interfaces.Repositories;
using DesafioMentoria.Domain.Entities;

namespace DesafioMentoria.Infrastructure.Data.Repositories
{
    public class RepositoryPessoa : RepositoryBase<Pessoa>, IRepositoryPessoa
    {
        private readonly SqlContext sqlContext;

        public RepositoryPessoa (SqlContext sqlContext) : base (sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}
