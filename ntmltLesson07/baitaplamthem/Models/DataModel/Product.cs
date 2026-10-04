using System.ComponentModel.DataAnnotations;

namespace baitaplamthem.Models.DataModel
{
    public class Product
    {
        public int ProductId { get; set; }


        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(150,MinimumLength = 6)]
        public string ProductName { get; set; }
        [Required]
        public string Image { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Range(0,100000,ErrorMessage ="Giá tiền không vượt quá 100000")]
        public float Price { get; set; }

        [Required]
        [Range(0,float.MaxValue,ErrorMessage ="")]
        public float SalePrice { get; set; }

        [Required]
        [StringLength(1500)]
        public string Description { get; set; }

        // foreign key
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null;

    }
}
