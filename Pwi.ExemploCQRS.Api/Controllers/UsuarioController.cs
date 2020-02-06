using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pwi.ExemploCQRS.Handles.Commands.Usuario;
using Pwi.ExemploCQRS.Handles.Query;

namespace Pwi.ExemploCQRS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator, ILogger<UsuarioController> logger)
        {
            this._mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post(
            AddUsuarioCommand addUsuarioCommand)
        {
            try
            {
                await _mediator.Send(addUsuarioCommand);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            RetornarUsuarioPorNomeCommand retornarUsuarioPorNomeCommand)
        {
            try
            {
                IReadOnlyList<UsuarioQuery> listaUsuarioQuery = await _mediator
                    .Send(retornarUsuarioPorNomeCommand);

                return Ok(listaUsuarioQuery);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}