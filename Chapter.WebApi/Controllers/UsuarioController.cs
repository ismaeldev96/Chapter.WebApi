using Chapter.WebApi.Interfaces;
using Chapter.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chapter.WebApi.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _iusuarioRepository;

        public UsuarioController(IUsuarioRepository iusuarioRepository)
        {
            _iusuarioRepository = iusuarioRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_iusuarioRepository.Listar());
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            try
            {
                Usuario usuarioEncontrado = _iusuarioRepository.BuscarId(id);
                if(usuarioEncontrado == null)
                {
                    return NotFound();
                }

               return Ok(usuarioEncontrado);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                _iusuarioRepository.Cadastrar(usuario);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Usuario usuario)
        {
            try
            {
                Usuario usuarioEncontrado = _iusuarioRepository.BuscarId(id);
                if (usuarioEncontrado == null)
                {
                    return NotFound();
                }
                _iusuarioRepository.Atualizar(id, usuario);
                return Ok("Usuario Alterado com Sucesso");
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            Usuario usuarioEncontrado = _iusuarioRepository.BuscarId(id);
            if (usuarioEncontrado == null)
            {
                return NotFound();
            }
            _iusuarioRepository.Deletar(id);
            return NoContent();
        }
    }
}
