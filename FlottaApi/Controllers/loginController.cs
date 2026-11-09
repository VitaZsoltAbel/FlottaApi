using Argon2Sharp;
using FlottaApi.dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlottaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class loginController : ControllerBase
    {
        private FloatContext _context;

        public loginController(FloatContext context)
        {
            _context = context;
        }

        [HttpPost]

        public IActionResult Login(logindto logindto)
        {
            try
            {
                User user = _context.Users.FirstOrDefault(u => u.LoginName == logindto.LogInName);
                if (user == null)
                {
                    return NotFound("Missing user.");
                }
                string phcString = user.Nash;
                var (isValid, parameters) = Argon2PhcFormat.VerifyPhcString(logindto, phcString);
                if (isValid)
                {

                    return Ok("token");
                }
                return BadRequest("Wrong Password")

        } catch (Exception ex) {

                return BadRequest("something wrong"); }

        }
    }

}