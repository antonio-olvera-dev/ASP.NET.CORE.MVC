using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NET.CORE.MVC.Data;
using ASP.NET.CORE.MVC.Models;

namespace ASP.NET.CORE.MVC.Controllers
{
    public class SignInController : Controller
    {
        private readonly UsersContext _context;

        public SignInController(UsersContext context)
        {
            _context = context;
        }

        // GET: SignIn
        public async Task<IActionResult> Index()
        {
           
            return View(await _context.SignIn.ToListAsync());
        }

        // GET: SignIn/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signIn = await _context.SignIn
                .FirstOrDefaultAsync(m => m.Id == id);
            if (signIn == null)
            {
                return NotFound();
            }

            return View(signIn);
        }

        // GET: SignIn/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SignIn/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Password")] SignIn signIn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(signIn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(signIn);
        }

        // GET: SignIn/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signIn = await _context.SignIn.FindAsync(id);
            if (signIn == null)
            {
                return NotFound();
            }
            return View(signIn);
        }

        // POST: SignIn/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Password")] SignIn signIn)
        {
            if (id != signIn.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(signIn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SignInExists(signIn.Id))
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
            return View(signIn);
        }

        // GET: SignIn/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signIn = await _context.SignIn
                .FirstOrDefaultAsync(m => m.Id == id);
            if (signIn == null)
            {
                return NotFound();
            }

            return View(signIn);
        }

        // POST: SignIn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var signIn = await _context.SignIn.FindAsync(id);
            _context.SignIn.Remove(signIn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SignInExists(int id)
        {
            return _context.SignIn.Any(e => e.Id == id);
        }
    }
}
