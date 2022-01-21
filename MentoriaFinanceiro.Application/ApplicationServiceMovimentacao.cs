using MentoriaFinanceiro.Application.Dtos;
using MentoriaFinanceiro.Application.Interfaces;
using MentoriaFinanceiro.Application.Interfaces.Mappers;
using MentoriaFinanceiro.Domain.Core.Interfaces.Services;
using MentoriaFinanceiro.Domain.Entities;
using MentoriaFinanceiro.Domain.BO;
using System.Collections.Generic;
using System;

namespace MentoriaFinanceiro.Application
{
    public class ApplicationServiceMovimentacao : IApplicationServiceMovimentacao
    {

        public const int DEPOSITO = 1;
        public const int TRANSFERECIA_C = 2;
        public const int TRANSFERECIA_D = 4;
        public const int PAGAMENTO = 5;


        private readonly IServiceMovimentacao serviceMovimentacao;
        private readonly IMapperMovimentacao mapperMovimentacao;
        private readonly IServiceConta serviceConta;
        private readonly IServiceOperacao serviceOperacao;
        private readonly IApplicationServiceConta applicationServiceConta;
        public ApplicationServiceMovimentacao(IServiceMovimentacao serviceMovimentacao, IMapperMovimentacao mapperMovimentacao,
            IServiceConta serviceConta, IServiceOperacao serviceOperacao, IApplicationServiceConta applicationServiceConta)
        {
            this.serviceMovimentacao = serviceMovimentacao;
            this.mapperMovimentacao = mapperMovimentacao;
            this.serviceConta = serviceConta;
            this.serviceOperacao = serviceOperacao;
            this.applicationServiceConta = applicationServiceConta;
        }

        public void Add(MovimentacaoDto movimentacaoDto)
        {
            var movimentacao = mapperMovimentacao.MapperDtoToEntity(movimentacaoDto);
            serviceMovimentacao.Add(movimentacao);
        }

        public IEnumerable<MovimentacaoDto> GetAll()
        {
            var movimentacoes = serviceMovimentacao.GetAll();
            return mapperMovimentacao.MapperListMovimentacoesDto(movimentacoes);

        }

        public MovimentacaoDto GetById(int id)
        {
            var movimentacao = serviceMovimentacao.GetById(id);
            return mapperMovimentacao.MapperEntityToDto(movimentacao);
        }

        public void Remove(MovimentacaoDto movimentacaoDto)
        {
            var movimentacao = mapperMovimentacao.MapperDtoToEntity(movimentacaoDto);
            serviceMovimentacao.Remove(movimentacao);
        }

        public void Update(MovimentacaoDto movimentacaoDto)
        {
            var movimentacao = mapperMovimentacao.MapperDtoToEntity(movimentacaoDto);
            serviceMovimentacao.Remove(movimentacao);
        }


        public void Depositar(int contaid, decimal valor, string descricao = "Deposito Financeiro")
        {
            var conta = serviceConta.GetById(contaid);

            var realizardeposito = new Movimentacao
            {
                Id = 0,
                Conta = conta,
                ContaId = contaid,
                DataMovimentacao = DateTime.Now,
                DescricaoMovimentacao = descricao,
                OperacaoId = DEPOSITO,
                Operacao = serviceOperacao.GetById(DEPOSITO),
                ValorMovimentacao = valor
            };

            MovimentacaoBO.ValidarInsercaoMovimentacao(realizardeposito);

            serviceMovimentacao.Add(realizardeposito);

            applicationServiceConta.depositarSaldoConta(conta, valor);
        }

        //    public void Pagamento(int contaID, decimal valor, string descricao = "pagamento")
        //    {
        //        var conta = serviceConta.GetById(contaID);

        //        ContaRN.verificaSaldoConta(conta, valor);

        //        var realizarPagamento = new Movimentacao
        //        {
        //            Id = 0,
        //            Conta = conta,
        //            ContaId = contaID,
        //            DataMovimentacao = DateTime.Now,
        //            DescricaoMovimentacao = descricao,
        //            OperacaoId = PAGAMENTO,
        //            Operacao = serviceOperacao.GetById(PAGAMENTO),
        //            ValorMovimentacao = valor
        //        };

        //        MovimentacaoRN.validadarMovimentacao(realizarPagamento);


        //        serviceMovimentacao.Add(realizarPagamento);

        //        applicationServiceConta.debitarSaldoConta(conta, valor);
        //    }


        //    public void Transferencia(int contaID, decimal valor, string agenciaDestino, string contaDestino, string descricao = "pagamento")
        //    {

        //        var contaOrigem = serviceConta.GetById(contaID);
        //        ContaRN.verificaSaldoConta(contaOrigem, valor);

        //        var contaDestinatario = serviceConta.GetConta(agenciaDestino, contaDestino);
        //        ContaRN.verificaDeposito(contaDestinatario);

        //        var realizarPagamento = new Movimentacao
        //        {
        //            Id = 0,
        //            Conta = contaOrigem,
        //            ContaId = contaID,
        //            DataMovimentacao = DateTime.Now,
        //            DescricaoMovimentacao = " Tranferencia efetuada para agencia: " + contaDestinatario.Agencia + " Conta Corrente: " + contaDestinatario.ContaCorrente + " Descrição: " + descricao,
        //            OperacaoId = TRANSFERECIA_D,
        //            Operacao = serviceOperacao.GetById(TRANSFERECIA_D),
        //            ValorMovimentacao = valor
        //        };

        //        MovimentacaoRN.validadarMovimentacao(realizarPagamento);


        //        var realizarDeposito = new Movimentacao
        //        {
        //            Id = 0,
        //            Conta = contaDestinatario,
        //            ContaId = contaDestinatario.Id,
        //            DataMovimentacao = DateTime.Now,
        //            DescricaoMovimentacao = "Transferencia recebida da agencia:  " + contaOrigem.Agencia + " Conta Corrente: " + contaOrigem.ContaCorrente + " Descrição:" + descricao,
        //            OperacaoId = TRANSFERECIA_C,
        //            Operacao = serviceOperacao.GetById(TRANSFERECIA_C),
        //            ValorMovimentacao = valor
        //        };

        //        serviceMovimentacao.Add(realizarPagamento);
        //        serviceMovimentacao.Add(realizarDeposito);

        //        applicationServiceConta.debitarSaldoConta(contaOrigem, valor);
        //        applicationServiceConta.depositarSaldoConta(contaDestinatario, valor);
        //    }
    }
}
