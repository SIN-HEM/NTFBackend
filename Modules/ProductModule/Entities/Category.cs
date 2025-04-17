using System.ComponentModel.DataAnnotations;

namespace NIFTWebApp.Modules.ProductModule.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        // Optional: Image or Icon
        public string IconUrl { get; set; }

        // Hierarchy support
        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }

        public ICollection<Category> SubCategories { get; set; } = new List<Category>();

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }

}
