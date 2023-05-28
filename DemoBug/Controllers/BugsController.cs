using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoBug.Data;
using DemoBug.Models;
using Nancy.Json;
using Humanizer;
using Syncfusion.EJ2.Notifications;

namespace DemoBug.Controllers
{
    public class BugsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BugsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            

            var groupedData = await _context.Bugs
                .GroupBy(bug => bug.severity)
                .Select(group => new Bug
                {
                    severity = group.Key,
                    Count = group.Count()
                })
                .ToListAsync();

            ViewBag.dataSource = groupedData;

            var applicationDbContext = _context.Bugs.Include(b => b.AssignedUser);
            return View(await applicationDbContext.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bugs == null)
            {
                return NotFound();
            }

            var bug = await _context.Bugs
                .Include(b => b.AssignedUser)
                .FirstOrDefaultAsync(m => m.BugId == id);
            if (bug == null)
            {
                return NotFound();
            }

            return View(bug);
        }

        public IActionResult Create()
        {
            ViewData["AssignedUserId"] = new SelectList(_context.Users, "UserId", "Username");
            return View(new Bug());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BugId,Title,Description, severity, AssignedUserId")] Bug bug)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bug);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["AssignedUserId"] = new SelectList(_context.Users, "UserId", "UserId", bug.AssignedUserId);
            return View(bug);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bugs == null)
            {
                return NotFound();
            }

            var bug = await _context.Bugs.FindAsync(id);
            if (bug == null)
            {
                return NotFound();
            }
            ViewData["AssignedUserId"] = new SelectList(_context.Users, "UserId", "UserId", bug.AssignedUserId);
            return View(bug);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BugId,Title,Description, severity, AssignedUserId")] Bug bug)
        {
            if (id != bug.BugId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bug);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BugExists(bug.BugId))
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
            ViewData["AssignedUserId"] = new SelectList(_context.Users, "UserId", "UserId", bug.AssignedUserId);
            return View(bug);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bugs == null)
            {
                return NotFound();
            }

            var bug = await _context.Bugs
                .Include(b => b.AssignedUser)
                .FirstOrDefaultAsync(m => m.BugId == id);
            if (bug == null)
            {
                return NotFound();
            }

            return View(bug);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bugs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Bugs'  is null.");
            }
            var bug = await _context.Bugs.FindAsync(id);
            if (bug != null)
            {
                _context.Bugs.Remove(bug);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BugExists(int id)
        {
          return (_context.Bugs?.Any(e => e.BugId == id)).GetValueOrDefault();
        }


    }
    

    

}
