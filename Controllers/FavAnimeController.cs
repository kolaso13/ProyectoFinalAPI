using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApiAnimeProyecto.Models;

namespace WebApiTiempoProyecto.Controllers
{
    public class FavAnimeController : Controller
    {
        private readonly MVCpruebaContext _context;

        public FavAnimeController(MVCpruebaContext context)
        {
            _context = context;
        }

        // GET: FavAnime
        public async Task<IActionResult> Index()
        {
            var mVCpruebaContext = _context.Anime_User.Include(a => a.AnimeData).Include(a => a.User);
            return View(await mVCpruebaContext.ToListAsync());
        }

        // GET: FavAnime/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anime_User = await _context.Anime_User
                .Include(a => a.AnimeData)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.FavoritoId == id);
            if (anime_User == null)
            {
                return NotFound();
            }

            return View(anime_User);
        }

        // GET: FavAnime/Create
        public IActionResult Create()
        {
            ViewData["AnimeName"] = new SelectList(_context.AnimeData, "Name", "Name");
            ViewData["UsuarioId"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: FavAnime/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FavoritoId,AnimeName,UsuarioId")] Anime_User anime_User)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anime_User);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimeName"] = new SelectList(_context.AnimeData, "Name", "Name", anime_User.AnimeName);
            ViewData["UsuarioId"] = new SelectList(_context.User, "Id", "Id", anime_User.UsuarioId);
            return View(anime_User);
        }

        // GET: FavAnime/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anime_User = await _context.Anime_User.FindAsync(id);
            if (anime_User == null)
            {
                return NotFound();
            }
            ViewData["AnimeName"] = new SelectList(_context.AnimeData, "Name", "Name", anime_User.AnimeName);
            ViewData["UsuarioId"] = new SelectList(_context.User, "Id", "Id", anime_User.UsuarioId);
            return View(anime_User);
        }

        // POST: FavAnime/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FavoritoId,AnimeName,UsuarioId")] Anime_User anime_User)
        {
            if (id != anime_User.FavoritoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anime_User);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Anime_UserExists(anime_User.FavoritoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimeName"] = new SelectList(_context.AnimeData, "Name", "Name", anime_User.AnimeName);
            ViewData["UsuarioId"] = new SelectList(_context.User, "Id", "Id", anime_User.UsuarioId);
            return View(anime_User);
        }

        // GET: FavAnime/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anime_User = await _context.Anime_User
                .Include(a => a.AnimeData)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.FavoritoId == id);
            if (anime_User == null)
            {
                return NotFound();
            }

            return View(anime_User);
        }

        // POST: FavAnime/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anime_User = await _context.Anime_User.FindAsync(id);
            _context.Anime_User.Remove(anime_User);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Anime_UserExists(int id)
        {
            return _context.Anime_User.Any(e => e.FavoritoId == id);
        }
    }
}
