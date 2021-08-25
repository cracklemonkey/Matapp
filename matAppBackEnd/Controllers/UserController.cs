using matAppBackEnd.Models;
using matAppBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace UsersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<User>> Get() =>
            _userService.Get();

          

         [HttpGet("{userid}", Name = "GetUser")]
        public ActionResult<User> Get(int userid)
        {   
            var user = _userService.Get(userid);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        
       
        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            _userService.Create(user);

            return CreatedAtRoute("GetUser", new { userid = user.UserId.ToString() }, user);
        }

        [HttpPut("{userid}")]
        public IActionResult Update(int userid, [FromBody] User userIn)
        {
            var user = _userService.Get(userid);

            if (user == null)
            {
                return NotFound();
            }

            _userService.UpdateUser(userid, userIn);

            return NoContent();
        }

        [HttpDelete("{userid}")]
        public IActionResult Delete(int userid)
        {
            var user = _userService.Get(userid);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Delete(user.UserId);

            return NoContent();

        }
        
        
    }

}