using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AutoMapper;
using BussinessObjects;

namespace DataObjects
{
    public class DataContext:DbContext
    {
        public DataContext() : base("DBPaymentSystem")
        {
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<AdminEntity, Admin>();
            //    cfg.CreateMap<Admin, AdminEntity>();
            //    cfg.CreateMap<CardEntity, Card>();
            //    cfg.CreateMap<Card, CardEntity>();
            //    cfg.CreateMap<PaymentEntity, Payment>();
            //    cfg.CreateMap<Payment, PaymentEntity>();
            //    cfg.CreateMap<RequestEntity, Request>();
            //    cfg.CreateMap<Request, RequestEntity>();
            //    cfg.CreateMap<UserEntity, User>();
            //    cfg.CreateMap<User, UserEntity>();
            //});
        }

        public DbSet<AdminEntity> Admins { get; set; }
        public DbSet<CardEntity> Cards { get; set; }
        public DbSet<PaymentEntity> Payments { get; set; }
        public DbSet<RequestEntity> Requests { get; set; }
        public DbSet<UserEntity> Users { get; set; }




        #region Generation
        static Random rand = new Random();
        public void Generate()
        {
            Admins.ToList();
            Cards.ToList();
            Payments.ToList();
            Requests.ToList();
            Users.ToList();
            AdminEntity admin = new AdminEntity();
            admin.Name = "admin";
            admin.Password = "admin";
            Admins.Add(admin);
            this.SaveChanges();
            admin = new AdminEntity();
            admin.Name = "admin1";
            admin.Password = "admin1";
            Admins.Add(admin);
            this.SaveChanges();

            CardEntity card;
            for (int i=0;i<500;i++)
            {
                card = new CardEntity();
                for (int j = 0; j < 16; j++)
                    card.Number += rand.Next(0, 9).ToString();
                bool flag = false;
                if (Cards.SingleOrDefault(c => c.Number == card.Number)!=null)
                    flag = true;
                while(flag)
                {
                    card.Number = "";
                    for (int j = 0; j < 16; j++)
                        card.Number += rand.Next(0, 9).ToString();
                    if (Cards.SingleOrDefault(c => c.Number == card.Number) == null)
                        flag = false;
                }
                flag = false;
                card.NumberAccount = "BY";
                for (int j = 0; j < 26; j++)
                    card.NumberAccount += rand.Next(0, 9).ToString();
                if (Cards.SingleOrDefault(c => c.NumberAccount == card.NumberAccount) != null)
                    flag = true;
                while (flag)
                {
                    card.NumberAccount = "BY";
                    for (int j = 0; j < 26; j++)
                        card.NumberAccount += rand.Next(0, 9).ToString();
                    if (Cards.SingleOrDefault(c => c.NumberAccount == card.NumberAccount) != null)
                        flag = false;
                }
                card.IsBlocked = false;
                card.IsActive = true;
                card.Balance = Convert.ToDecimal(rand.Next(1000));
                card.CVV = rand.Next(1000);
                card.Validity = new DateTime(2022, 8, 1);
                Cards.Add(card);
                this.SaveChanges();
            }

            UserEntity user;
            for (int i = 0; i < 10; i++)
            {
                user = new UserEntity();
                user.Name = "user" + i.ToString();
                user.Password = user.Name;
                Users.Add(user);
                this.SaveChanges();
            }
        }
        #endregion
    }
}
