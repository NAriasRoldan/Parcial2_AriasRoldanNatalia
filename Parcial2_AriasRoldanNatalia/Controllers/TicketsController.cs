using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial2_AriasRoldanNatalia.DAL;
using Parcial2_AriasRoldanNatalia.DAL.Entities;

namespace Parcial2_AriasRoldanNatalia.Controllers
{
    public class TicketsController : Controller
    {
        private readonly DataBaseContext _context;

        public TicketsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public IActionResult Index(bool exist = false)
        {
            ViewData["exist"] = exist;
            return View();
        }


        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null || _context.Tickets == null)
            {
                return NotFound();
            }
            try
            {
                var guidValue = Guid.Parse(id);
                var ticket = await _context.Tickets.FindAsync(guidValue);
                if (ticket == null)
                {
                    return RedirectToAction(nameof(Index), new { exist = true });
                }
                return View(ticket);
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index), new { exist = true });
            }

        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Ticket ticket)
        {
            if (id != ticket.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.id))
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
            return View(ticket);
        }

        private bool TicketExists(Guid id)
        {
            return (_context.Tickets?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
