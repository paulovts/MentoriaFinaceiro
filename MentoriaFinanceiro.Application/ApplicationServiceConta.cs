using System;
using MentoriaFinanceiro.Application.Dtos;
using MentoriaFinanceiro.Application.Interfaces;
using MentoriaFinanceiro.Application.Interfaces.Mappers;
using MentoriaFinanceiro.Domain.Entities;
using MentoriaFinanceiro.Domain.BO;
using MentoriaFinanceiro.Domain.Services;

using MentoriaFinanceiro.Domain.Core.Interfaces.Services;
using System.Collections.Generic;

namespace MentoriaFinanceiro.Application
{
    public class ApplicationServiceConta : IApplicationServiceConta
    {
        private readonly IServiceConta serviceConta;
        private readonly IMapperConta mapperConta;
        private readonly ContaBO contaBO = new ContaBO();
        private readonly IServiceMovimentacao serviceMovimentacao;
        private readonly IServicePessoa servicePessoa;

        public ApplicationServiceConta (IServiceConta serviceConta, IMapperConta mapperConta, IServiceMovimentacao serviceMovimentacao, IServicePessoa servicePessoa)
        {
            this.serviceConta = serviceConta;
            this.mapperConta = mapperConta;
            this.serviceMovimentacao = serviceMovimentacao;
            this.servicePessoa = servicePessoa;
        }

        public void Add(ContaDto contaDto)
        {
           var conta = mapperConta.MapperDtoToEntity(contaDto);
            contaBO.ValidarInsercaoConta(conta);
            serviceConta.Add(conta);
            var isContaAberta = GetConta(conta.Agencia , conta.ContaCorrente);

            var movAbertura = new Movimentacao
            {
                ContaId = isContaAberta.Id,
                Id = 0,
                OperacaoId = ApplicationServiceMovimentacao.DEPOSITO,
                DescricaoMovimentacao = "Abertura conta",
                DataMovimentacao = DateTime.Now,
                ValorMovimentacao = conta.ValorAbertura
            };

            serviceMovimentacao.Add(movAbertura);

        }

        public int IsPessoaTemConta(int pessoaID)
        {
            return serviceConta.IsPessoaTemConta(pessoaID);

        }

        public ContaDto GetConta(string agencia , string conta)
        {
            var contas = serviceConta.GetConta(agencia, conta);
            return mapperConta.MapperEntityToDto(contas);
        }
        public IEnumerable<ContaDto> GetAll()
        {
            var contas = serviceConta.GetAll();
            return mapperConta.MapperListContaDto(contas);
        }

        public ContaDto GetById(int id)
        {
            var contas = serviceConta.GetById(id);
            return mapperConta.MapperEntityToDto(contas);
        }

        public void Remove(ContaDto contaDto)
        {
            var pessoa = mapperConta.MapperDtoToEntity(contaDto);
            serviceConta.Remove(pessoa);
        }

        public void Update(ContaDto contaDto)
        {
            var conta = mapperConta.MapperDtoToEntity(contaDto);
            serviceConta.Update(conta);
        }

        public void depositarSaldoConta(Conta conta, decimal valor)
        {
            conta.ValorSaldoAtual += valor;
            serviceConta.Update(conta);

        }
        public void debitarSaldoConta(Conta conta, decimal valor)
        {
            conta.ValorSaldoAtual -= valor;
            serviceConta.Update(conta);

        }

        public ExtratoBancario Extrato(string agencia, string contaCorrente, DateTime dataInicio, DateTime dataFim)
        {
            var conta = GetConta(agencia, contaCorrente);

            var pessoa = servicePessoa.GetById(conta.PessoaId);

            var extrato = serviceMovimentacao.Extrato(mapperConta.MapperDtoToEntity(conta), dataInicio, dataFim);
            extrato.Agencia = conta.Agencia;
            extrato.Conta = conta.ContaCorrente;
            extrato.SaldoAtual = conta.ValorSaldoAtual;

            return extrato;
        }
    }
}
