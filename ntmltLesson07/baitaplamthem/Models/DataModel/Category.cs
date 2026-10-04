using System.ComponentModel.DataAnnotations;

namespace baitaplamthem.Models.DataModel
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        // 1 category co nhieu san pham -> category.products: nhung san pham trong category day
        public ICollection<Product> Products { get; set; }
            = new List<Product>();


    }
}
