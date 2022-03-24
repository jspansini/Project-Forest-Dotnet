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
    public class CadastrarPassagemsController : Controller
    {
        private readonly Context _context;

        public CadastrarPassagemsController(Context context)
        {
            _context = context;
        }

        // GET: CadastrarPassagems
        public async Task<IActionResult> Index()
        {
            return View(await _context.CadastrarPassagem.ToListAsync());
        }

        // GET: CadastrarPassagems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastrarPassagem = await _context.CadastrarPassagem
                .FirstOrDefaultAsync(m => m.IdPassagem == id);
            if (cadastrarPassagem == null)
            {
                return NotFound();
            }

            return View(cadastrarPassagem);
        }

        // GET: CadastrarPassagems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastrarPassagems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPassagem,DestinoPassagem,ValorPassagem")] CadastrarPassagem cadastrarPassagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastrarPassagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastrarPassagem);
        }

        // GET: CadastrarPassagems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastrarPassagem = await _context.CadastrarPassagem.FindAsync(id);
            if (cadastrarPassagem == null)
            {
                return NotFound();
            }
            return View(cadastrarPassagem);
        }

        // POST: CadastrarPassagems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPassagem,DestinoPassagem,ValorPassagem")] CadastrarPassagem cadastrarPassagem)
        {
            if (id != cadastrarPassagem.IdPassagem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastrarPassagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastrarPassagemExists(cadastrarPassagem.IdPassagem))
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
            return View(cadastrarPassagem);
        }

        // GET: CadastrarPassagems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastrarPassagem = await _context.CadastrarPassagem
                .FirstOrDefaultAsync(m => m.IdPassagem == id);
            if (cadastrarPassagem == null)
            {
                return NotFound();
            }

            return View(cadastrarPassagem);
        }

        // POST: CadastrarPassagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastrarPassagem = await _context.CadastrarPassagem.FindAsync(id);
            _context.CadastrarPassagem.Remove(cadastrarPassagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastrarPassagemExists(int id)
        {
            return _context.CadastrarPassagem.Any(e => e.IdPassagem == id);
        }
    }
}
