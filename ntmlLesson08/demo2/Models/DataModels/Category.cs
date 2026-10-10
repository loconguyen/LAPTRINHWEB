using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demo2.Models.DataModels
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [StringLength(100)]
        public string? CategoryName { get; set; }


        // Navigation Property
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
