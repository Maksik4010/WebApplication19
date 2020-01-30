using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication19.Data;
using WebApplication19.Models;

namespace WebApplication19.Controllers
{
    public class znajomisController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public znajomisController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: znajomis
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.uzytkownik = userId;
            ICollection<uzytkownicy> allUsers = _context.uzytkownicies.ToList();
            ViewBag.allUsers = allUsers;
            return View(await _context.znajomis.ToListAsync());
        }

        // GET: znajomis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var znajomi = await _context.znajomis
                .FirstOrDefaultAsync(m => m.Id_znajomi == id);
            if (znajomi == null)
            {
                return NotFound();
            }

            return View(znajomi);
        }

        // GET: znajomis/Create
        public IActionResult Create()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            ICollection<uzytkownicy> uzyt = _context.uzytkownicies.ToList();
            ViewBag.uzytkonicy = uzyt;
            return View();
        }

        // POST: znajomis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_znajomi,Id_uzytkownicy,Id_znajomwgo,poczatek_znajomosci")] znajomi znajomi)
        {
            if (ModelState.IsValid)
            {
                znajomi.poczatek_znajomosci = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
                var userId = _userManager.GetUserId(HttpContext.User);
                znajomi.Id_uzytkownicy = userId.ToString();
                _context.Add(znajomi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(znajomi);
        }

        // GET: znajomis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var znajomi = await _context.znajomis.FindAsync(id);
            if (znajomi == null)
            {
                return NotFound();
            }
            return View(znajomi);
        }

        // POST: znajomis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_znajomi,Id_uzytkownicy,Id_znajomwgo,poczatek_znajomosci")] znajomi znajomi)
        {
            if (id != znajomi.Id_znajomi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(znajomi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!znajomiExists(znajomi.Id_znajomi))
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
            return View(znajomi);
        }

        // GET: znajomis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var znajomi = await _context.znajomis
                .FirstOrDefaultAsync(m => m.Id_znajomi == id);
            if (znajomi == null)
            {
                return NotFound();
            }

            return View(znajomi);
        }

        // POST: znajomis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var znajomi = await _context.znajomis.FindAsync(id);
            _context.znajomis.Remove(znajomi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool znajomiExists(int id)
        {
            return _context.znajomis.Any(e => e.Id_znajomi == id);
        }
    }
}
