using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObjects;
using DataObjects;

namespace Service
{
    public class ServiceAdmin
    {
        static AdminDao adminDao = new AdminDao();
        static RequestDao requestDao = new RequestDao();
        static CardDao cardDao = new CardDao();

        //Service Admin
        public Admin CheckPassword(string name, string password)
        {
            Admin admin = adminDao.GetAdmin(name);
            if (admin == null)
                return null;
            if (admin.Password != password)
                return null;
            return admin;
        }

        //Service Request
        public List<Request> GetRequests()
        {
            return requestDao.GetRequests();
        }

        public void LeaveBlocked(int requestId)
        {
            requestDao.RemoveRequest(requestId);
        }

        public void UnBlocked(int requestId,int cardId)
        {
            cardDao.ChangeBlocked(cardId, false);
            requestDao.RemoveRequest(requestId);
        }

    }
}
