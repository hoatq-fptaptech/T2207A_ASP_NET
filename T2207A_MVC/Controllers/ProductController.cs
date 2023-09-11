using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using T2207A_MVC.Entities;
using T2207A_MVC.Models.Product;
using Microsoft.EntityFrameworkCore;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace T2207A_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Product> products = _context.Products
                .Include(p=>p.category).ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            List<Category> categories = _context.Categories.ToList();
            var selectCategories = new List<SelectListItem>();
            foreach(var c in categories)
            {
                selectCategories.Add(new SelectListItem { Text = c.name, Value = c.id.ToString() });
            }
            ViewBag.categories = selectCategories;
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(new Product {
                    name = model.name,
                    price = model.price,
                    description = model.description,
                    category_id = model.category_id
                    });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            List<Category> categories = _context.Categories.ToList();
            var selectCategories = new List<SelectListItem>();
            foreach (var c in categories)
            {
                selectCategories.Add(new SelectListItem { Text = c.name, Value = c.id.ToString() });
            }
            ViewBag.categories = selectCategories;
            return View();
        }
    }
}

