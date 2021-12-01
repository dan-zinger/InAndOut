using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InAndOut1.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Borrower { get; set; }
        public string Lender { get; set; }
        [DisplayName("Item Name")]
        public string ItemName { get; set;}
    }
}
