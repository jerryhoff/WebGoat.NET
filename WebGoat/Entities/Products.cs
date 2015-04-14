using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OWASP.WebGoat.NET.Entities
{
    public partial class Products
    {
        [Key]
        [StringLength(15)]
        public string productCode { get; set; }

        [Required]
        [StringLength(200)]
        public string productName { get; set; }

        public long catNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string productImage { get; set; }

        [Required]
        [StringLength(50)]
        public string productVendor { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string productDescription { get; set; }

        public short quantityInStock { get; set; }

        [Column(TypeName = "real")]
        public double buyPrice { get; set; }

        [Column(TypeName = "real")]
        public double MSRP { get; set; }
    }
}
