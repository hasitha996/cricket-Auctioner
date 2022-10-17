using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrickAuctioner.Data;
using CrickAuctioner.Models;
using Microsoft.AspNetCore.Authorization;

namespace CrickAuctioner.Controllers
{
    [Authorize]
    public class TrophiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrophiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trophies
        public async Task<IActionResult> Index()
        {
              return View(await _context.Trophy.ToListAsync());
        }

        // GET: Trophies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trophy == null)
            {
                return NotFound();
            }

            var trophy = await _context.Trophy
                .FirstOrDefaultAsync(m => m.TrophyId == id);
            if (trophy == null)
            {
                return NotFound();
            }

            return View(trophy);
        }

        // GET: Trophies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trophies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrophyId,TrophyName,TrophyYear,CreatedBy,CreatedOn")] Trophy trophy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trophy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trophy);
        }

        // GET: Trophies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trophy == null)
            {
                return NotFound();
            }

            var trophy = await _context.Trophy.FindAsync(id);
            if (trophy == null)
            {
                return NotFound();
            }
            return View(trophy);
        }

        // POST: Trophies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrophyId,TrophyName,TrophyYear,CreatedBy,CreatedOn")] Trophy trophy)
        {
            if (id != trophy.TrophyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trophy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrophyExists(trophy.TrophyId))
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
            return View(trophy);
        }

        // GET: Trophies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trophy == null)
            {
                return NotFound();
            }

            var trophy = await _context.Trophy
                .FirstOrDefaultAsync(m => m.TrophyId == id);
            if (trophy == null)
            {
                return NotFound();
            }

            return View(trophy);
        }

        // POST: Trophies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trophy == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Trophy'  is null.");
            }
            var trophy = await _context.Trophy.FindAsync(id);
            if (trophy != null)
            {
                _context.Trophy.Remove(trophy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrophyExists(int id)
        {
          return _context.Trophy.Any(e => e.TrophyId == id);
        }
    }
}
