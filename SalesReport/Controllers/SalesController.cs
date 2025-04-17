using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesReport.Data;
using SalesReport.Models;
namespace SalesReport.Controllers
{
    [Authorize]
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lead
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalesLeads.ToListAsync());
        }

        // GET: Lead/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SalesLeads == null)
            {
                return NotFound();
            }

            var salesLead = await _context.SalesLeads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesLead == null)
            {
                return NotFound();
            }

            return View(salesLead);
        }

        // GET: Lead/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lead/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Mobile,Email,Source")] SalesLead salesLead)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesLead);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesLead);
        }

        // GET: Lead/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SalesLeads == null)
            {
                return NotFound();
            }

            var salesLead = await _context.SalesLeads.FindAsync(id);
            if (salesLead == null)
            {
                return NotFound();
            }
            return View(salesLead);
        }

        // POST: Lead/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Mobile,Email,Source")] SalesLead salesLead)
        {
            if (id != salesLead.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesLead);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesLeadExists(salesLead.Id))
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
            return View(salesLead);
        }

        // GET: Lead/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SalesLeads == null)
            {
                return NotFound();
            }

            var salesLead = await _context.SalesLeads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesLead == null)
            {
                return NotFound();
            }

            return View(salesLead);
        }

        // POST: Lead/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SalesLeads == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SalesLeads'  is null.");
            }
            var salesLead = await _context.SalesLeads.FindAsync(id);
            if (salesLead != null)
            {
                _context.SalesLeads.Remove(salesLead);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesLeadExists(int id)
        {
            return _context.SalesLeads.Any(e => e.Id == id);
        }
    }
}
