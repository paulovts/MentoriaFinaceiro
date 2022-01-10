using DesafioMentoria.Application.Dtos;
using DesafioMentoria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMentoria.Application.Interfaces.Mappers
{
    public interface IMapperConta 
    {
        Conta MapperDtoToEntity(ContaDto contaDto);
        IEnumerable<ContaDto> MapperListContaDto(IEnumerable<Conta> contas);
        ContaDto MapperEntityToDto(Conta conta);
    }
}
