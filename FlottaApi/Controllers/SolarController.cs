using FlottaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlottaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolarController : ControllerBase
    {
        [HttpGet("GetAll")]
       

        public IActionResult GetAllSofor()
        {
            
            using (var context = new Models.FlottaContext())
            {
                var soforok = context.Sofors.ToList();
                return Ok(soforok);
            }
        }

        [HttpDelete("DeleteSofor/{id}")]

        public IActionResult DeleteSofor(int id)
        {
            try
            {
                Sofor soforok = _context.Sofor.FirstOrDefaults(0 => 0, id == id);
                if (soforok != null) {

                    
                    _context.Sofors.Remove(soforok);
                    _context.SaveChanges();
                    return Ok("sokeres torlés")
                }
        }
    }
}
