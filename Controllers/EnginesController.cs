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
        private readonly OneToManyAPIDbContext dbContext;

        public EnginesController(OneToManyAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEngines()
        {
            return Ok(await dbContext.Engines.ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
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
            Manufacturer manufacturer = dbContext.Manufacturers.FirstOrDefault(m=>m.Id == addEngineRequest.ManufacturerId);

            var engine = new Engine()
            {
                Name = addEngineRequest.Name,
                Volume = addEngineRequest.Volume,
                Manufacturer = manufacturer
            };

            await dbContext.Engines.AddAsync(engine);
            await dbContext.SaveChangesAsync();

            return Ok(engine);
        }

        [HttpPut]
        [Route("{id}")]
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
        [Route("{id}")]
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
