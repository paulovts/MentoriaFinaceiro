using DesafioMentoria.Domain.Core.Interfaces.Repositories;
using DesafioMentoria.Domain.Entities;

namespace DesafioMentoria.Infrastructure.Data.Repositories
{
    public class RepositoryMovimentacao : RepositoryBase<Movimentacao>, IRepositoryMovimentacao
    {
        private readonly SqlContext sqlContext;

        public RepositoryMovimentacao(SqlContext sqlContext) : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}
