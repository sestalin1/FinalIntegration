using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalIntegracion.Models;
using WS.Models;
using WS;

namespace FinalIntegracion.Controllers
{
    public class SalesTypesController : Controller
    {
        private readonly FinalIntegracionContext _context;

        public SalesTypesController(FinalIntegracionContext context)
        {
            _context = context;
        }

        // GET: SalesTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalesType.ToListAsync());
        }

        // GET: SalesTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesType = await _context.SalesType
                .FirstOrDefaultAsync(m => m.id == id);
            if (salesType == null)
            {
                return NotFound();
            }

            return View(salesType);
        }

        // GET: SalesTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,sales_type,tax_included,factor,inactive")] SalesType salesType)
        {
            if (ModelState.IsValid)
            {
                // _context.Add(salesType);
                //await _context.SaveChangesAsync();
                WebServiceFA ws = new WebServiceFA();
                ws.InsertSalesType(salesType);
                return RedirectToAction(nameof(Index));
            }
            return View(salesType);
        }

        // GET: SalesTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesType = await _context.SalesType.FindAsync(id);
            if (salesType == null)
            {
                return NotFound();
            }
            return View(salesType);
        }

        // POST: SalesTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,sales_type,tax_included,factor,inactive")] SalesType salesType)
        {
            if (id != salesType.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesTypeExists(salesType.id))
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
            return View(salesType);
        }

        // GET: SalesTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesType = await _context.SalesType
                .FirstOrDefaultAsync(m => m.id == id);
            if (salesType == null)
            {
                return NotFound();
            }

            return View(salesType);
        }

        // POST: SalesTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesType = await _context.SalesType.FindAsync(id);
            _context.SalesType.Remove(salesType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesTypeExists(int id)
        {
            return _context.SalesType.Any(e => e.id == id);
        }
    }
}
