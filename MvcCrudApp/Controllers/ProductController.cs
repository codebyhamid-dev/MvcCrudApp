using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcCrudApp.Data;
using MvcCrudApp.Models;
using MvcCrudApp.Models.ViewModel;

namespace MvcCrudApp.Controllers
{
    public class ProductController : Controller
    {
        protected readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ INDEX
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Category = p.Category.Name
                })
                .ToListAsync();

            return View(products);
        }

        // ✅ CREATE (GET)
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var vm = new CreateProductViewModel();

            vm.Categories = await _context.Categories
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToListAsync();

            return View(vm);
        }

        // ✅ CREATE (POST)
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Categories = await _context.Categories
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    })
                    .ToListAsync();

                return View(vm);
            }

            var product = new Product
            {
                Name = vm.Name,
                Price = vm.Price,
                CategoryId = vm.CategoryId
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // ✅ EDIT (GET)
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return NotFound();

            var vm = new CreateProductViewModel
            {
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,

                Categories = await _context.Categories
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    })
                    .ToListAsync()
            };

            return View(vm);
        }

        // ✅ EDIT (POST)
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CreateProductViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Categories = await _context.Categories
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    })
                    .ToListAsync();

                return View(vm);
            }

            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound();

            product.Name = vm.Name;
            product.Price = vm.Price;
            product.CategoryId = vm.CategoryId;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // ✅ DELETE (POST)
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
