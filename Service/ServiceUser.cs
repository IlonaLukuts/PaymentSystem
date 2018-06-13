using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObjects;
using DataObjects;

namespace Service
{
    public class ServiceUser
    {
        static UserDao userDao = new UserDao();
        static CardDao cardDao = new CardDao();
        static PaymentDao paymentDao = new PaymentDao();
        static RequestDao requestDao = new RequestDao();

        //Service User

        public User CheckPassword(string name, string password)
        {
            User user = userDao.GetUser(name);
            if (user == null)
                return null;
            if (user.Password != password)
                return null;
            cardDao.UpdateActive();
            paymentDao.UpdateOldPayments();
            return user;
        }
        public User AddUser(string name,string password)
        {
            if (userDao.GetUser(name) != null)
                return null;
            else
            {
                User user = new User();
                user.Name = name;
                user.Password = password;
                userDao.AddUser(user);
                return user;
            }
        }
        //Service Card
        public List<Card> GetCards(int userId)
        {
            return cardDao.GetCards(userId);
        }

        public Card NewCard(string numberCard,int userId)
        {
            return cardDao.AddUser(numberCard, userId);
        }

        public void BlockedCard(int id)
        {
            cardDao.ChangeBlocked(id, true);
        }
        public bool UnBlockedCard(int id,int cvv,string numberCard)
        {
            if(cardDao.CheckCVV(id,cvv))
            {
                Request request = new Request();
                request.CardId = id;
                request.NumberCard = numberCard;
                requestDao.AddRequest(request);
                return true;
            }
            return false;
        }

        //Service Payment
        public List<Payment> GetPayments(int id)
        {
            return paymentDao.GetPayments(id);
        }

        public bool NewPayment(int cardId, string account, decimal money, string notice)
        {
            if (!cardDao.CheckEnoughMoney(cardId, money))
                return false;
            else
            {
                Payment payment = new Payment();
                payment.CardId = cardId;
                payment.Account = account;
                payment.Date = DateTime.Now;
                payment.Money = money;
                payment.Notice = notice;
                paymentDao.AddPayment(payment);
                cardDao.UpdateBalance(cardId, money*-1);
                cardDao.UpdateBalance(account, money);
                return true;
            }
        }
    }
}
