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

        [HttpGet("GetOneEngine/{id:guid}")]
        public async Task<IActionResult> GetOneEngine([FromRoute] Guid id)
        {
            var engine = await dbContext.Engines.FindAsync(id);
            if (engine == null)
            {
                return NotFound("Engine not found");
            }
            return Ok(engine);
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

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateEngine([FromRoute] Guid id, UpdateEngineRequest updateEngineRequest)
        {
            var engine = await dbContext.Engines.FindAsync(id);
            if (engine != null)
            {
                engine.Volume = updateEngineRequest.Volume;
                engine.Name = updateEngineRequest.Name;

                await dbContext.SaveChangesAsync();

                return Ok(engine);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id: guid}")]
        public async Task<IActionResult> DeleteEngine([FromRoute] Guid id)
        {
            var engine = await dbContext.Engines.FindAsync(id);

            await dbContext.Engines.FindAsync(id);
            if (engine != null)
            {
                dbContext.Remove(engine);
                await dbContext.SaveChangesAsync();

            }
            return NotFound("Engine not found");
        }

    }
}
