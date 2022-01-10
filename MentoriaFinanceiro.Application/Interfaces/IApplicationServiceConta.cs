using DesafioMentoria.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMentoria.Application.Interfaces
{
    public interface IApplicationServiceConta
    {
        void Add(ContaDto contaDto);
        void Remove(ContaDto contaDto);
        void Update(ContaDto contaDto);
        IEnumerable<ContaDto> GetAll();
        ContaDto GetById(int id);
    }
}
