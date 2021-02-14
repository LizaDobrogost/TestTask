using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Models;

namespace Test.Controllers
{
    public class AreasModelsController : Controller
    {
        private readonly TestDbContext _context;

        public AreasModelsController(TestDbContext context)
        {
            _context = context;
        }

        // GET: AreasModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.AreasModels.ToListAsync());
        }

        // GET: AreasModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areasModel = await _context.AreasModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (areasModel == null)
            {
                return NotFound();
            }

            return View(areasModel);
        }

        // GET: AreasModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AreasModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Comments")] AreasModel areasModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(areasModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(areasModel);
        }

        // GET: AreasModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areasModel = await _context.AreasModels.FindAsync(id);
            if (areasModel == null)
            {
                return NotFound();
            }
            return View(areasModel);
        }

        // POST: AreasModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Comments")] AreasModel areasModel)
        {
            if (id != areasModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(areasModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreasModelExists(areasModel.Id))
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
            return View(areasModel);
        }

        // GET: AreasModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areasModel = await _context.AreasModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (areasModel == null)
            {
                return NotFound();
            }

            return View(areasModel);
        }

        // POST: AreasModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var areasModel = await _context.AreasModels.FindAsync(id);
            _context.AreasModels.Remove(areasModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AreasModelExists(int id)
        {
            return _context.AreasModels.Any(e => e.Id == id);
        }
    }
}
