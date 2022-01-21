using System;
using System.Collections.Generic;
using System.Text;

namespace MentoriaFinanceiro.Domain.Entities
{
    public class ExtratoMovimentacao
    {
        public int ContaId { get; set; }
        public DateTime? DataMovimentacao { get; set; }
        public decimal ValorMovimentacao { get; set; }
        public string DescricaoMovimentacao { get; set; }
        public char TipoMovimentacao { get; set; }
        public string NomeOperacao { get; set; }
    }
}
