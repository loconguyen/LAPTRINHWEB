using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demo2.Models.DataModels
{
    [Table("Book")]
    public class Book
    {
        [Key]
        [StringLength(10)]
        public string BookId { get; set; } = null!;

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = null!;

        [StringLength(100)]
        public string? Author { get; set; }

        public int? Release { get; set; }

        public double? Price { get; set; }

        [Column(TypeName = "ntext")]
        public string? Description { get; set; }

        [StringLength(100)]
        public string? Picture { get; set; }


        // Foreign Key -> Publisher
        public int? PublisherId { get; set; }

        // Foreign Key -> Category
        public int? CategoryId { get; set; }


        // Navigation Properties
        [ForeignKey("PublisherId")]
        public Publisher? Publisher { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
            = new List<OrderDetail>();
    }
}
