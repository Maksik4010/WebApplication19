using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication19.Data;
using WebApplication19.Models;

namespace WebApplication19.Controllers
{
    public class wiadomoscisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public wiadomoscisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: wiadomoscis
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.uzytkownik = userId;
            return View(await _context.wiadomoscis.ToListAsync());
        }

        // GET: wiadomoscis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wiadomosci = await _context.wiadomoscis
                .FirstOrDefaultAsync(m => m.Id_wiadomosci == id);
            if (wiadomosci == null)
            {
                return NotFound();
            }

            return View(wiadomosci);
        }

        // GET: wiadomoscis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: wiadomoscis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_wiadomosci,Id_konwersacji,id_uzytkownicy,tresc,data_utworzenia,czy_usunieta")] wiadomosci wiadomosci)
        {
            if (ModelState.IsValid)
            {
                wiadomosci.data_utworzenia = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                wiadomosci.id_uzytkownicy = userId.ToString();
                _context.Add(wiadomosci);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wiadomosci);
        }

        // GET: wiadomoscis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wiadomosci = await _context.wiadomoscis.FindAsync(id);
            if (wiadomosci == null)
            {
                return NotFound();
            }
            return View(wiadomosci);
        }

        // POST: wiadomoscis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_wiadomosci,Id_konwersacji,id_uzytkownicy,tresc,data_utworzenia,czy_usunieta")] wiadomosci wiadomosci)
        {
            if (id != wiadomosci.Id_wiadomosci)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wiadomosci);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!wiadomosciExists(wiadomosci.Id_wiadomosci))
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
            return View(wiadomosci);
        }

        // GET: wiadomoscis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wiadomosci = await _context.wiadomoscis
                .FirstOrDefaultAsync(m => m.Id_wiadomosci == id);
            if (wiadomosci == null)
            {
                return NotFound();
            }

            return View(wiadomosci);
        }

        // POST: wiadomoscis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wiadomosci = await _context.wiadomoscis.FindAsync(id);
            _context.wiadomoscis.Remove(wiadomosci);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool wiadomosciExists(int id)
        {
            return _context.wiadomoscis.Any(e => e.Id_wiadomosci == id);
        }
    }
}
