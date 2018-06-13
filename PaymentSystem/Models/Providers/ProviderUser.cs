using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using AutoMapper;
using BussinessObjects;
using System.Collections.ObjectModel;

namespace PaymentSystem.Models.Providers
{
    public class ProviderUser
    {
        static ServiceUser serviceUser = new ServiceUser();

        public ProviderUser()
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<Admin, AdminModel>());
            //Mapper.Initialize(cfg => cfg.CreateMap<Card, CardModel>());
            //Mapper.Initialize(cfg => cfg.CreateMap<Payment, PaymentModel>());
            //Mapper.Initialize(cfg => cfg.CreateMap<Request, RequestModel>());
            //Mapper.Initialize(cfg => cfg.CreateMap<User, UserModel>());
        }
        //User
        public UserModel Login (string name,string password)
        {
            User user = serviceUser.CheckPassword(name, password);
            return Mapper.Map<User, UserModel>(user);
        }

        public UserModel NewUser(string name, string password)
        {
            User user = serviceUser.AddUser(name, password);
            return Mapper.Map<User, UserModel>(user);
        }
        //Card
        public CardModel NewCard(string number,int userId)
        {
            Card card = serviceUser.NewCard(number, userId);
            return Mapper.Map<Card, CardModel>(card);
        }

        public ObservableCollection<CardModel> GetCards(int userId)
        {
            var cards= serviceUser.GetCards(userId);
            return Mapper.Map<List<Card>, ObservableCollection<CardModel>>(cards);
        }

        public void BlockedCard(int id)
        {
            serviceUser.BlockedCard(id);
        }
        public bool UnBlockedCard(int id, int cvv,string numberCard)
        {
            return serviceUser.UnBlockedCard(id, cvv,numberCard);
        }

        //Payment
        public ObservableCollection<PaymentModel> GetPayments(int id)
        {
            var payments = serviceUser.GetPayments(id);
            return Mapper.Map<List<Payment>, ObservableCollection<PaymentModel>>(payments);
        }

        public bool NewPayment(int cardId, string account, decimal money, string notice)
        {
            return serviceUser.NewPayment(cardId, account, money, notice);
        }
    }
}
