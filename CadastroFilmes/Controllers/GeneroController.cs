using CadastroFilmes.Data;
using CadastroFilmes.Models;
using CadastroFilmes.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CadastroFilmes.Controllers
{
    [ApiController]
    [Route("api/Genero")]
    public class GeneroController : Controller
    {
        private readonly GeneroRepositorio _generoRepositorio;
        private readonly Context _context;

        public GeneroController()
        {
            _context = new Context();
            _generoRepositorio = new GeneroRepositorio(_context);

        }

        //api/Genero
        [HttpGet]
        public IActionResult GetAll()
        {
            var genero = _generoRepositorio.GetAll();
            return Ok(genero);
        }


        //api/Genero/[id]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var filme = _generoRepositorio.Get(id);
            if (filme == null)
            {
                return NotFound();
            }
            return Ok(filme);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Genero genero)
        {
            var insrirGenero = new Genero { Nome = genero.Nome, DataCriacao = DateTime.Now , Ativo = genero.Ativo};
            _generoRepositorio.Create(insrirGenero);
            return Ok();
        }


    }
}
