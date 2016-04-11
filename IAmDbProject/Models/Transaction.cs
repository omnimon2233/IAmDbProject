using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAmDbProject.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Transaction_Id { get; set; }

        [RegularExpression(@"^\d{16}$", ErrorMessage = "Must be 16 numbers, no spaces. ")]
        public int Credit_Card_Number { get; set; }

        [StringLength(5, MinimumLength = 5)]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Exactly 5 digits are allowed. ")]
        public string Zip { get; set; }

        [RegularExpression(@"^\d{3}$", ErrorMessage = "Must be 3 numbers, no spaces. ")]
        public int Cvv2_Code { get; set; }

        [Required]
        [RegularExpression(@"^[0-1]{1}$", ErrorMessage = "Please Enter 'True' or 'False'")]
        public int Receipt_Bool { get; set; }

        public virtual ICollection<Item_In_Transaction> ItemsInTransactions { get; set; }
    }
}
