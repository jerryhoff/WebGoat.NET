using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OWASP.WebGoat.NET.Entities
{
    public partial class Comments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long commentNumber { get; set; }

        [Required]
        [StringLength(15)]
        public string productCode { get; set; }

        [Required]
        [StringLength(100)]
        public string email { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string comment { get; set; }
    }
}
