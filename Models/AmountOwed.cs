using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TunableInterview.Models
{
    public class AmountOwed
    {
        public Customer customer { get; set; }
        public long amountOwed { get; set; }
    }
}
