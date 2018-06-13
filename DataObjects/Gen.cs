using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Gen
    {
        public static void Gener()
        {
            using (var context = new DataContext())
            {
                context.Generate();
            }
        }
    }
}
