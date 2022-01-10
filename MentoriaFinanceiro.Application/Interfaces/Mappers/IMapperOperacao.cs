using DesafioMentoria.Application.Dtos;
using DesafioMentoria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMentoria.Application.Interfaces.Mappers
{
    public interface IMapperOperacao 
    {
        Operacao MapperDtoToEntity(OperacaoDto operacaoDto);
        IEnumerable<OperacaoDto> MapperListOperacoesDto(IEnumerable<Operacao> operacoes);
        OperacaoDto MapperEntityToDto(Operacao operacao);
    }
}
