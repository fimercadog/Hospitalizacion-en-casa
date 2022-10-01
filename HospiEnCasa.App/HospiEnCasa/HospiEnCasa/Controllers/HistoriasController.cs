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
    public class HistoriasController : Controller
    {
        private readonly HospiEnCasaDataContext _context;

        public HistoriasController(HospiEnCasaDataContext context)
        {
            _context = context;
        }

        // GET: Historias
        public async Task<IActionResult> Index()
        {
              return View(await _context.Historias.ToListAsync());
        }

        // GET: Historias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Historias == null)
            {
                return NotFound();
            }

            var historia = await _context.Historias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historia == null)
            {
                return NotFound();
            }

            return View(historia);
        }

        // GET: Historias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Historias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Diagnostico,Entorno")] Historia historia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(historia);
        }

        // GET: Historias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Historias == null)
            {
                return NotFound();
            }

            var historia = await _context.Historias.FindAsync(id);
            if (historia == null)
            {
                return NotFound();
            }
            return View(historia);
        }

        // POST: Historias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Diagnostico,Entorno")] Historia historia)
        {
            if (id != historia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoriaExists(historia.Id))
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
            return View(historia);
        }

        // GET: Historias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Historias == null)
            {
                return NotFound();
            }

            var historia = await _context.Historias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historia == null)
            {
                return NotFound();
            }

            return View(historia);
        }

        // POST: Historias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Historias == null)
            {
                return Problem("Entity set 'HospiEnCasaDataContext.Historias'  is null.");
            }
            var historia = await _context.Historias.FindAsync(id);
            if (historia != null)
            {
                _context.Historias.Remove(historia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoriaExists(int id)
        {
          return _context.Historias.Any(e => e.Id == id);
        }
    }
}
