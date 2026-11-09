using Argon2Sharp;
using FlottaApi.dtos;
using FlottaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlottaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private FloatContext _context;

        public loginController(FloatContext context)
        {
            _context = context;
        }

        [HttpPost]

        public IActionResult User(logindto userdto)
        {
            try
            {
                User user = _context.Users.FirstOrDefault(u => u.LoginName == userdto.LogInName);
                if (user == null)
                {
                    return NotFound("Missing user.");
                }
                string phcString = user.Nash;
                var (isValid, parameters) = Argon2PhcFormat.VerifyPhcString(userdto, phcString);
                if (isValid)
                {

                    return Ok("token");
                }
                return BadRequest("Wrong Password")

        }
            catch (Exception ex)
            {

                return BadRequest("something wrong");
            }
        }
}
