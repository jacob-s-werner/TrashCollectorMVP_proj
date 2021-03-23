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
    [Authorize(Roles = "Employee")]
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            string todaysDayOfTheWeek = DateTime.Today.ToString("dddd");

            List<Employee> currentEmployees = _context.Employees.Where(e => e.IdentityUserId == userId).ToList();
            List<Customer> todaysCustomers = _context.Customers.Include(c => c.WeeklyPickUpDay)
                .Where(c => c.ZipCode.Equals(currentEmployees[0].ZipCode) && c.WeeklyPickUpDay.Day.Equals(todaysDayOfTheWeek)).ToList();

            EmployeeCustomerViewModel ecViewModel = new EmployeeCustomerViewModel
            {
                Employees = currentEmployees,
                Customers = todaysCustomers,
                WeeklyPickupDayId = 1
            };
            
            var applicationDbContext = _context.Employees.Include(e => e.IdentityUser);
            await applicationDbContext.ToListAsync();
            
            ViewData["WeeklyPickUpDayId"] = new SelectList(_context.WeeklyPickupDays, "Id", "Day");
            return View(ecViewModel);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,ZipCode")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.IdentityUserId = userId;
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,ZipCode")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }

        // GET: Customers/SearchPickupsByDay/5
        public async Task<IActionResult> SearchPickupsByDay(int WeeklyPickupDayId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<Employee> currentEmployees = _context.Employees.Where(e => e.IdentityUserId == userId).ToList();
            List<Customer> todaysCustomers = _context.Customers.Include(c => c.WeeklyPickUpDay)
                .Where(c => c.ZipCode.Equals(currentEmployees[0].ZipCode) && c.WeeklyPickUpDay.Id.Equals(WeeklyPickupDayId)).ToList();

            EmployeeCustomerViewModel ecViewModel = new EmployeeCustomerViewModel
            {
                Employees = currentEmployees,
                Customers = todaysCustomers
            };
            
            var applicationDbContext = _context.Employees.Include(e => e.IdentityUser);
            await applicationDbContext.ToListAsync();
            return View(ecViewModel);
        }

    }
}
