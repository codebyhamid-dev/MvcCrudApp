using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCrudApp.Data;
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
        [HttpGet]
        // GET: ProductController
        public IActionResult Index()
        {
            var products = _context.Products.Include(p => p.Category)
                .Select(p => new ProductViewModel
                {
                    Name = p.Name,
                    Price = p.Price,
                    Category = p.Category.Name
                })
                .ToList();
            return View(products);
        }
    }
}
