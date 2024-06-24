using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCRUD.Models;

namespace MVCCRUD.Controllers
{
    public class AprendicesController : Controller
    {
        private readonly MvccrudContext _context;

        public AprendicesController(MvccrudContext context)
        {
            _context = context;
        }

        // GET: Aprendices
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aprendices.ToListAsync());
        }

        // GET: Aprendices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aprendix = await _context.Aprendices
                .FirstOrDefaultAsync(m => m.IDaprendiz == id);
            if (aprendix == null)
            {
                return NotFound();
            }

            return View(aprendix);
        }

        // GET: Aprendices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aprendices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDaprendiz,NombreAprendiz,ApellidoAprendiz")] Aprendix aprendix)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aprendix);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aprendix);
        }

        // GET: Aprendices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aprendix = await _context.Aprendices.FindAsync(id);
            if (aprendix == null)
            {
                return NotFound();
            }
            return View(aprendix);
        }

        // POST: Aprendices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDaprendiz,NombreAprendiz,ApellidoAprendiz")] Aprendix aprendix)
        {
            if (id != aprendix.IDaprendiz)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aprendix);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AprendixExists(aprendix.IDaprendiz))
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
            return View(aprendix);
        }

        // GET: Aprendices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aprendix = await _context.Aprendices
                .FirstOrDefaultAsync(m => m.IDaprendiz == id);
            if (aprendix == null)
            {
                return NotFound();
            }

            return View(aprendix);
        }

        // POST: Aprendices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aprendix = await _context.Aprendices.FindAsync(id);
            if (aprendix != null)
            {
                _context.Aprendices.Remove(aprendix);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AprendixExists(int id)
        {
            return _context.Aprendices.Any(e => e.IDaprendiz == id);
        }
    }
}
