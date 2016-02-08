using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OWASP.WebGoat.NET.Entities
{
    public partial class OrderDetails
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long orderNumber { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string productCode { get; set; }

        public long quantityOrdered { get; set; }

        [Column(TypeName = "real")]
        public double priceEach { get; set; }

        public short orderLineNumber { get; set; }
    }
}
