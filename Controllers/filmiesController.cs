using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication19.Data;
using WebApplication19.Models;

namespace WebApplication19.Controllers
{
    public class filmiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHostingEnvironment he;

        public filmiesController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IHostingEnvironment e)
        {
            _context = context;
            _userManager = userManager;
            he = e;
        }

        // GET: filmies
        public async Task<IActionResult> Index()
        {
            return View(await _context.filmies.ToListAsync());
        }

        // GET: filmies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmy = await _context.filmies
                .FirstOrDefaultAsync(m => m.id_filmy == id);
            if (filmy == null)
            {
                return NotFound();
            }

            return View(filmy);
        }

        // GET: filmies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: filmies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_filmy,nazwa,id_uzytkownicy,link_bezposredni")] filmy filmy, IFormFile file)
        {
            if (file == null)
            {
                ViewBag.String = "Brak wybranego pliku!";
                return View("~/Views/zdjecias/Erroe.cshtml");
            }
            if ((file.Length / 1048576.0) > 5) //rozmiar wiekszy niż 5 mb
            {
                ViewBag.String = "Plik za duży!";
                return View("~/Views/zdjecias/Erroe.cshtml");
            }

            string extension = Path.GetExtension(file.FileName);
            if ((extension == ".mp4") || (extension == ".avi"))
            {

                var filename = Path.Combine(he.WebRootPath, Path.GetFileName(file.FileName));

                using (var stream = new FileStream(filename, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }




                if (ModelState.IsValid)
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    filmy.id_uzytkownicy = userId.ToString();
                    filmy.link_bezposredni = "/" + file.FileName;
                    _context.Add(filmy);

                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index", "posties");
                }

                return View(filmy);

            }
            ViewBag.String = "Błędny typ pliku!";
            return View("~/Views/zdjecias/Erroe.cshtml");
        }

        // GET: filmies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmy = await _context.filmies.FindAsync(id);
            if (filmy == null)
            {
                return NotFound();
            }
            return View(filmy);
        }

        // POST: filmies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_filmy,nazwa,id_uzytkownicy,link_bezposredni")] filmy filmy)
        {
            if (id != filmy.id_filmy)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!filmyExists(filmy.id_filmy))
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
            return View(filmy);
        }

        // GET: filmies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmy = await _context.filmies
                .FirstOrDefaultAsync(m => m.id_filmy == id);
            if (filmy == null)
            {
                return NotFound();
            }

            return View(filmy);
        }

        // POST: filmies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filmy = await _context.filmies.FindAsync(id);
            _context.filmies.Remove(filmy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool filmyExists(int id)
        {
            return _context.filmies.Any(e => e.id_filmy == id);
        }
    }
}
