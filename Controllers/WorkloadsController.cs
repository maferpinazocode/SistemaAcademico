using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcademicSystem.Data;
using AcademicSystem.Models;

namespace AcademicSystem.Controllers
{
    public class WorkloadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkloadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Workloads
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Workloads.Include(w => w.Course).Include(w => w.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Workloads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workload = await _context.Workloads
                .Include(w => w.Course)
                .Include(w => w.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workload == null)
            {
                return NotFound();
            }

            return View(workload);
        }

        // GET: Workloads/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "FatherSurname");
            return View();
        }

        // POST: Workloads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CourseId,TeacherId,Group,Laboratory,Capacity,Status,Created,Modified")] Workload workload)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workload);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name", workload.CourseId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "FatherSurname", workload.TeacherId);
            return View(workload);
        }

        // GET: Workloads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workload = await _context.Workloads.FindAsync(id);
            if (workload == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name", workload.CourseId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "FatherSurname", workload.TeacherId);
            return View(workload);
        }

        // POST: Workloads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseId,TeacherId,Group,Laboratory,Capacity,Status,Created,Modified")] Workload workload)
        {
            if (id != workload.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workload);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkloadExists(workload.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name", workload.CourseId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "FatherSurname", workload.TeacherId);
            return View(workload);
        }

        // GET: Workloads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workload = await _context.Workloads
                .Include(w => w.Course)
                .Include(w => w.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workload == null)
            {
                return NotFound();
            }

            return View(workload);
        }

        // POST: Workloads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workload = await _context.Workloads.FindAsync(id);
            if (workload != null)
            {
                _context.Workloads.Remove(workload);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkloadExists(int id)
        {
            return _context.Workloads.Any(e => e.Id == id);
        }
    }
}
