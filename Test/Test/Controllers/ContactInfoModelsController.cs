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
    public class ContactInfoModelsController : Controller
    {
        private readonly TestDbContext _context;

        public ContactInfoModelsController(TestDbContext context)
        {
            _context = context;
        }

        // GET: ContactInfoModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactInfoModels.ToListAsync());
        }

        // GET: ContactInfoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactInfoModel = await _context.ContactInfoModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactInfoModel == null)
            {
                return NotFound();
            }

            return View(contactInfoModel);
        }

        // GET: ContactInfoModels/Create
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        // POST: ContactInfoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,MiddleName,LastName,Company,Title,Email,Phone,Fax,Mobile")] ContactInfoModel contactInfoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactInfoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactInfoModel);
        }

        // GET: ContactInfoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactInfoModel = await _context.ContactInfoModels.FindAsync(id);
            if (contactInfoModel == null)
            {
                return NotFound();
            }
            return View(contactInfoModel);
        }

        // POST: ContactInfoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,MiddleName,LastName,Company,Title,Email,Phone,Fax,Mobile")] ContactInfoModel contactInfoModel)
        {
            if (id != contactInfoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactInfoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactInfoModelExists(contactInfoModel.Id))
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
            return View(contactInfoModel);
        }

        // GET: ContactInfoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactInfoModel = await _context.ContactInfoModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactInfoModel == null)
            {
                return NotFound();
            }

            return View(contactInfoModel);
        }

        // POST: ContactInfoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactInfoModel = await _context.ContactInfoModels.FindAsync(id);
            _context.ContactInfoModels.Remove(contactInfoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactInfoModelExists(int id)
        {
            return _context.ContactInfoModels.Any(e => e.Id == id);
        }
    }
}
