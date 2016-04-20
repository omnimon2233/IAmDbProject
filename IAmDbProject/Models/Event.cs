using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAmDbProject.Models
{
    public enum State { AL, AK, AZ, AR, CA, CO, CT, DE, FL, GA, HI, ID, IL, IN, IA, KS, KY, LA, ME, MD, MA, MI, MN, MS, MO, MT, NE, NV, NH, NJ, NM, NY, NC, ND, OH, OK, OR, PA, RI, SC, SD, TN, TX, UT, VT, VA, WA, WV, WI, WY };
    public class Event
    {
        [Key]
        public int Event_Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Event_name { get; set; }

        [Required]
        [StringLength(50, MinimumLength =5)]
        public string Address { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string City { get; set; }

        [Required]
        public State State { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string County { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public string Event_Type { get; set; }

        
        public double Event_Total { get; set; }

        [RegularExpression(@"^[0-1]{1}$", ErrorMessage = "Must either be true or false.")]
        public int Event_Close { get; set; }


        public virtual ICollection<Item> Items { get; set; }
    }
}
