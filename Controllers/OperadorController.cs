using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using workApi.Interfaces.ISercive;
using workApi.Model;

namespace workApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class OperadorController : ControllerBase
    {
        private readonly IOperadorService _operadorService;
        
        public OperadorController(IOperadorService operadorService)
        {
            _operadorService = operadorService;
        }

        [AllowAnonymous]
        [HttpPost("autenticacao")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var user = _operadorService.Autentique(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Usuário e Senha Incorreto!" });

            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _operadorService.GetAll();
            return Ok(users);
        }
    }
}