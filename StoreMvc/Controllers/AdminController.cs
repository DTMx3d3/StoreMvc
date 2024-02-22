using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreMvc.Data;
using StoreMvc.Models;
using System;

namespace StoreMvc.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Manage()
        {
            var watches = await _context.Watches.ToListAsync();
            return View(watches);
        }

        public IActionResult Create()
        {
            return View("CreateWatch");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Watch watch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(watch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Manage));
            }
            return View("CreateWatch", watch);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var watch = await _context.Watches.FindAsync(id);
            if (watch == null)
            {
                return NotFound();
            }
            return View("EditWatch", watch);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Watch watch)
        {
            if (id != watch.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(watch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WatchExists(watch.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Manage));
            }
            return View("EditWatch", watch);
        }

        private bool WatchExists(int id)
        {
            return _context.Watches.Any(e => e.id == id);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var watch = await _context.Watches.FindAsync(id);
            if (watch == null)
            {
                return NotFound();
            }

            _context.Watches.Remove(watch);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Manage));
        }

    }
}

