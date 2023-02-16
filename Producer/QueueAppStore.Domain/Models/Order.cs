using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueAppStore.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Card Card { get; set; }
        public Client Client { get; set; }
        public App App { get; set; }
    }
}
