using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace demo2.Models.DataModels
{
    [Table("Publisher")]
    public class Publisher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PublisherId { get; set; }

        [StringLength(200)]
        public string? PublisherName { get; set; }

        [StringLength(30)]
        public string? Phone { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
