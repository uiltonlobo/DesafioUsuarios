using DesafioTJ.API.Authorization;
using DesafioTJ.Domain.Interfaces.Repository;
using DesafioTJ.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTJ.API.Controllers
{
    [Authorize]
    [ApiController]
    public class TipoUsuarioController : Controller
    {
        private readonly ITipoUsuarioService _tipoUsuarioService;

        public TipoUsuarioController(ITipoUsuarioService tipoUsuarioService)
        {
            _tipoUsuarioService = tipoUsuarioService;
        }

        [HttpGet("TiposUsuarios")]
        public IActionResult ListarTiposUsuario()
        {
            return Ok(_tipoUsuarioService.ListarTiposUsuario());
        }
    }
}
