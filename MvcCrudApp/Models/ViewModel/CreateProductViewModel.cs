using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MvcCrudApp.Models.ViewModel
{
    public class CreateProductViewModel
    {
        [Required]
        public string Name { get; set; }

        [Range(0, 999999)]
        public decimal Price { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public List<SelectListItem> Categories { get; set; } = new();
    }
}
