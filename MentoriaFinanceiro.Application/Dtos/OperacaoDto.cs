using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMentoria.Application.Dtos
{
    public class OperacaoDto
    {
        public int Id { get; set; }
        public string NomeOperacao { get; set; }
        public char TipoMovimentacao { get; set; }
        public bool Ativo { get; set; }
    }
}
