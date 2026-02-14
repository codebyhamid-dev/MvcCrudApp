using System.ComponentModel.DataAnnotations;

namespace MvcCrudApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(100, ErrorMessage = "Category name cannot exceed 100 characters.")]
        
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
