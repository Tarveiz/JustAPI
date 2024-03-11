using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CRUD.Controllers
{
    public class CustomerController(ApplicationDbContext db) : Controller
    {
        private readonly ApplicationDbContext _db = db;

        public IActionResult Index()
        {
            List<Customer> customers = _db.Customers.ToList();
            return View(customers);
        }
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (_db.Customers.Any(x => x.Email!.Equals(customer.Email)))
            {
                ModelState.AddModelError("email","Такой электронный адрес уже используется");
            };

            
            if(ModelState.IsValid)
            {
                _db.Customers.Add(customer);
                _db.SaveChanges();
                TempData["Success"] = "Пользователь успешно создан";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            Customer? customer = _db.Customers.Find(id);
            if (customer == null || id == 0 || id == null) {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (_db.Customers.Any(x => x.Email!.Equals(customer.Email) && x.Id != customer.Id))
            {
                ModelState.AddModelError("email","Такой электронный адрес уже используется");
            };

            
            if(ModelState.IsValid)
            {
                _db.Customers.Update(customer);
                _db.SaveChanges();
                TempData["Success"] = "Пользователь успешно изменен";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            Customer? customer = _db.Customers.Find(id);
            if (customer == null || id == 0 || id == null)
            {
                return NotFound();
            }

            _db.Customers.Remove(customer);
            _db.SaveChanges();
            TempData["Success"] = "Пользователь успешно удален";
            return RedirectToAction("Index");
        }

    }
}
