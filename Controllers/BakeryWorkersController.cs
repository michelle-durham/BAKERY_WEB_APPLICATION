/*
 * Name: Michelle Ng // 100779006
 * File Name: BakedWorkersController.cs
 * Date : 10 December 2021
 * Description: A controller class for interaction with the workers tab.
 *       
 */

#region USING STATEMENTS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BAKERY_WEB_APPLICATION.Data;
using BAKERY_WEB_APPLICATION.Models;
using Microsoft.AspNetCore.Authorization;
#endregion

namespace BAKERY_WEB_APPLICATION.Controllers
{
    public class BakeryWorkersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BakeryWorkersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BakeryWorkers
        public async Task<IActionResult> Index()
        {
            return View(await _context.BakeryWorkers.ToListAsync());
        }

        // GET: BakeryWorkers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bakeryWorker = await _context.BakeryWorkers
                .FirstOrDefaultAsync(m => m.workerID == id);
            if (bakeryWorker == null)
            {
                return NotFound();
            }

            return View(bakeryWorker);
        }

        // GET: BakeryWorkers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BakeryWorkers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("workerID,workerFirstName,workerLastName,workerRole,workerHourlyWage")] BakeryWorker bakeryWorker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bakeryWorker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bakeryWorker);
        }

        // GET: BakeryWorkers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bakeryWorker = await _context.BakeryWorkers.FindAsync(id);
            if (bakeryWorker == null)
            {
                return NotFound();
            }
            return View(bakeryWorker);
        }

        // POST: BakeryWorkers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("workerID,workerFirstName,workerLastName,workerRole,workerHourlyWage")] BakeryWorker bakeryWorker)
        {
            if (id != bakeryWorker.workerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bakeryWorker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BakeryWorkerExists(bakeryWorker.workerID))
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
            return View(bakeryWorker);
        }

        // GET: BakeryWorkers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bakeryWorker = await _context.BakeryWorkers
                .FirstOrDefaultAsync(m => m.workerID == id);
            if (bakeryWorker == null)
            {
                return NotFound();
            }

            return View(bakeryWorker);
        }

        // POST: BakeryWorkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bakeryWorker = await _context.BakeryWorkers.FindAsync(id);
            _context.BakeryWorkers.Remove(bakeryWorker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BakeryWorkerExists(int id)
        {
            return _context.BakeryWorkers.Any(e => e.workerID == id);
        }
    }
}
