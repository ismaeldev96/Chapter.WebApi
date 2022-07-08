using Chapter.WebApi.Models;
using Chapter.WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chapter.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly LivroRepository _livroRepository;

        public LivroController(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_livroRepository.Listar());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            try
            {
                Livro livroBuscado = _livroRepository.BuscarId(id);
                if(livroBuscado == null)
                {
                    return NotFound();
                }

                return Ok(livroBuscado);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Livro livro)
        {
            try
            {
                _livroRepository.Cadastrar(livro);
                return StatusCode(201);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                Livro livroBuscado = _livroRepository.BuscarId(id);
                if (livroBuscado == null)
                {
                    return StatusCode(410);
                }
                else
                {
                    _livroRepository.Deletar(id);
                }

                return Ok("Livro removido com sucesso");

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Livro livro)
        {
            try
            {
                Livro livroBuscado = _livroRepository.BuscarId(id);
                if (livroBuscado == null)
                {
                    return StatusCode(410);
                }
                else
                {
                    _livroRepository.Atualizar(id, livro);
                    return StatusCode(204);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
