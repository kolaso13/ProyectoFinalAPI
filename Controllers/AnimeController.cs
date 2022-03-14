using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAnimeProyecto.Models;

namespace WebApiAnimeProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private readonly AnimeContext _context;

        public AnimeController(AnimeContext context)
        {
            _context = context;
        }

        // GET: api/Anime
        [Autohorrize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimeData>>> GetAnimeData()
        {
            return await _context.AnimeData.ToListAsync();
        }

        // GET: api/Anime/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimeData>> GetAnimeData(string id)
        {
            var AnimeData = await _context.AnimeData.FindAsync(id);

            if (AnimeData == null)
            {
                return NotFound();
            }

            return AnimeData;
        }

        // PUT: api/Anime/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimeData(string id, AnimeData AnimeData)
        {
            if (id != AnimeData.Id)
            {
                return BadRequest();
            }

            _context.Entry(AnimeData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimeDataExists(id))
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

        // POST: api/Anime
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnimeData>> PostAnimeData(AnimeData AnimeData)
        {
            _context.AnimeData.Add(AnimeData);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AnimeDataExists(AnimeData.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAnimeData", new { id = AnimeData.Id }, AnimeData);
        }

        // DELETE: api/Anime/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimeData(string id)
        {
            var AnimeData = await _context.AnimeData.FindAsync(id);
            if (AnimeData == null)
            {
                return NotFound();
            }

            _context.AnimeData.Remove(AnimeData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimeDataExists(string id)
        {
            return _context.AnimeData.Any(e => e.Id == id);
        }
    }
}
