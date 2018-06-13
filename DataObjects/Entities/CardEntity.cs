using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class CardEntity
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string NumberAccount { get; set; }
        public decimal Balance { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsActive { get; set; }
        public DateTime Validity { get; set; }
        public int CVV { get; set; }
        public int? UserId { get; set; }
    }
}
