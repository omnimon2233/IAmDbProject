using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAmDbProject.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Item_Id { get; set; }

        [Required]
        [Index("Idx_item_name")]
        [StringLength(40, MinimumLength =2)]
        public String Name { get; set; }

        [DisplayName("Expected Sale Value")]
        //[RegularExpression(@"^\d{1, 5}\.\d{2}$", ErrorMessage = "Must have a dollar value of at least 1.00 and must be formatted the same way.")]
        public double Expected_Sale_Value { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public double Start_Price { get; set; }

        public double? End_Price { get; set; }

        [Required]
        public double Min_Increment { get; set; }

       
        public double Buyout_Price { get; set; }

        [Required]
        [ForeignKey("Donor")]
        public int Donor_Id { get; set; }
        public virtual Donor Donor { get; set; }

        [ForeignKey("Event")]
        public virtual int? Event_Id { get; set; }
        public virtual Event Event { get; set; }

        [DisplayName("Bidder Id")]
        [ForeignKey("Person")]
        public virtual int? Person_Id { get; set; }
        public virtual Person Person { get; set; }

        public virtual ICollection<Item_In_Transaction> ItemsInTransactions { get; set; }


    }
}
