using DesafioMentoria.Application.Dtos;
using DesafioMentoria.Domain.Entities;
using System.Collections.Generic;

namespace DesafioMentoria.Application.Interfaces.Mappers
{
    public interface IMapperPessoa
    {
        Pessoa MapperDtoToEntity(PessoaDto pessoaDto);
        IEnumerable<PessoaDto> MapperListPessoaDto(IEnumerable<Pessoa> pessoas);
        PessoaDto MapperEntityToDto(Pessoa pessoa);
    }
}
