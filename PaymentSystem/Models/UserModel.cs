using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace PaymentSystem.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ObservableCollection<CardModel> CardModels { get; set; }

        public UserModel()
        {
            CardModels = new ObservableCollection<CardModel>();
        }
    }
}
