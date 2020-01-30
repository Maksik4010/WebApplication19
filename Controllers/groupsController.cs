using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication19.Data;
using WebApplication19.Models;

namespace WebApplication19.Controllers
{
    public class groupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public groupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: groups
        public async Task<IActionResult> Index()
        {
            return View(await _context.grupy_Dyskusyjnes.ToListAsync());
        }

        // GET: groups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupy_dyskusyjne = await _context.grupy_Dyskusyjnes
                .FirstOrDefaultAsync(m => m.id_grupy_dyskusyjne == id);
            if (grupy_dyskusyjne == null)
            {
                return NotFound();
            }

            return View(grupy_dyskusyjne);
        }

        // GET: groups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_grupy_dyskusyjne,nazwa,id_uzytkownicy,data_zalozenia")] grupy_dyskusyjne grupy_dyskusyjne)
        {
            if (ModelState.IsValid)
            {
                grupy_dyskusyjne.data_zalozenia = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
                _context.Add(grupy_dyskusyjne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grupy_dyskusyjne);
        }

        // GET: groups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupy_dyskusyjne = await _context.grupy_Dyskusyjnes.FindAsync(id);
            if (grupy_dyskusyjne == null)
            {
                return NotFound();
            }
            return View(grupy_dyskusyjne);
        }

        // POST: groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_grupy_dyskusyjne,nazwa,id_uzytkownicy,data_zalozenia")] grupy_dyskusyjne grupy_dyskusyjne)
        {
            if (id != grupy_dyskusyjne.id_grupy_dyskusyjne)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupy_dyskusyjne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!grupy_dyskusyjneExists(grupy_dyskusyjne.id_grupy_dyskusyjne))
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
            return View(grupy_dyskusyjne);
        }

        // GET: groups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupy_dyskusyjne = await _context.grupy_Dyskusyjnes
                .FirstOrDefaultAsync(m => m.id_grupy_dyskusyjne == id);
            if (grupy_dyskusyjne == null)
            {
                return NotFound();
            }

            return View(grupy_dyskusyjne);
        }

        // POST: groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grupy_dyskusyjne = await _context.grupy_Dyskusyjnes.FindAsync(id);
            _context.grupy_Dyskusyjnes.Remove(grupy_dyskusyjne);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool grupy_dyskusyjneExists(int id)
        {
            return _context.grupy_Dyskusyjnes.Any(e => e.id_grupy_dyskusyjne == id);
        }
    }
}
