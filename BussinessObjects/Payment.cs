using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects
{
    public class Payment
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public DateTime Date { get; set; }
        public string Account { get; set; }
        public decimal Money { get; set; }
        public string Notice { get; set; }
    }
}
