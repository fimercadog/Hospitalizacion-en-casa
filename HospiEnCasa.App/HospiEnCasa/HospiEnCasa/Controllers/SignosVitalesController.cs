using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospiEnCasa.Models;

namespace HospiEnCasa.Controllers
{
    public class SignosVitalesController : Controller
    {
        private readonly HospiEnCasaDataContext _context;

        public SignosVitalesController(HospiEnCasaDataContext context)
        {
            _context = context;
        }

        // GET: SignosVitales
        public async Task<IActionResult> Index()
        {
              return View(await _context.SignosVitales.ToListAsync());
        }

        // GET: SignosVitales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SignosVitales == null)
            {
                return NotFound();
            }

            var signosVitale = await _context.SignosVitales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (signosVitale == null)
            {
                return NotFound();
            }

            return View(signosVitale);
        }

        // GET: SignosVitales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SignosVitales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaHora,TipoSigno")] SignosVitale signosVitale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(signosVitale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(signosVitale);
        }

        // GET: SignosVitales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SignosVitales == null)
            {
                return NotFound();
            }

            var signosVitale = await _context.SignosVitales.FindAsync(id);
            if (signosVitale == null)
            {
                return NotFound();
            }
            return View(signosVitale);
        }

        // POST: SignosVitales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaHora,TipoSigno")] SignosVitale signosVitale)
        {
            if (id != signosVitale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(signosVitale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SignosVitaleExists(signosVitale.Id))
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
            return View(signosVitale);
        }

        // GET: SignosVitales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SignosVitales == null)
            {
                return NotFound();
            }

            var signosVitale = await _context.SignosVitales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (signosVitale == null)
            {
                return NotFound();
            }

            return View(signosVitale);
        }

        // POST: SignosVitales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SignosVitales == null)
            {
                return Problem("Entity set 'HospiEnCasaDataContext.SignosVitales'  is null.");
            }
            var signosVitale = await _context.SignosVitales.FindAsync(id);
            if (signosVitale != null)
            {
                _context.SignosVitales.Remove(signosVitale);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SignosVitaleExists(int id)
        {
          return _context.SignosVitales.Any(e => e.Id == id);
        }
    }
}
