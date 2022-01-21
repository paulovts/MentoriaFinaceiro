using MentoriaFinanceiro.Application.Dtos;
using MentoriaFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MentoriaFinanceiro.Application.Interfaces
{
    public interface IApplicationServiceConta
    {
        void Add(ContaDto contaDto);
        void Remove(ContaDto contaDto);
        void Update(ContaDto contaDto);
        IEnumerable<ContaDto> GetAll();
        ContaDto GetById(int id);

        ExtratoBancario Extrato(string agencia, string conta, DateTime dataInicio, DateTime dataFim);
    }
}
