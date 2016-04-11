using IAmDbProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAmDbProject.Models
{
    public enum StatusType { Caretaker, Survivor, Both};
    public class Person
    {
        [Key]
        public int Person_Id { get; set; }
        

        [Required]
        [Index("Idx_person_full_name", 1)]
        [StringLength(25, MinimumLength =1)]
        public string First_Name { get; set; }

        [Required]
        [Index("Idx_person_last_name")]
        [Index("Idx_person_full_name", 2)]
        [StringLength(25, MinimumLength =1)]
        public string Last_Name { get; set; }

        [Required]
        [StringLength(255, MinimumLength =5)]
        public string Address1 { get; set; }

        [StringLength(255, MinimumLength =5)]
        public string Address2 { get; set; }

        [Required]
        [StringLength(30, MinimumLength =2)]
        public string City { get; set; }

        [Required]
        public State State { get; set; }

        [StringLength(5, MinimumLength = 5)]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Exactly 5 digits are allowed")]
        public string Zip { get; set; }

        [Required]
        [RegularExpression(@"^\(?\d{3}\)?-? *\d{3}-? *-?\d{4}$", ErrorMessage = "Must have a dollar value of at least 1.00 and must be formatted the same way.")]
        public string Phone { get; set; }

        [Required]
        [RegularExpression(@"^[0-1]{1}$", ErrorMessage = "Must either be true or false.")]
        public int Waiver_Signed { get; set; }

        [Required]
        [RegularExpression(@"^[0-1]{1}$", ErrorMessage = "Must either be true or false.")]
        public int Deceased_Bool { get; set; }

        [Required]
        [RegularExpression(@"^[0-3]{1}$", ErrorMessage = "Must be a single digit 0-3 representing the users role")]
        public int User_Role { get; set; }

        [Index("Idx_person_status")]
        public StatusType Status { get; set; }


        public virtual ICollection<Item>  Items { get; set; }

       
    }
}
