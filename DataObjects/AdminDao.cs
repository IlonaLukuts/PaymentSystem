using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BussinessObjects;


namespace DataObjects
{
    public class AdminDao
    {
        static AdminDao()
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<AdminEntity, Admin>());
            //Mapper.Initialize(cfg => cfg.CreateMap<Admin, AdminEntity>());
        }
        public Admin GetAdmin(string name)
        {
            using (var context = new DataContext())
            {
                var admin = context.Admins.SingleOrDefault(a => a.Name == name);
                if (admin == null)
                    return null;
                return Mapper.Map<AdminEntity, Admin>(admin);
            }
        }

    }
}
