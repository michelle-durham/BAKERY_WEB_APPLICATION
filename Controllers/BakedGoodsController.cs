/*
 * Name: Michelle Ng // 100779006
 * File Name: BakedGoodsController.cs
 * Date : 10 December 2021
 * Description: A controller class for interaction with the baked goods tab.
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
    public class BakedGoodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BakedGoodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BakedGoods
        public async Task<IActionResult> Index()
        {
            return View(await _context.BakedGoods.ToListAsync());
        }

        // GET: BakedGoods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bakedGood = await _context.BakedGoods
                .FirstOrDefaultAsync(m => m.bakedGoodID == id);
            if (bakedGood == null)
            {
                return NotFound();
            }

            return View(bakedGood);
        }

        // GET: BakedGoods/Create
        [Authorize] // Can't create new object unless you are logged-in.
        public IActionResult Create()
        {
            return View();
        }

        // POST: BakedGoods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("bakedGoodID,bakedGoodName,typeOfPastry,pricePerUnit,availableOrNot")] BakedGood bakedGood)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bakedGood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bakedGood);
        }

        // GET: BakedGoods/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bakedGood = await _context.BakedGoods.FindAsync(id);
            if (bakedGood == null)
            {
                return NotFound();
            }
            return View(bakedGood);
        }

        // POST: BakedGoods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("bakedGoodID,bakedGoodName,typeOfPastry,pricePerUnit,availableOrNot")] BakedGood bakedGood)
        {
            if (id != bakedGood.bakedGoodID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bakedGood);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BakedGoodExists(bakedGood.bakedGoodID))
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
            return View(bakedGood);
        }

        // GET: BakedGoods/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bakedGood = await _context.BakedGoods
                .FirstOrDefaultAsync(m => m.bakedGoodID == id);
            if (bakedGood == null)
            {
                return NotFound();
            }

            return View(bakedGood);
        }

        // POST: BakedGoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bakedGood = await _context.BakedGoods.FindAsync(id);
            _context.BakedGoods.Remove(bakedGood);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BakedGoodExists(int id)
        {
            return _context.BakedGoods.Any(e => e.bakedGoodID == id);
        }

        // GET: Search bar.
        public async Task<IActionResult> Searching()
        {
            return View();
        }

        public async Task<IActionResult> SearchByPastry(string SearchByPastryType)
        {
            return View("Index", await _context.BakedGoods.Where(s => s.typeOfPastry.Contains(SearchByPastryType)).ToListAsync());
        }

    }
}
