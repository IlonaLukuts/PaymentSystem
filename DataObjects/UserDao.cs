using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BussinessObjects;

namespace DataObjects
{
    public class UserDao
    {
        static UserDao()
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<UserEntity, User>());
            //Mapper.Initialize(cfg => cfg.CreateMap<User, UserEntity>());
        }
        public User GetUser(string name)
        {
            using (var context = new DataContext())
            {
                var user = context.Users.SingleOrDefault(u => u.Name == name);
                if (user == null)
                    return null;
                return Mapper.Map<UserEntity, User>(user);
            }
        }

        public void AddUser(User user)
        {
            using (var context = new DataContext())
            {
                var entity = Mapper.Map<User, UserEntity>(user);

                context.Users.Add(entity);
                context.SaveChanges();

                // update business object with new id
                user.Id = entity.Id;
            }
        }
    }
}
