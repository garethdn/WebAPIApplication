using System;
using System.Collections.Generic;

namespace WebAPIApplication.Models
{
    public interface IUserRepository
    {
        void Add(User item);
        IEnumerable<User> GetAll();
        User Find(Guid id);
        User Remove(Guid id);
        void Update(User item);
    }
}