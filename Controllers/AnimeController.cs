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
    public class AnimeController : Controller
    {
        private readonly MVCpruebaContext _context;

        public AnimeController(MVCpruebaContext context)
        {
            _context = context;
        }

        // GET: Anime
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnimeData.ToListAsync());
        }

        // GET: Anime/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animeData = await _context.AnimeData
                .FirstOrDefaultAsync(m => m.Name == id);
            if (animeData == null)
            {
                return NotFound();
            }

            return View(animeData);
        }

        // GET: Anime/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Anime/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Chapters,Image,Studio,Date,Genre")] AnimeData animeData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animeData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animeData);
        }

        // GET: Anime/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animeData = await _context.AnimeData.FindAsync(id);
            if (animeData == null)
            {
                return NotFound();
            }
            return View(animeData);
        }

        // POST: Anime/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Description,Chapters,Image,Studio,Date,Genre")] AnimeData animeData)
        {
            if (id != animeData.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animeData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimeDataExists(animeData.Name))
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
            return View(animeData);
        }

        // GET: Anime/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animeData = await _context.AnimeData
                .FirstOrDefaultAsync(m => m.Name == id);
            if (animeData == null)
            {
                return NotFound();
            }

            return View(animeData);
        }

        // POST: Anime/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var animeData = await _context.AnimeData.FindAsync(id);
            _context.AnimeData.Remove(animeData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimeDataExists(string id)
        {
            return _context.AnimeData.Any(e => e.Name == id);
        }
    }
}
