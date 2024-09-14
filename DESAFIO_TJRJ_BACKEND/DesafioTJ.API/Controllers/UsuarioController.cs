using DesafioTJ.API.Authorization;
using DesafioTJ.Domain.Helper;
using DesafioTJ.Domain.Interfaces.Service;
using DesafioTJ.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace DesafioTJ.API.Controllers
{
    [Authorize]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [AllowAnonymous]
        [HttpGet("Usuarios")]
        public IActionResult ListarUsuarios()
        {
            IList<UsuarioViewModel> usuarios = _usuarioService.ListarUsuarios();

            return Ok(usuarios);
        }

        [HttpGet("Usuarios/{id}")]
        public IActionResult ObterUsuario(int id)
        {
            UsuarioViewModel usuario = _usuarioService.ObterUsuarioPorId(id);

            return usuario != null ? Ok(usuario) : NotFound();
        }

        [HttpGet("Usuarios/Origem/{origem}")]
        public IActionResult ObterUsuarioPorOrigem(string origem)
        {
            IList<UsuarioViewModel> usuarios = _usuarioService.ListarUsuariosPorOrigem(origem);

            return Ok(usuarios);
        }

        [HttpPost("Usuarios")]
        public IActionResult IncluirUsuario([FromBody] UsuarioViewModel usuario)
        {
            try
            {
                ValidatorHelper.ValidarUsuario(usuario);

                _usuarioService.IncluirUsuario(usuario);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
