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
    public class uzytkowniciesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public uzytkowniciesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: uzytkownicies
        public async Task<IActionResult> Index()
        {
            return View(await _context.uzytkownicies.ToListAsync());
        }

        // GET: uzytkownicies/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownicy = await _context.uzytkownicies
                .FirstOrDefaultAsync(m => m.id == id);
            if (uzytkownicy == null)
            {
                return NotFound();
            }

            return View(uzytkownicy);
        }

        // GET: uzytkownicies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: uzytkownicies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,login,haslo,imie,nazwisko,ksywka,kraj,data_zalozenia,ostatnie_logowanie,ip_ostatniego_logowania,liczba_znajomych")] uzytkownicy uzytkownicy)
        {
            if (ModelState.IsValid)
            {
                uzytkownicy.login = User.Identity.Name;

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                uzytkownicy.id = userId.ToString();
                uzytkownicy.data_zalozenia = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

                //var userId = (Guid)Membership.GetUser(User.Identity.Name).ProviderUserKey;
                _context.Add(uzytkownicy);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","posties");
            }
            return View(uzytkownicy);
        }

        // GET: uzytkownicies/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownicy = await _context.uzytkownicies.FindAsync(id);
            if (uzytkownicy == null)
            {
                return NotFound();
            }
            return View(uzytkownicy);
        }

        // POST: uzytkownicies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id,login,haslo,imie,nazwisko,ksywka,kraj,data_zalozenia,ostatnie_logowanie,ip_ostatniego_logowania,liczba_znajomych")] uzytkownicy uzytkownicy)
        {
            if (id != uzytkownicy.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uzytkownicy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!uzytkownicyExists(uzytkownicy.id))
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
            return View(uzytkownicy);
        }

        // GET: uzytkownicies/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownicy = await _context.uzytkownicies
                .FirstOrDefaultAsync(m => m.id == id);
            if (uzytkownicy == null)
            {
                return NotFound();
            }

            return View(uzytkownicy);
        }

        // POST: uzytkownicies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var uzytkownicy = await _context.uzytkownicies.FindAsync(id);
            _context.uzytkownicies.Remove(uzytkownicy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool uzytkownicyExists(string id)
        {
            return _context.uzytkownicies.Any(e => e.id == id);
        }
    }
}
