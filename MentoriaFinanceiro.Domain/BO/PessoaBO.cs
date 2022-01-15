using System;
using System.Collections.Generic;
using System.Text;
using MentoriaFinanceiro.Domain.Entities;

namespace MentoriaFinanceiro.Domain.BO
{
    public class PessoaBO
    {
        public void ValidarInsercaoPessoa(Pessoa pessoaDto)
        {
            if (pessoaDto == null)
            {
                throw new FormatException("Não foi informado o objeto Pessoa");
            }

            if (!pessoaDto.DataNascimento.HasValue)
            {
                throw new FormatException("Não foi informada data de nascimento");
            }

            if (pessoaDto.DataNascimento.Value.AddYears(18) > DateTime.Now)
            {
                throw new FormatException("É necessário ter mais de 18 anos");
            }
        }
    }
}
