#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimeTable_Creator.Data;
using TimeTable_Creator.Models;

namespace TimeTable_Creator.Controllers
{
    public class SlotsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SlotsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Slots
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Slots.Include(s => s.Batch).Include(s => s.Subject).Include(s => s.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Slots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slot = await _context.Slots
                .Include(s => s.Batch)
                .Include(s => s.Subject)
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slot == null)
            {
                return NotFound();
            }

            return View(slot);
        }

        // GET: Slots/Create
        public IActionResult Create()
        {
            ViewData["BatchId"] = new SelectList(_context.Batches, "Id", "Name");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Name");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Name");
            return View();
        }

        // POST: Slots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TimeStamp,Link,Class,StartTime,TimeLength,Day,TeacherId,BatchId,SubjectId")] Slot slot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(slot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BatchId"] = new SelectList(_context.Batches, "Id", "Id", slot.BatchId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id", slot.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Id", slot.TeacherId);
            return View(slot);
        }

        // GET: Slots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slot = await _context.Slots.FindAsync(id);
            if (slot == null)
            {
                return NotFound();
            }
            ViewData["BatchId"] = new SelectList(_context.Batches, "Id", "Id", slot.BatchId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id", slot.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Id", slot.TeacherId);
            return View(slot);
        }

        // POST: Slots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TimeStamp,Link,Class,StartTime,TimeLength,Day,TeacherId,BatchId,SubjectId")] Slot slot)
        {
            if (id != slot.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlotExists(slot.Id))
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
            ViewData["BatchId"] = new SelectList(_context.Batches, "Id", "Id", slot.BatchId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id", slot.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Id", slot.TeacherId);
            return View(slot);
        }

        // GET: Slots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slot = await _context.Slots
                .Include(s => s.Batch)
                .Include(s => s.Subject)
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slot == null)
            {
                return NotFound();
            }

            return View(slot);
        }

        // POST: Slots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slot = await _context.Slots.FindAsync(id);
            _context.Slots.Remove(slot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlotExists(int id)
        {
            return _context.Slots.Any(e => e.Id == id);
        }
    }
}
