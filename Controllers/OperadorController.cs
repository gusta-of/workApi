using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using workApi.Model;
using workApi.Repository;
namespace workApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperadorController : ControllerBase
    {
        private readonly OperadorRepository _operadorRepository;
        public OperadorController(OperadorRepository operadorRepository)
        {
            _operadorRepository = operadorRepository;
        }

        [HttpGet]
        [Produces(typeof(Operador))]
        public IActionResult Get()
        {
            var operadores = _operadorRepository.GetAll();
            if (operadores.Count() == 0)
                return NoContent();
            return Ok(operadores);
        }

        [HttpGet("{id}")]
        [Produces(typeof(Operador))]
        public IActionResult GetTodoItem(long id)
        {
            var operador = _operadorRepository.GetId(id);

            if (operador == null)
            {
                return NotFound();
            }

            return Ok(operador);
        }
    }
}