using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace PaymentSystem.Models
{
    public class CardModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string NumberAccount { get; set; }
        public decimal Balance { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsActive { get; set; }
        public DateTime Validity { get; set; }
        public int CVV { get; set; }
    }

}
