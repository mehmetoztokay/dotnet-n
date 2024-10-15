using System.ComponentModel.DataAnnotations;

namespace shopapp.webui.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Isim 2 ile 60 karakter arasinda olmalidir")]
        public string Name { get; set; }

        [Required]
        [Range(1, 10000)]
        public double? Price { get; set; }

        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; } = false;
        public int CategoryId { get; set; }
    }
}