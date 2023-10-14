using System.ComponentModel.DataAnnotations;

namespace CPF.ProductCatalog.APIs.Models
{
    public class ProductRequest
    {
        [StringLength(8)]
        public string Code { get; set; } = null!;

        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = null!;
         
        public IFormFile? File { get; set; } 
    }
}
