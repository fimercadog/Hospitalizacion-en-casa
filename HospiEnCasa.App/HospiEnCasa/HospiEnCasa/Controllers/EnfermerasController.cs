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
    public class EnfermerasController : Controller
    {
        private readonly HospiEnCasaDataContext _context;

        public EnfermerasController(HospiEnCasaDataContext context)
        {
            _context = context;
        }

        // GET: Enfermeras
        public async Task<IActionResult> Index()
        {
              return View(await _context.Enfermeras.ToListAsync());
        }

        // GET: Enfermeras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Enfermeras == null)
            {
                return NotFound();
            }

            var enfermera = await _context.Enfermeras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enfermera == null)
            {
                return NotFound();
            }

            return View(enfermera);
        }

        // GET: Enfermeras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enfermeras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TarjetaProfesional,HorasLaboradas,Nombre,Apellidos,NumeroTelefono,Genero")] Enfermera enfermera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enfermera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enfermera);
        }

        // GET: Enfermeras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Enfermeras == null)
            {
                return NotFound();
            }

            var enfermera = await _context.Enfermeras.FindAsync(id);
            if (enfermera == null)
            {
                return NotFound();
            }
            return View(enfermera);
        }

        // POST: Enfermeras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TarjetaProfesional,HorasLaboradas,Nombre,Apellidos,NumeroTelefono,Genero")] Enfermera enfermera)
        {
            if (id != enfermera.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enfermera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnfermeraExists(enfermera.Id))
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
            return View(enfermera);
        }

        // GET: Enfermeras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Enfermeras == null)
            {
                return NotFound();
            }

            var enfermera = await _context.Enfermeras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enfermera == null)
            {
                return NotFound();
            }

            return View(enfermera);
        }

        // POST: Enfermeras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Enfermeras == null)
            {
                return Problem("Entity set 'HospiEnCasaDataContext.Enfermeras'  is null.");
            }
            var enfermera = await _context.Enfermeras.FindAsync(id);
            if (enfermera != null)
            {
                _context.Enfermeras.Remove(enfermera);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnfermeraExists(int id)
        {
          return _context.Enfermeras.Any(e => e.Id == id);
        }
    }
}
