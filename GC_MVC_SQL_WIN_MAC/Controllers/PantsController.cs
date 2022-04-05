﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GC_MVC_SQL_WIN_MAC.Data;
using GC_MVC_SQL_WIN_MAC.Models;

namespace GC_MVC_SQL_WIN_MAC.Controllers
{
    public class PantsController : Controller
    {
        private readonly PantsContext _context;

        public PantsController(PantsContext context)
        {
            _context = context;
        }

        // GET: Pants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pants.ToListAsync());
        }

        // GET: Pants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pants = await _context.Pants
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pants == null)
            {
                return NotFound();
            }

            return View(pants);
        }

        // GET: Pants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Length,Waist,Size,Brand,ProductName,Color,Price,IsOnSale")] Pants pants)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pants);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pants);
        }

        // GET: Pants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pants = await _context.Pants.FindAsync(id);
            if (pants == null)
            {
                return NotFound();
            }
            return View(pants);
        }

        // POST: Pants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Length,Waist,Size,Brand,ProductName,Color,Price,IsOnSale")] Pants pants)
        {
            if (id != pants.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pants);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PantsExists(pants.ID))
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
            return View(pants);
        }

        // GET: Pants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pants = await _context.Pants
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pants == null)
            {
                return NotFound();
            }

            return View(pants);
        }

        // POST: Pants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pants = await _context.Pants.FindAsync(id);
            _context.Pants.Remove(pants);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PantsExists(int id)
        {
            return _context.Pants.Any(e => e.ID == id);
        }
    }
}
