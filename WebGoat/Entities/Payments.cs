using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OWASP.WebGoat.NET.Entities
{
    public partial class Payments
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long customerNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string cardType { get; set; }

        [Required]
        [StringLength(50)]
        public string creditCardNumber { get; set; }

        public short verificationCode { get; set; }

        [Required]
        [StringLength(3)]
        public string cardExpirationMonth { get; set; }

        [Required]
        [StringLength(5)]
        public string cardExpirationYear { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string confirmationCode { get; set; }

        public DateTime paymentDate { get; set; }

        [Column(TypeName = "real")]
        public double amount { get; set; }
    }
}
