using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollectorMVP.Data;
using TrashCollectorMVP.Models;

namespace TrashCollectorMVP.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Customers.Include(c => c.IdentityUser).Include(c => c.WeeklyPickUpDay);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.IdentityUser)
                .Include(c => c.WeeklyPickUpDay)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["WeeklyPickUpDayId"] = new SelectList(_context.WeeklyPickupDays, "Id", "Day");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Address,ZipCode,WeeklyPickUpDayId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WeeklyPickUpDayId"] = new SelectList(_context.WeeklyPickupDays, "Id", "Day", customer.WeeklyPickUpDayId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["WeeklyPickUpDayId"] = new SelectList(_context.WeeklyPickupDays, "Id", "Day", customer.WeeklyPickUpDayId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Address,ZipCode,WeeklyPickUpDayId")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    customer.IdentityUserId = userId;
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            ViewData["WeeklyPickUpDayId"] = new SelectList(_context.WeeklyPickupDays, "Id", "Day", customer.WeeklyPickUpDayId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.IdentityUser)
                .Include(c => c.WeeklyPickUpDay)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }

        // GET: Customers/CreateOneTimePickup
        public IActionResult CreateOneTimePickup()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["CustomerId"] = new SelectList(_context.Customers.Where(c => c.IdentityUserId == userId), "Id", "Address");
            return View();
        }

        // POST: Customers/CreateOneTimePickup
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOneTimePickup([Bind("Id, DateForPickup,CustomerId")] OneTimePickup oneTimePickup)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                oneTimePickup.IdentityUserId = userId;
                oneTimePickup.ZipCode = _context.Customers.Where(c => c.Id == oneTimePickup.CustomerId).Select(c => c.ZipCode).SingleOrDefault();
                _context.Add(oneTimePickup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oneTimePickup);
        }

        // GET: Customers/DeleteOneTimePickup/5
        public async Task<IActionResult> DeleteOneTimePickup(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oneTimePickup = await _context.OneTimePickups
                .Include(c => c.IdentityUser)
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oneTimePickup == null)
            {
                return NotFound();
            }

            return View(oneTimePickup);
        }

        // POST: Customers/DeleteOneTimePickup/5
        [HttpPost, ActionName("DeleteOneTimePickup")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOneTimePickupConfirmed(int id)
        {
            var oneTimePickup = await _context.OneTimePickups.FindAsync(id);
            _context.OneTimePickups.Remove(oneTimePickup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OneTimePickupExists(int id)
        {
            return _context.OneTimePickups.Any(e => e.Id == id);
        }
    }
}
