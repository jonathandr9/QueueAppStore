using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueAppStore.Domain.Models
{
    public class Payment
    {
        public int OrderId { get; set; }
        public Card Card { get; set; }
        public int Amounts { get; set; }
        public decimal Value { get; set; }
    }
}
