using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Filmes2012API.Data;
using Filmes2012API.Models;

namespace Filmes2012API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly Filmes2012APIContext _context;

        public FilmeController(Filmes2012APIContext context)
        {
            _context = context;
        }

        // GET: api/Filme
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmeDTO>>> GetFilmes()
        {
            return await _context.Filmes
            .Select(x => FilmeToDTO(x))
            .ToListAsync();
        }

        // GET: api/Filme/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmeDTO>> GetFilme(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);

            if (filme == null)
            {
                return NotFound();
            }

            return FilmeToDTO(filme);
        }

        // PUT: api/Filme/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilme(int id, Filme filme)
        {
            if (id != filme.Id)
            {
                return BadRequest();
            }

            _context.Entry(filme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Filme
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Filme>> PostFilme(Filme filme)
        {
            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilme", new { id = filme.Id }, filme);
        }

        // DELETE: api/Filme/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilme(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);
            if (filme == null)
            {
                return NotFound();
            }

            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmeExists(int id)
        {
            return _context.Filmes.Any(e => e.Id == id);
        }

        private static FilmeDTO FilmeToDTO(Filme filme) =>
        new FilmeDTO
        {
            Id = filme.Id,
            Nome = filme.Nome,
            Genero = filme.Genero,
            Ano = filme.Ano,
            Duracao = filme.Duracao
        };
    }
}
