using DesafioMentoria.Domain.Core.Interfaces.Repositories;
using DesafioMentoria.Domain.Entities;

namespace DesafioMentoria.Infrastructure.Data.Repositories
{
    public class RepositoryOperacao : RepositoryBase<Operacao>, IRepositoryOperacao
    {
        private readonly SqlContext sqlContext;

        public RepositoryOperacao(SqlContext sqlContext) : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}
