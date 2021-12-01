using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InAndOut1.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        [DisplayName("Expense")]
        [Required]
        public string ExpenseName { get; set; }
        [Range(1, int.MaxValue, ErrorMessage ="Amount must be greater than 0!")]
        public int Amount { get; set; }
    }
}