using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPIApplication.Models;

namespace WebAPIApplication.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        public UsersController(IUserRepository users)
        {
            Users = users;
        }
        public IUserRepository Users { get; set; }

        // GET api/users
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return Users.GetAll();
        }

        // GET api/users/5
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetById(string id)
        {
            var user = Users.Find(new Guid(id));
            
            if (user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }

        // POST api/users
        [HttpPost]
        public IActionResult Create([FromBody]User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            Users.Add(user);

            return CreatedAtRoute("GetUser", new { controller = "Users", id = user.Id }, user);
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]User user)
        {
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
        }
    }
}
