using System;
using System.Collections.Generic;
using System.Linq;
using TrincaChurras.Core.Entities;
using TrincaChurras.Core.Interfaces.Repositories;

namespace TrincaChurras.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User FindUser(string email, string password)
        {
            var users = new List<User>
            {
                new User(new Guid("a2021f74-feeb-4705-a761-cfaf9da5368d"), "rodrigo@gmail.com", "Test@123"),
                new User(new Guid("96d7c805-32e4-46d8-940e-5abd03e1d2f0"), "jobs@trinca.recruitee.com", "TrincaChurras")
            };
            
            var user = users.FirstOrDefault(x => x.Email.ToLower() == email.ToLower() && x.Password == password);

            return user;
        }
    }
}
