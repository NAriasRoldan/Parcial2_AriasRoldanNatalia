using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial2_AriasRoldanNatalia.DAL;
using Parcial2_AriasRoldanNatalia.DAL.Entities;
using Parcial2_AriasRoldanNatalia.Models;

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
                var entrances = await _context.Entrances.ToListAsync();
                if (ticket == null || ticket.IsUsed)
                {
                    return RedirectToAction(nameof(Index), new { exist = true });
                }
                EditViewModel editViewModel = new() { Entrances = entrances, IdTicket = guidValue, createDateTickey = ticket.CreatedDate };
                return View(editViewModel);
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index), new { exist = true });
            }

        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Tickets == null)
            {
                return NotFound();
            }
            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.id == id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid idTicket, EditViewModel editViewModel)
        {
            if (idTicket != editViewModel.IdTicket)
            {
                return NotFound();
            }
            try
            {
                var guidValue = Guid.Parse(editViewModel.selectedEntrance);
                Ticket newTicket = new()
                {
                    id = idTicket,
                    IsUsed = true,
                    EntranceGate = await _context.Entrances.FirstOrDefaultAsync(c => c.id == guidValue),
                    CreatedDate = editViewModel.createDateTickey,
                    ModifiedDate = DateTime.Now,
                    UseDate = DateTime.Now,
                };

                _context.Update(newTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id= idTicket });
            }
            catch (DbUpdateException dbUpdateException)
            {
                ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
            }

            return RedirectToAction(nameof(Index));
        }


        private bool TicketExists(Guid id)
        {
            return (_context.Tickets?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
