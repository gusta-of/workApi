using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using workApi.Model;
using workApi.Services;

namespace workApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaService _pessoaService;

        public PessoaController(PessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        [Produces(typeof(Pessoa))]
        public IActionResult Get()
        {
            var pessoas = _pessoaService.GetAll();
            if (pessoas.Count() == 0)
                return NoContent();
            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        [Produces(typeof(Pessoa))]
        public IActionResult GetTodoItem(long id)
        {
            var pessoa = _pessoaService.GetId(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return Ok(pessoa);
        }
    }
}