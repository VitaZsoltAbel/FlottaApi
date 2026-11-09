using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlottaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoforControllerú : ControllerBase
    {

        public IActionResult GetSoforJarmu(int id)
        {
            try
            {
                SoforControllerú vane = _context.Sofor.FirstOrDefault(s => s.id == id);
                if (vane == null) { 
                return NotFound("hiányzik sofőr");
                }
                var result = _context.KikuldottJarmu
                    Where(j => SoforNavigation.id == id).
                    Select(j => j.Gepjarmu).
                    ToList();
                return (Exception ex){

                    return BadRequest("hiba" + ex.Message)
                }
        }
    }
}
