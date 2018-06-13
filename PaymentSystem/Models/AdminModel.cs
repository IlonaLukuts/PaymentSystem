using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace PaymentSystem.Models
{
    public class AdminModel
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public ObservableCollection<RequestModel> RequestModels { get; set; }
    }
}
