using MentoriaFinanceiro.Application.Dtos;
using MentoriaFinanceiro.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MentoriaFinanceiro.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IApplicationServicePessoa _applicationServicePessoa;

        public PessoaController(IApplicationServicePessoa ApplicationServicePessoa)
        {
            _applicationServicePessoa = ApplicationServicePessoa;
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServicePessoa.GetAll());
        }

        [HttpGet("{id}")]

        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationServicePessoa.GetAll());
        }
        
        [HttpPost]
        public ActionResult Post([FromBody] PessoaDto pessoaDto)
        {
            try
            {
                if (pessoaDto == null)
                    return NotFound();
                _applicationServicePessoa.Add(pessoaDto);
                return Ok("Cadastro de pessoa realizado com sucesso!");
            }catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [HttpPut]
        public ActionResult Put ([FromBody] PessoaDto pessoaDto)
        {
            try
            {
                if (pessoaDto == null)
                    return NotFound();
                _applicationServicePessoa.Update(pessoaDto);
                return Ok("Cadastro de pessoa atualizado com sucesso!");
            } catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [HttpDelete()]
        public ActionResult Delete([FromBody] PessoaDto pessoaDto)
        {
            try
            {
                if (pessoaDto == null)
                    return NotFound();
                _applicationServicePessoa.Remove(pessoaDto);
                return Ok("Cadastro de pessoa removido com sucesso!");
            } 
            catch (Exception ex)
            {
                throw ex;
            }
        }
    

    }
}
