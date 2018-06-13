using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BussinessObjects;

namespace DataObjects
{
    public class RequestDao
    {
        static RequestDao()
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<RequestEntity, Request>());
            //Mapper.Initialize(cfg => cfg.CreateMap<Request, RequestEntity>());
        }

        public List<Request> GetRequests()
        {
            using (var context = new DataContext())
            {
                var requests = context.Requests.ToList();
                return Mapper.Map<List<RequestEntity>, List<Request>>(requests);
            }
        }
        
        public void AddRequest(Request request)
        {
            using (var context = new DataContext())
            {
                var entity = Mapper.Map<Request, RequestEntity>(request);

                context.Requests.Add(entity);
                context.SaveChanges();
            }
        }

        public void RemoveRequest(int id)
        {
            using (var context = new DataContext())
            {
                var request=context.Requests.SingleOrDefault(r => r.Id == id);
                context.Requests.Remove(request);
                context.SaveChanges();
            }
        }
    }
}
