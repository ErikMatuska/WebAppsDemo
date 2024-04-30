using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppsDemo.MVC.Data;
using WebAppsDemo.MVC.Entities;

namespace WebAppsDemo.MVC.Controllers
{
    public class ProductEntitiesController : Controller
    {
        private readonly ProductDbContext _context;

        public ProductEntitiesController(ProductDbContext context)
        {
            _context = context;
        }

        // GET: ProductEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductEntity.ToListAsync());
        }

        // GET: ProductEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productEntity = await _context.ProductEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productEntity == null)
            {
                return NotFound();
            }

            return View(productEntity);
        }

        // GET: ProductEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ProductEntity productEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productEntity);
        }

        // GET: ProductEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productEntity = await _context.ProductEntity.FindAsync(id);
            if (productEntity == null)
            {
                return NotFound();
            }
            return View(productEntity);
        }

        // POST: ProductEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ProductEntity productEntity)
        {
            if (id != productEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductEntityExists(productEntity.Id))
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
            return View(productEntity);
        }

        // GET: ProductEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productEntity = await _context.ProductEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productEntity == null)
            {
                return NotFound();
            }

            return View(productEntity);
        }

        // POST: ProductEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productEntity = await _context.ProductEntity.FindAsync(id);
            if (productEntity != null)
            {
                _context.ProductEntity.Remove(productEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductEntityExists(int id)
        {
            return _context.ProductEntity.Any(e => e.Id == id);
        }
    }
}
