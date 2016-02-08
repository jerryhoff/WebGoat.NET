using System.ComponentModel.DataAnnotations;

namespace OWASP.WebGoat.NET.Entities
{
    public partial class Offices
    {
        [Key]
        [StringLength(10)]
        public string officeCode { get; set; }

        [Required]
        [StringLength(50)]
        public string city { get; set; }

        [Required]
        [StringLength(50)]
        public string phone { get; set; }

        [Required]
        [StringLength(50)]
        public string addressLine1 { get; set; }

        [StringLength(50)]
        public string addressLine2 { get; set; }

        [StringLength(50)]
        public string state { get; set; }

        [Required]
        [StringLength(50)]
        public string country { get; set; }

        [Required]
        [StringLength(15)]
        public string postalCode { get; set; }

        [Required]
        [StringLength(10)]
        public string territory { get; set; }
    }
}
