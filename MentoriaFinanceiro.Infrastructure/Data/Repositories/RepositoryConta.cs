using DesafioMentoria.Domain.Core.Interfaces.Repositories;
using DesafioMentoria.Domain.Entities;

namespace DesafioMentoria.Infrastructure.Data.Repositories
{
    public class RepositoryConta : RepositoryBase<Conta>, IRepositoryConta
    {
        private readonly SqlContext sqlContext;

        public RepositoryConta(SqlContext sqlContext) : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}
