using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InAndOut1.Models
{
    public class ExpenseType
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        [DisplayName("Type")]
        [Required]
        public string Name { get; set; }
    }
}