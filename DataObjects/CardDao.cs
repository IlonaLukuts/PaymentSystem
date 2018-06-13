using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BussinessObjects;

namespace DataObjects
{
    public class CardDao
    {
        static CardDao()
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<CardEntity, Card>());
            //Mapper.Initialize(cfg => cfg.CreateMap<Card, CardEntity>());
        }

        public List<Card> GetCards(int id)
        {
            using (var context = new DataContext())
            {
                var cards = context.Cards.Where(c => c.UserId==id).ToList();
                return Mapper.Map<List<CardEntity>, List<Card>>(cards);
            }
        }
        public void UpdateBalance(int id, decimal addBalance)
        {
            using (var context = new DataContext())
            {
                var card = context.Cards.SingleOrDefault(c => c.Id == id);
                if (card != null)
                    card.Balance += addBalance;
                context.SaveChanges();
            }
        }

        public void UpdateBalance(string numberAccount, decimal addBalance)
        {
            using (var context = new DataContext())
            {
                var card = context.Cards.SingleOrDefault(c => c.NumberAccount == numberAccount);
                if (card != null)
                    card.Balance += addBalance;
                context.SaveChanges();
            }
        }

        public void UpdateActive()
        {
            if (DateTime.Now.Day == 1)
            {
                DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                using (var context = new DataContext())
                {
                    var cards = context.Cards.Where(c => c.Validity <= dateTime).ToList();
                    foreach (var card in cards)
                    {
                        if (card.Validity < dateTime)
                            context.Cards.Remove(card);
                        else
                        {
                            card.IsBlocked = true;
                            card.IsActive = false;
                        }
                    }
                    context.SaveChanges();
                }
            }
        }
        public void ChangeBlocked(int id,bool isBlocked)
        {
            using (var context = new DataContext())
            {
                var card = context.Cards.SingleOrDefault(c => c.Id == id);
                if (card != null)
                    card.IsBlocked = isBlocked;
                context.SaveChanges();
            }
        }

        public Card AddUser(string numberCard,int userId)
        {
            using (var context = new DataContext())
            {
                var card = context.Cards.SingleOrDefault(c => c.Number == numberCard);
                if (card != null)
                {
                    if (card.UserId == null)
                    {
                        card.UserId = userId;
                        context.SaveChanges();
                        return Mapper.Map<CardEntity, Card>(card);
                    }
                    else return null;
                }
                else return null;
            }
        }

        public bool CheckCVV(int id,int cvv)
        {
            using (var context = new DataContext())
            {
                var card = context.Cards.SingleOrDefault(c => c.Id == id);
                if (card != null)
                {
                    if (card.CVV == cvv)
                        return true;
                    else return false;
                }
                else return false;
            }
        }
        public bool CheckEnoughMoney(int id,decimal money)
        {
            using (var context = new DataContext())
            {
                var card = context.Cards.SingleOrDefault(c => c.Id == id);
                if (card != null)
                   return card.Balance>=money;
                return false;
            }
        }
    }
}
