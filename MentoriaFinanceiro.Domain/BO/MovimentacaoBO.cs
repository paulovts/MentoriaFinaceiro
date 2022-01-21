using System;
using System.Collections.Generic;
using System.Text;
using MentoriaFinanceiro.Domain.Entities;

namespace MentoriaFinanceiro.Domain.BO
{
    public class MovimentacaoBO
    {
        public void ValidarInsercaoMovimentacao(Movimentacao movimentacao)
        {
            if (movimentacao == null)
            {
                throw new FormatException("Informe uma movimetação");
            }
        }
    }
}
