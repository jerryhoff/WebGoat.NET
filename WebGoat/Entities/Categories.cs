using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OWASP.WebGoat.NET.Entities
{
    public partial class Categories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long catNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string catName { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string catDesc { get; set; }
    }
}
