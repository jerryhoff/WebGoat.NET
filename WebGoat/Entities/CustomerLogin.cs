using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OWASP.WebGoat.NET.Entities
{
    [Table("CustomerLogin")]
    public partial class CustomerLogin
    {
        [Key]
        [StringLength(100)]
        public string email { get; set; }

        public long customerNumber { get; set; }

        [Required]
        [StringLength(40)]
        public string password { get; set; }

        public short? question_id { get; set; }

        [StringLength(50)]
        public string answer { get; set; }
    }
}
