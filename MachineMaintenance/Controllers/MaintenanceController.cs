using MachineMaintenance.Data;
using MachineMaintenance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MachineMaintenance.Controllers
{
    public class MaintenanceController : Controller
    {
        private readonly MaintenanceDbContext _context;

        public MaintenanceController(MaintenanceDbContext context)
        {
            _context = context;
        }

        // GET: Maintenance
        public async Task<IActionResult> Index()
        {
            var records = await _context.MaintenanceRecords
                .OrderByDescending(m => m.CreatedDate)
                .ToListAsync();

            // Calculate statistics
            ViewBag.TotalMachines = await _context.MaintenanceRecords
                .Select(m => m.MachineId)
                .Distinct()
                .CountAsync();

            ViewBag.CompletedThisMonth = await _context.MaintenanceRecords
                .Where(m => m.Status == MaintenanceStatus.Completed 
                    && m.CompletionDate.HasValue 
                    && m.CompletionDate.Value.Month == DateTime.Now.Month
                    && m.CompletionDate.Value.Year == DateTime.Now.Year)
                .CountAsync();

            ViewBag.PendingMaintenance = await _context.MaintenanceRecords
                .Where(m => m.Status == MaintenanceStatus.Pending || m.Status == MaintenanceStatus.Scheduled)
                .CountAsync();

            return View(records);
        }

        // GET: Maintenance/Create
        public IActionResult Create()
        {
            var model = new MaintenanceRecord
            {
                ScheduledDate = DateTime.Today
            };
            return View(model);
        }

        // POST: Maintenance/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MachineId,MachineName,MaintenanceType,Priority,ScheduledDate,Technician,EstimatedHours,Status,Description,Notes")] MaintenanceRecord record)
        {
            if (ModelState.IsValid)
            {
                record.CreatedDate = DateTime.Now;
                _context.Add(record);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Maintenance record created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(record);
        }

        // GET: Maintenance/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var record = await _context.MaintenanceRecords.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }
            return View(record);
        }

        // POST: Maintenance/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MachineId,MachineName,MaintenanceType,Priority,ScheduledDate,Technician,EstimatedHours,Status,Description,Notes,ActualHours,CompletionDate,CreatedDate")] MaintenanceRecord record)
        {
            if (id != record.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    record.LastUpdated = DateTime.Now;
                    _context.Update(record);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Maintenance record updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaintenanceRecordExists(record.Id))
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
            return View(record);
        }

        // GET: Maintenance/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var record = await _context.MaintenanceRecords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (record == null)
            {
                return NotFound();
            }

            return View(record);
        }

        // GET: Maintenance/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var record = await _context.MaintenanceRecords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (record == null)
            {
                return NotFound();
            }

            return View(record);
        }

        // POST: Maintenance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var record = await _context.MaintenanceRecords.FindAsync(id);
            if (record != null)
            {
                _context.MaintenanceRecords.Remove(record);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Maintenance record deleted successfully!";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool MaintenanceRecordExists(int id)
        {
            return _context.MaintenanceRecords.Any(e => e.Id == id);
        }
    }
}
