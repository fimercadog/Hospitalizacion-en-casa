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
    public class FamiliaresDesignadoesController : Controller
    {
        private readonly HospiEnCasaDataContext _context;

        public FamiliaresDesignadoesController(HospiEnCasaDataContext context)
        {
            _context = context;
        }

        // GET: FamiliaresDesignadoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.FamiliaresDesignados.ToListAsync());
        }

        // GET: FamiliaresDesignadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FamiliaresDesignados == null)
            {
                return NotFound();
            }

            var familiaresDesignado = await _context.FamiliaresDesignados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (familiaresDesignado == null)
            {
                return NotFound();
            }

            return View(familiaresDesignado);
        }

        // GET: FamiliaresDesignadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FamiliaresDesignadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Parentesco,Correo,Nombre,Apellidos,NumeroTelefono,Genero")] FamiliaresDesignado familiaresDesignado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(familiaresDesignado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(familiaresDesignado);
        }

        // GET: FamiliaresDesignadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FamiliaresDesignados == null)
            {
                return NotFound();
            }

            var familiaresDesignado = await _context.FamiliaresDesignados.FindAsync(id);
            if (familiaresDesignado == null)
            {
                return NotFound();
            }
            return View(familiaresDesignado);
        }

        // POST: FamiliaresDesignadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Parentesco,Correo,Nombre,Apellidos,NumeroTelefono,Genero")] FamiliaresDesignado familiaresDesignado)
        {
            if (id != familiaresDesignado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(familiaresDesignado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamiliaresDesignadoExists(familiaresDesignado.Id))
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
            return View(familiaresDesignado);
        }

        // GET: FamiliaresDesignadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FamiliaresDesignados == null)
            {
                return NotFound();
            }

            var familiaresDesignado = await _context.FamiliaresDesignados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (familiaresDesignado == null)
            {
                return NotFound();
            }

            return View(familiaresDesignado);
        }

        // POST: FamiliaresDesignadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FamiliaresDesignados == null)
            {
                return Problem("Entity set 'HospiEnCasaDataContext.FamiliaresDesignados'  is null.");
            }
            var familiaresDesignado = await _context.FamiliaresDesignados.FindAsync(id);
            if (familiaresDesignado != null)
            {
                _context.FamiliaresDesignados.Remove(familiaresDesignado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FamiliaresDesignadoExists(int id)
        {
          return _context.FamiliaresDesignados.Any(e => e.Id == id);
        }
    }
}
