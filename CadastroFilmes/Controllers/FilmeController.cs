using CadastroFilmes.Data;
using CadastroFilmes.Models;
using CadastroFilmes.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;


namespace CadastroFilmes.Controllers
{
    [ApiController]
    [Route("api/Filmes")]
    public class FilmeController : Controller
    {
        private readonly FilmeRepositorio _repositorioFilme;
        private readonly Context _context;


        public FilmeController()
        {
            _context = new Context();
            _repositorioFilme = new FilmeRepositorio(_context);

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var filme = _repositorioFilme.GetAll();
            return Ok(filme);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var filme = _repositorioFilme.GetById(id);
            if (filme == null)
            {
                return NotFound();
            }
            return Ok(filme);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Filme _filme)
        {
            var filme = new Filme { Nome = _filme.Nome, DataCriacao = DateTime.Now, Ativo = _filme.Ativo, GeneroId = _filme.GeneroId };
            _repositorioFilme.Create(filme);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Edite([FromBody] Filme filme, int id)
        {
            var _filme = _repositorioFilme.GetById(id);

            if (_filme == null)
            {
                return NotFound();
            }

            try
            {
                _filme.Nome = filme.Nome;
                _filme.Ativo = filme.Ativo;
                _filme.GeneroId = filme.GeneroId;
                _repositorioFilme.Update(_filme);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var filme = _repositorioFilme.GetById(id);
            if (filme == null)
            {
                return NotFound();
            }

            try
            {
                _repositorioFilme.Delete(filme);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{ids}")]
        public IActionResult  DeletarListaIds([FromQuery] int[] ids)
        {
            try
            {
                _repositorioFilme.GetListIds(ids);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
