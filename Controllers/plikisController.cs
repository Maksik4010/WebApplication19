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
    public class plikisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public plikisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: plikis
        public async Task<IActionResult> Index()
        {
            return View(await _context.plikis.ToListAsync());
        }

        // GET: plikis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pliki = await _context.plikis
                .FirstOrDefaultAsync(m => m.id_pliki == id);
            if (pliki == null)
            {
                return NotFound();
            }

            return View(pliki);
        }

        // GET: plikis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: plikis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_pliki,nazwa,id_uzytkownicy,link_bezpośredni")] pliki pliki)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                pliki.id_uzytkownicy = userId.ToString();
                _context.Add(pliki);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pliki);
        }

        // GET: plikis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pliki = await _context.plikis.FindAsync(id);
            if (pliki == null)
            {
                return NotFound();
            }
            return View(pliki);
        }

        // POST: plikis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_pliki,nazwa,id_uzytkownicy,link_bezpośredni")] pliki pliki)
        {
            if (id != pliki.id_pliki)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pliki);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!plikiExists(pliki.id_pliki))
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
            return View(pliki);
        }

        // GET: plikis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pliki = await _context.plikis
                .FirstOrDefaultAsync(m => m.id_pliki == id);
            if (pliki == null)
            {
                return NotFound();
            }

            return View(pliki);
        }

        // POST: plikis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pliki = await _context.plikis.FindAsync(id);

            _context.plikis.Remove(pliki);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool plikiExists(int id)
        {
            return _context.plikis.Any(e => e.id_pliki == id);
        }
    }
}
