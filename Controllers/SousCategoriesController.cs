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
    public class SousCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SousCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SousCategories
        public async Task<IActionResult> Index()
        {
            var souscategories = _context.souscategories.Include(c=>c.Categorie).ToList();
            return View(souscategories);
        }

        // GET: SousCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.souscategories == null)
            {
                return NotFound();
            }

            var sousCategorie = await _context.souscategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sousCategorie == null)
            {
                return NotFound();
            }

            return View(sousCategorie);
        }

        // GET: SousCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SousCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int categorieId,[Bind("Id,Name")] SousCategorie sousCategorie)
        {
            if(!ModelState.IsValid)
            {
                // Log ModelState errors
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { Message = "Invalid data.", Errors = errors });
            }

            var category = await _context.categorie.FindAsync(categorieId);
            if (category == null)
          {
                return NotFound("Category not found.");
           }

            var newSousCategorie = new SousCategorie
            {
                Name = sousCategorie.Name,
                CategorieId = categorieId,
                Categorie = category
            };

            _context.souscategories.Add(newSousCategorie);
            await _context.SaveChangesAsync();

            return Ok("SousCategorie created successfully.");
        }

        // GET: SousCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.souscategories == null)
            {
                return NotFound();
            }

            var newSousCategorie = await _context.souscategories.FindAsync(id);
            if (newSousCategorie == null)
            {
                return NotFound();
            }
            return View(newSousCategorie);
        }

        // POST: SousCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] SousCategorie sousCategorie)
        {
            if (id != sousCategorie.Id)
            {
                return BadRequest("Invalid SousCategorie ID.");
            }

            var existingSousCategorie = await _context.souscategories.FindAsync(id);
            if (existingSousCategorie == null)
            {
                return NotFound("SousCategorie not found.");
            }

            var category = await _context.categorie.FindAsync(sousCategorie.CategorieId);
            if (category == null)
            {
                return NotFound("Category not found.");
            }
            existingSousCategorie.Name = sousCategorie.Name;
            existingSousCategorie.CategorieId = sousCategorie.CategorieId;
             existingSousCategorie.Categorie = category;

            await _context.SaveChangesAsync();
            return Ok("SousCategorie updated successfully.");


            return View(existingSousCategorie);
         
        }

        // GET: SousCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.souscategories == null)
            {
                return NotFound();
            }

            var sousCategorie = await _context.souscategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sousCategorie == null)
            {
                return NotFound();
            }

            return View(sousCategorie);
        }

        // POST: SousCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.souscategories == null)
            {
                return Problem("Entity set 'ApplicationDbContext.souscategories'  is null.");
            }
            var sousCategorie = await _context.souscategories.FindAsync(id);
            if (sousCategorie != null)
            {
                _context.souscategories.Remove(sousCategorie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SousCategorieExists(int id)
        {
          return (_context.souscategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
