﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using workApi.Model;
using workApi.Services;

namespace workApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OperadorController : ControllerBase
    {
        private readonly OperadorService _operadorService;
        
        public OperadorController(OperadorService operadorService)
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
        [Produces(typeof(Pessoa))]
        public IActionResult GetAll()
        {
            var users = _operadorService.GetAll();
            return Ok(users);
        }
    }
}