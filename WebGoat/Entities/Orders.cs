using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OWASP.WebGoat.NET.Entities
{
    public partial class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long orderNumber { get; set; }

        public DateTime orderDate { get; set; }

        public DateTime requiredDate { get; set; }

        public DateTime? shippedDate { get; set; }

        [Required]
        [StringLength(15)]
        public string status { get; set; }

        [StringLength(2147483647)]
        public string comments { get; set; }

        public long customerNumber { get; set; }
    }
}
