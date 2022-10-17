using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrickAuctioner.Data;
using CrickAuctioner.Models;
using System.Globalization;

namespace CrickAuctioner.Controllers
{
    public class PlayerAccountsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayerAccountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PlayerAccounts
        public async Task<IActionResult> Index()
        {
           return View(await _context.PlayerAccount.ToListAsync());
        }

        // GET: PlayerAccounts
        public async Task<IActionResult> PLogin()
        {
            return View(await _context.PlayerAccount.ToListAsync());
        }

        // GET: PlayerAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PlayerAccount == null)
            {
                return NotFound();
            }

            var playerAccount = await _context.PlayerAccount
                .FirstOrDefaultAsync(m => m.PlayerId == id);
            if (playerAccount == null)
            {
                return NotFound();
            }

            return View(playerAccount);
        }

        // GET: PlayerAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: PlayerAccounts/Create
        public IActionResult Register()
        {
            return View();
        }

        // POST: PlayerAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("PlayerId,PlayerName,PlayerEmail,PlayerDOB,Password,ConfirmPassword,PlayerCountry,CreatedOn")] PlayerAccount playerAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playerAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(PLogin));
            }
            return View(playerAccount);
        }

        // POST: PlayerAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerId,PlayerName,PlayerEmail,PlayerDOB,Password,ConfirmPassword,PlayerCountry,CreatedOn")] PlayerAccount playerAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playerAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playerAccount);
        }

        // GET: PlayerAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PlayerAccount == null)
            {
                return NotFound();
            }

            var playerAccount = await _context.PlayerAccount.FindAsync(id);
            if (playerAccount == null)
            {
                return NotFound();
            }
            return View(playerAccount);
        }

        // POST: PlayerAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlayerId,PlayerName,PlayerEmail,PlayerDOB,Password,ConfirmPassword,PlayerCountry,CreatedOn")] PlayerAccount playerAccount)
        {
            if (id != playerAccount.PlayerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerAccountExists(playerAccount.PlayerId))
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
            return View(playerAccount);
        }

        // GET: PlayerAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PlayerAccount == null)
            {
                return NotFound();
            }

            var playerAccount = await _context.PlayerAccount
                .FirstOrDefaultAsync(m => m.PlayerId == id);
            if (playerAccount == null)
            {
                return NotFound();
            }

            return View(playerAccount);
        }

        // POST: PlayerAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PlayerAccount == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PlayerAccount'  is null.");
            }
            var playerAccount = await _context.PlayerAccount.FindAsync(id);
            if (playerAccount != null)
            {
                _context.PlayerAccount.Remove(playerAccount);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerAccountExists(int id)
        {
          return _context.PlayerAccount.Any(e => e.PlayerId == id);
        }
    }
}
