using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BussinessObjects;

namespace DataObjects
{
    public class PaymentDao
    {
        static PaymentDao()
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<PaymentEntity, Payment>());
            //Mapper.Initialize(cfg => cfg.CreateMap<Payment, PaymentEntity>());
        }

        public List<Payment> GetPayments(int id)
        {
            using (var context = new DataContext())
            {
                var payments = context.Payments.Where(c => c.CardId == id).ToList();
                return Mapper.Map<List<PaymentEntity>, List<Payment>>(payments);
            }
        }

        public void UpdateOldPayments()
        {
            using (var context = new DataContext())
            {
                var payments = context.Payments.Where(c => c.Date.Month<=DateTime.Now.Month-1||c.Date.Year<DateTime.Now.Year).ToList();
                context.Payments.RemoveRange(payments);
                context.SaveChanges();
            }
        }

        public void AddPayment(Payment payment)
        {
            using (var context = new DataContext())
            {
                var entity = Mapper.Map<Payment, PaymentEntity>(payment);

                context.Payments.Add(entity);
                context.SaveChanges();

                // update business object with new id
                payment.Id = entity.Id;
            }
        }
    }
}
