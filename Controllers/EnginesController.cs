using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneToManyAPI.Data;
using OneToManyAPI.Models;

namespace OneToManyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnginesController : Controller
    {
        private readonly EnginesAPIDbContext dbContext;

        public EnginesController(EnginesAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEngines()
        {
            return Ok(await dbContext.Engines.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddEngine(AddEngineRequest addEngineRequest) 
        {
            var engine = new Engine()
            {
                Id = Guid.NewGuid(),
                Name = addEngineRequest.Name,
                Volume = addEngineRequest.Volume

            };

           await dbContext.Engines.AddAsync(engine);
            await dbContext.SaveChangesAsync();

            return Ok(engine);
        }
    }
}
