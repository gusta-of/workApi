using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using workApi.IRepository;
using workApi.Model;
using workApi.Repository;

namespace workApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaRepository _pessoaRepository;

        public PessoaController(PessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        [HttpGet]
        [Produces(typeof(Pessoa))]
        public IActionResult Get()
        {
            var pessoas = _pessoaRepository.GetAll();
            if (pessoas.Count() == 0)
                return NoContent();
            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        [Produces(typeof(Pessoa))]
        public IActionResult GetTodoItem(long id)
        {
            var pessoa = _pessoaRepository.GetId(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return Ok(pessoa);
        }
    }
}