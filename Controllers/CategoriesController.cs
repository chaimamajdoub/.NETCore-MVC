using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP11Core.Models;

namespace TP11Core.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            this._context = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var categories = await _context.categorie.Include(c => c.SousCategories).ToListAsync();
            return View(categories);

            //return _context.categorie != null ? 
                      //    View(await _context.categorie.ToListAsync()) :
                       //   Problem("Entity set 'ApplicationDbContext.categorie'  is null.");
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.categorie == null)
            {
                return NotFound();
            }

            var categorie = await _context.categorie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Categorie categorie)
        {
            var Categories = new Categorie
            {
                Name = categorie.Name,
            };
           
                await _context.categorie.AddAsync(categorie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            return View(categorie);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.categorie == null)
            {
                return NotFound();
            }

            var categorie = await _context.categorie.FindAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }
            return View(categorie);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Categorie categorie)
        {
            var Categorie = await _context.categorie.FindAsync(id);
            if (categorie is not null)
            {
                categorie.Name = categorie.Name;
                await _context.SaveChangesAsync();

            }
            return RedirectToAction(nameof(Index));

        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.categorie == null)
            {
                return NotFound();
            }

            var categorie = await _context.categorie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.categorie == null)
            {
                return Problem("Entity set 'ApplicationDbContext.categorie'  is null.");
            }
            var categorie = await _context.categorie.FindAsync(id);
            if (categorie != null)
            {
                _context.categorie.Remove(categorie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategorieExists(int id)
        {
          return (_context.categorie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
