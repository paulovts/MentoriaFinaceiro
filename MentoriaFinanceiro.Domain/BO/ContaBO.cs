using System;
using System.Collections.Generic;
using System.Text;
using MentoriaFinanceiro.Domain.Entities;


namespace MentoriaFinanceiro.Domain.BO
{
    public class ContaBO
    {
        public void ValidarInsercaoConta(Conta conta)
        {
            if (conta == null)
            {
                throw new FormatException("Não foi informado uma conta");
            }

            if (conta.ValorSaldoAtual.Equals(null))
            {
                throw new FormatException("Informe um valor para o saldo inicial");
            }

            if (conta.PessoaId.Equals(null))
            {
                throw new FormatException("Informe um correntista");
            }
            if (conta.Agencia.Equals(null))
            {
                throw new FormatException("Informe um Agencia");
            }
            if (conta.ContaCorrente.Equals(null))
            {
                throw new FormatException("Informe uma Conta Corrente");
            }

        }
    }
}
