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
    public class postiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public postiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: posties
        public async Task<IActionResult> Index(string searchString, string sortOrder)
        {
            ViewBag.sortContent = (String.IsNullOrEmpty(sortOrder) || sortOrder == "content_desc") ? "content_asc" : "content_desc";
            ViewBag.sortDate = (String.IsNullOrEmpty(sortOrder) || sortOrder == "date_desc") ? "date_asc" : "date_desc";
            var posts = from p in _context.posties select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                posts = posts.Where(p => p.tresc.Contains(searchString) || p.getDate(p.data_utworzenia).ToString().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "content_asc":
                    posts = posts.OrderBy(p => p.tresc); break;
                case "content_desc":
                    posts = posts.OrderByDescending(p => p.tresc); break;
                case "date_asc":
                    posts = posts.OrderBy(p => p.data_utworzenia); break;
                case "date_desc":
                    posts = posts.OrderByDescending(p => p.data_utworzenia); break;
                default:
                    posts = posts.OrderByDescending(p => p.data_utworzenia); break;
            }


            return View(posts.ToList());
        }

        // GET: posties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posty = await _context.posties
                .FirstOrDefaultAsync(m => m.id == id);
            if (posty == null)
            {
                return NotFound();
            }

            return View(posty);
        }

        // GET: posties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: posties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,typ,id_uzytkownika,tresc,data_utworzenia,liczba_like,liczba_dislike,status_komentarzy")] posty posty)
        {
            if (ModelState.IsValid)
            {
                posty.typ = 0; //post publiczny
                //posty.id_uzytkownika =  TODO
                //posty.id_uzytkownika = User.
                posty.data_utworzenia = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
                posty.status_komentarzy = 1; //wlaczone
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                posty.id_uzytkownika = userId.ToString();
                _context.Add(posty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(posty);
        }

        // GET: posties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posty = await _context.posties.FindAsync(id);
            if (posty == null)
            {
                return NotFound();
            }
            return View(posty);
        }

        // POST: posties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,typ,id_uzytkownika,tresc,data_utworzenia,liczba_like,liczba_dislike,status_komentarzy")] posty posty)
        {
            if (id != posty.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(posty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!postyExists(posty.id))
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
            return View(posty);
        }

        // GET: posties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posty = await _context.posties
                .FirstOrDefaultAsync(m => m.id == id);
            if (posty == null)
            {
                return NotFound();
            }

            return View(posty);
        }

        // POST: posties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var posty = await _context.posties.FindAsync(id);
            _context.posties.Remove(posty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool postyExists(int id)
        {
            return _context.posties.Any(e => e.id == id);
        }
    }
}
