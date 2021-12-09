using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InAndOut1.Models.ViewModels
{
    public class ExpenseViewModel
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        [DisplayName("Expense")]
        public string ExpenseName { get; set; }
        public int Amount { get; set; }
        [DisplayName("Expense Type")]
        public int ExpenseTypeId { get; set; }
        [DisplayName("Expense Type")]
        public string ExpenseType { get; set; }

    }
}