using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OWASP.WebGoat.NET.Entities
{
    public partial class SecurityQuestions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short question_id { get; set; }

        [Required]
        [StringLength(400)]
        public string question_text { get; set; }
    }
}
