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
    public class ProviderAdmin
    {
        static ServiceAdmin serviceAdmin = new ServiceAdmin();
        public ProviderAdmin()
        {
            //Mapper.Initialize(cfg => { cfg.CreateMap<Admin, AdminModel>();
            //    cfg.CreateMap<Request, RequestModel>(); });
        }

        public AdminModel Login(string name, string password)
        {
            Admin admin = serviceAdmin.CheckPassword(name, password);
            AdminModel adminModel= Mapper.Map<Admin, AdminModel>(admin);
            adminModel.RequestModels = GetRequests();
            return adminModel;
        }

        public ObservableCollection<RequestModel> GetRequests()
        {
            List<Request> requests = serviceAdmin.GetRequests();
            return Mapper.Map<List<Request>, ObservableCollection<RequestModel>>(requests);
        }

        public void LeaveBlocked(int requestId)
        {
            serviceAdmin.LeaveBlocked(requestId);
        }

        public void UnBlocked(int requestId, int cardId)
        {
            serviceAdmin.UnBlocked(requestId, cardId);
        }
    }
}
