using System;
using System.Collections.Generic;
using System.Linq;
using MentoriaFinanceiro.Domain.Core.Interfaces.Repositories;
using MentoriaFinanceiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
namespace MentoriaFinanceiro.Infrastructure.Data.Repositories
{
    public class RepositoryConta : RepositoryBase<Conta>, IRepositoryConta
    {
        private readonly SqlContext sqlContext;

        public RepositoryConta(SqlContext sqlContext) : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
        public int IsPessoaTemConta(int pessoaID)
        {
            return sqlContext.Set<Conta>()
            .Where<Conta>(Conta => Conta.PessoaId == pessoaID)
            .Count();

        }
        public Conta GetConta(string agencia, string conta)
        {
            return sqlContext.Set<Conta>()
            .Where<Conta>(Conta => Conta.Agencia == agencia)
            .Where<Conta>(Conta => Conta.ContaCorrente == conta)
            .First();

        }
    }
}
