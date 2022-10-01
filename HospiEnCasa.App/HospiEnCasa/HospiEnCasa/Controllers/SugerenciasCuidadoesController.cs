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
    public class SugerenciasCuidadoesController : Controller
    {
        private readonly HospiEnCasaDataContext _context;

        public SugerenciasCuidadoesController(HospiEnCasaDataContext context)
        {
            _context = context;
        }

        // GET: SugerenciasCuidadoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.SugerenciasCuidados.ToListAsync());
        }

        // GET: SugerenciasCuidadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SugerenciasCuidados == null)
            {
                return NotFound();
            }

            var sugerenciasCuidado = await _context.SugerenciasCuidados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sugerenciasCuidado == null)
            {
                return NotFound();
            }

            return View(sugerenciasCuidado);
        }

        // GET: SugerenciasCuidadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SugerenciasCuidadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaHora,Descripcion")] SugerenciasCuidado sugerenciasCuidado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sugerenciasCuidado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sugerenciasCuidado);
        }

        // GET: SugerenciasCuidadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SugerenciasCuidados == null)
            {
                return NotFound();
            }

            var sugerenciasCuidado = await _context.SugerenciasCuidados.FindAsync(id);
            if (sugerenciasCuidado == null)
            {
                return NotFound();
            }
            return View(sugerenciasCuidado);
        }

        // POST: SugerenciasCuidadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaHora,Descripcion")] SugerenciasCuidado sugerenciasCuidado)
        {
            if (id != sugerenciasCuidado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sugerenciasCuidado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SugerenciasCuidadoExists(sugerenciasCuidado.Id))
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
            return View(sugerenciasCuidado);
        }

        // GET: SugerenciasCuidadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SugerenciasCuidados == null)
            {
                return NotFound();
            }

            var sugerenciasCuidado = await _context.SugerenciasCuidados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sugerenciasCuidado == null)
            {
                return NotFound();
            }

            return View(sugerenciasCuidado);
        }

        // POST: SugerenciasCuidadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SugerenciasCuidados == null)
            {
                return Problem("Entity set 'HospiEnCasaDataContext.SugerenciasCuidados'  is null.");
            }
            var sugerenciasCuidado = await _context.SugerenciasCuidados.FindAsync(id);
            if (sugerenciasCuidado != null)
            {
                _context.SugerenciasCuidados.Remove(sugerenciasCuidado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SugerenciasCuidadoExists(int id)
        {
          return _context.SugerenciasCuidados.Any(e => e.Id == id);
        }
    }
}
