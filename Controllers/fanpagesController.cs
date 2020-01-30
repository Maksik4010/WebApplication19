using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication19.Data;
using WebApplication19.Models;

namespace WebApplication19.Controllers
{
    public class fanpagesController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public fanpagesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: fanpages
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            ViewBag.uzytkownik = userId;

            ICollection<uzytkownicy> allUsers = _context.uzytkownicies.ToList();
            ViewBag.allUsers = allUsers;
            return View(await _context.fanpages.ToListAsync());
        }

        // GET: fanpages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fanpage = await _context.fanpages
                .FirstOrDefaultAsync(m => m.id_fanpage == id);
            if (fanpage == null)
            {
                return NotFound();
            }

            return View(fanpage);
        }

        // GET: fanpages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: fanpages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_fanpage,id_uzytkownicy,nazwa,kategoria,data_zalozenia,liczba_polubien")] fanpage fanpage)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                fanpage.id_uzytkownicy = userId;
                _context.Add(fanpage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fanpage);
        }

        // GET: fanpages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fanpage = await _context.fanpages.FindAsync(id);
            if (fanpage == null)
            {
                return NotFound();
            }
            return View(fanpage);
        }

        // POST: fanpages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_fanpage,id_uzytkownicy,nazwa,kategoria,data_zalozenia,liczba_polubien")] fanpage fanpage)
        {
            if (id != fanpage.id_fanpage)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fanpage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!fanpageExists(fanpage.id_fanpage))
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
            return View(fanpage);
        }

        // GET: fanpages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fanpage = await _context.fanpages
                .FirstOrDefaultAsync(m => m.id_fanpage == id);
            if (fanpage == null)
            {
                return NotFound();
            }

            return View(fanpage);
        }

        // POST: fanpages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fanpage = await _context.fanpages.FindAsync(id);
            _context.fanpages.Remove(fanpage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool fanpageExists(int id)
        {
            return _context.fanpages.Any(e => e.id_fanpage == id);
        }
    }
}
