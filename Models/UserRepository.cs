using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace WebAPIApplication.Models
{
    public class UserRepository : IUserRepository
    {
        static ConcurrentDictionary<Guid, User> _users = 
              new ConcurrentDictionary<Guid, User>();

        public UserRepository()
        {
            Add(new User { 
                Name = "Gareth",
                Id = new Guid("ac6583e1-6c55-4d34-9dd2-8496a36d0df9"),
                Email = "garethdn@mymail.co" 
            });
        }

        public IEnumerable<User> GetAll()
        {
            return _users.Values;
        }

        public void Add(User item)
        {
            item.Id = Guid.NewGuid();
            _users[item.Id] = item;
        }

        public User Find(Guid id)
        {
            User item;
            _users.TryGetValue(id, out item);
            return item;
        }

        public User Remove(Guid id)
        {
            User item;
            _users.TryGetValue(id, out item);
            _users.TryRemove(id, out item);
            return item;
        }

        public void Update(User item)
        {
            _users[item.Id] = item;
        }
    }
}