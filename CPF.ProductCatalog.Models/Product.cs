using System.ComponentModel.DataAnnotations;

namespace CPF.ProductCatalog.Models
{
    public class Product
    {
        [Key]
        [StringLength(8)]
        public string Code { get; set; } = null!;

        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [StringLength(50)]
        public string PictureFileName { get; set; } = null!;

        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;
        
        [StringLength(50)]
        public string CreatedBy { get; set; } = null!;
    }
}