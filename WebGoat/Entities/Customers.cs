using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OWASP.WebGoat.NET.Entities
{
    public partial class Customers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long customerNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string customerName { get; set; }

        [StringLength(100)]
        public string logoFileName { get; set; }

        [Required]
        [StringLength(50)]
        public string contactLastName { get; set; }

        [Required]
        [StringLength(50)]
        public string contactFirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string phone { get; set; }

        [Required]
        [StringLength(50)]
        public string addressLine1 { get; set; }

        [StringLength(50)]
        public string addressLine2 { get; set; }

        [Required]
        [StringLength(50)]
        public string city { get; set; }

        [StringLength(50)]
        public string state { get; set; }

        [StringLength(15)]
        public string postalCode { get; set; }

        [Required]
        [StringLength(50)]
        public string country { get; set; }

        public long? salesRepEmployeeNumber { get; set; }

        [Column(TypeName = "real")]
        public double? creditLimit { get; set; }
    }
}
