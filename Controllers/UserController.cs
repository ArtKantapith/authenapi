using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AuthenApi.Models;

namespace AuthenApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public IUserRepository _userRepository { get; set; }
        public UserController(IUserRepository users)
        {
            _userRepository = users;
        }

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        [HttpGet("{id}", Name="GetUser")]
        public IActionResult GetById(int id)
        {
            var user = _userRepository.Find(id);
            if(user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if(user == null) 
            {
                return BadRequest();
            }
            _userRepository.Add(user);
            return CreatedAtRoute("GetUser", new {id = user.UserID}, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] User user)
        {
            if(user == null || user.UserID != id)
            {
                return BadRequest();
            }
            var _user = _userRepository.Find(id);
            if(_user == null)
            {
                return NotFound();
            }
            _user.Name = user.Name;
            _user.Password = user.Password;
            _userRepository.Update(_user);
            return new NoContentResult();
        } 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userRepository.Find(id);
            if(user == null)
            {
                return NotFound();
            }
            _userRepository.Remove(id);
            return new NoContentResult();
        }
    }
}