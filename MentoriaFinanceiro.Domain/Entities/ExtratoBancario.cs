using System;
using System.Collections.Generic;
using System.Text;

namespace MentoriaFinanceiro.Domain.Entities
{
    public class ExtratoBancario
    {
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public decimal SaldoAnterior { get; set; }
        public decimal SaldoFinalPeriodo { get; set; }
        public decimal SaldoAtual { get; set; }
        public List<ExtratoMovimentacao> Movimentacao { get; set; }
    }
}
