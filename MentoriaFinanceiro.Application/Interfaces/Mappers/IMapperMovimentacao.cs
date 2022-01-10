using DesafioMentoria.Application.Dtos;
using DesafioMentoria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMentoria.Application.Interfaces.Mappers
{
    public interface IMapperMovimentacao
    {
        Movimentacao MapperDtoToEntity(MovimentacaoDto movimentacaoDto);
        IEnumerable<MovimentacaoDto> MapperListMovimentacoesDto(IEnumerable<Movimentacao> movimentacoes);
        MovimentacaoDto MapperEntityToDto(Movimentacao movimentacao);
    }
}
