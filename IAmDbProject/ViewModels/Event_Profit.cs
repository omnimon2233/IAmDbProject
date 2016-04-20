using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAmDbProject.ViewModels
{
    public class Event_Profit
    {
        public int EventId { get; set; }

        public double Event_Total { get; set; }

        public double Event_Difference { get; set; }

        public double Event_Expected { get; set; }
    }
}
