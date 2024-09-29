using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;

namespace NZWalks.API.Controllers
{
    // https://localhost:0000/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        public readonly NZWalksDbContext dbcontext;
        public RegionsController(NZWalksDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = dbcontext.Regions.ToList();

            return Ok(regions);
        }
    }
}
