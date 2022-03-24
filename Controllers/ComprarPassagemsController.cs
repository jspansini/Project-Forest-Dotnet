#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgenciaForest.Models;

namespace AgenciaForest.Controllers
{
    public class ComprarPassagemsController : Controller
    {
        private readonly Context _context;

        public ComprarPassagemsController(Context context)
        {
            _context = context;
        }

        // GET: ComprarPassagems
        public async Task<IActionResult> Index()
        {
            var context = _context.ComprarPassagem.Include(c => c.CadastrarPassagem);
            return View(await context.ToListAsync());
        }

        // GET: ComprarPassagems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprarPassagem = await _context.ComprarPassagem
                .Include(c => c.CadastrarPassagem)
                .FirstOrDefaultAsync(m => m.IdPassagem == id);
            if (comprarPassagem == null)
            {
                return NotFound();
            }

            return View(comprarPassagem);
        }

        // GET: ComprarPassagems/Create
        public IActionResult Create()
        {
            ViewData["cadastrarPassagem"] = new SelectList(_context.CadastrarPassagem, "IdPassagem", "DestinoPassagem");
            return View();
        }

        // POST: ComprarPassagems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPassagem,DestinoPassagem,ValorPassagem,cadastrarPassagem")] ComprarPassagem comprarPassagem)
        {

            _context.Add(comprarPassagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            ViewData["cadastrarPassagem"] = new SelectList(_context.CadastrarPassagem, "IdPassagem", "DestinoPassagem", comprarPassagem.cadastrarPassagem);
        }

        // GET: ComprarPassagems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprarPassagem = await _context.ComprarPassagem.FindAsync(id);
            if (comprarPassagem == null)
            {
                return NotFound();
            }
            ViewData["cadastrarPassagem"] = new SelectList(_context.CadastrarPassagem, "IdPassagem", "DestinoPassagem", comprarPassagem.cadastrarPassagem);
            return View(comprarPassagem);
        }

        // POST: ComprarPassagems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPassagem,DestinoPassagem,ValorPassagem,cadastrarPassagem")] ComprarPassagem comprarPassagem)
        {
            if (id != comprarPassagem.IdPassagem)
            {
                return NotFound();
            }

           
                try
                {
                    _context.Update(comprarPassagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComprarPassagemExists(comprarPassagem.IdPassagem))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["cadastrarPassagem"] = new SelectList(_context.CadastrarPassagem, "IdPassagem", "DestinoPassagem", comprarPassagem.cadastrarPassagem);
            return View(comprarPassagem);
        }

        // GET: ComprarPassagems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprarPassagem = await _context.ComprarPassagem
                .Include(c => c.CadastrarPassagem)
                .FirstOrDefaultAsync(m => m.IdPassagem == id);
            if (comprarPassagem == null)
            {
                return NotFound();
            }

            return View(comprarPassagem);
        }

        // POST: ComprarPassagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comprarPassagem = await _context.ComprarPassagem.FindAsync(id);
            _context.ComprarPassagem.Remove(comprarPassagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComprarPassagemExists(int id)
        {
            return _context.ComprarPassagem.Any(e => e.IdPassagem == id);
        }
    }
}
