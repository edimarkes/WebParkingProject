using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebParking.Models;
using WebParking.Models.Domains;

namespace WebParking.Controllers
{
    public class ControleVeiculosController : Controller
    {
        private readonly DatabaseContext _context;

        public ControleVeiculosController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: ControleVeiculos
        public async Task<IActionResult> Index()
        {
              return View(await _context.ControleVeiculo.ToListAsync());
        }

        // GET: ControleVeiculos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ControleVeiculo == null)
            {
                return NotFound();
            }

            var controleVeiculo = await _context.ControleVeiculo
                .FirstOrDefaultAsync(m => m.Condutor == id);
            if (controleVeiculo == null)
            {
                return NotFound();
            }

            return View(controleVeiculo);
        }

        // GET: ControleVeiculos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ControleVeiculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Condutor,Placa,Veiculo,Modelo,Cor,HoraEntrada,HoraSaida,ValorPago")] ControleVeiculo controleVeiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(controleVeiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(controleVeiculo);
        }

        // GET: ControleVeiculos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ControleVeiculo == null)
            {
                return NotFound();
            }

            var controleVeiculo = await _context.ControleVeiculo.FindAsync(id);
            if (controleVeiculo == null)
            {
                return NotFound();
            }
            return View(controleVeiculo);
        }

        // POST: ControleVeiculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Condutor,Placa,Veiculo,Modelo,Cor,HoraEntrada,HoraSaida,ValorPago")] ControleVeiculo controleVeiculo)
        {
            if (id != controleVeiculo.Condutor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(controleVeiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ControleVeiculoExists(controleVeiculo.Condutor))
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
            return View(controleVeiculo);
        }

        // GET: ControleVeiculos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ControleVeiculo == null)
            {
                return NotFound();
            }

            var controleVeiculo = await _context.ControleVeiculo
                .FirstOrDefaultAsync(m => m.Condutor == id);
            if (controleVeiculo == null)
            {
                return NotFound();
            }

            return View(controleVeiculo);
        }

        // POST: ControleVeiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ControleVeiculo == null)
            {
                return Problem("Entity set 'DatabaseContext.ControleVeiculo'  is null.");
            }
            var controleVeiculo = await _context.ControleVeiculo.FindAsync(id);
            if (controleVeiculo != null)
            {
                _context.ControleVeiculo.Remove(controleVeiculo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ControleVeiculoExists(string id)
        {
          return _context.ControleVeiculo.Any(e => e.Condutor == id);
        }
    }
}
