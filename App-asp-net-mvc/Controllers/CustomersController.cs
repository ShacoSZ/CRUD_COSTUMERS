using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App_asp_net_mvc.Data;
using App_asp_net_mvc.Models;

namespace App_asp_net_mvc.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public IActionResult Index()
        {
            IEnumerable<Customers> all_customers = _context.customers;

            return View(all_customers);
        }

        // CREATE: Customers
        public IActionResult Create()
        {
            return View();
        }

        // STORE: Customers
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customers customers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customers);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // EDIT: Customers
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var customer = _context.customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // UPDATE: Customers
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customers customers)
        {
            if (ModelState.IsValid)
            {
                _context.customers.Update(customers);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        // DELETE: Customers
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var aula = _context.customers.Find(id);

            if (aula == null)
            {
                return NotFound();
            }

            return View(aula);
        }

        // DELETE: Customers
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePeriodo(Customers customer)
        {
            if (customer == null)
            {
                return NotFound();
            }

            _context.customers.Remove(customer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

