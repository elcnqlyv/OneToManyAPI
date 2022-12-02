using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneToManyAPI.Data;
using OneToManyAPI.Models;

namespace OneToManyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly OneToManyAPIDbContext dbContext;

        public ManufacturersController(OneToManyAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllManufacturers()
        {
            return Ok(await dbContext.Manufacturers.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetOneManufacturer([FromRoute] Guid id)
        {
            var manufacturer = await dbContext.Manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                return NotFound("Manufacturer not found");
            }
            return Ok(manufacturer);
        }
        [HttpPost]
        public async Task<IActionResult> AddManufacturer(AddManufacturerRequest addManufacturerRequest)
        {
            var manufacturer = new Manufacturer()
            {

                name = addManufacturerRequest.Name,
                Country = addManufacturerRequest.Country

            };

            await dbContext.Manufacturers.AddAsync(manufacturer);
            await dbContext.SaveChangesAsync();

            return Ok(manufacturer);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateManufacturer([FromRoute] Guid id, UpdateManufacturerRequest updateManufacturerRequest)
        {
            var manufacturer = await dbContext.Manufacturers.FindAsync(id);
            if (manufacturer != null)
            {
                manufacturer.Country = updateManufacturerRequest.country;
                manufacturer.name = updateManufacturerRequest.name;

                await dbContext.SaveChangesAsync();

                return Ok(manufacturer);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEngine([FromRoute] Guid id)
        {
            var manufacturer = await dbContext.Manufacturers.FindAsync(id);

            await dbContext.Manufacturers.FindAsync(id);
            if (manufacturer != null)
            {
                dbContext.Remove(manufacturer);
                await dbContext.SaveChangesAsync();

            }
            return NotFound("Manufacturer not found");
        }
    }
}
