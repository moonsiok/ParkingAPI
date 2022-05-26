using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ParkingController : Controller
    {
        private readonly DataContext _context;

        public ParkingController(DataContext context)
        {
            _context = context;
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Parking>>> Get()
        {
            
            return Ok(await _context.parkings.ToListAsync());
        }

        [HttpGet("(id)"), Authorize]
        public async Task<ActionResult<Parking>> Get(int id)
        {
            var car = await _context.parkings.FindAsync(id);
            if (car == null)
                return BadRequest("Car is not found");
            return Ok(car);
        }

        [HttpPost]
        public async Task<ActionResult<List<Parking>>> AddCars(Parking car)
        {
            _context.parkings.Add(car);
            await _context.SaveChangesAsync();
            return Ok(await _context.parkings.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Parking>>> UpdateCar(Parking request)
        {
            var dbcar = await _context.parkings.FindAsync(request.Id);
            if (dbcar == null)
                return BadRequest("Car is not found");
            dbcar.Name = request.Name;
            dbcar.FirstName = request.FirstName;
            dbcar.LastName = request.LastName;
            dbcar.Place = request.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.parkings.ToListAsync());
        }

        [HttpDelete("(id)")]
        public async Task<ActionResult<List<Parking>>> Delete(int id)
        {
            var dbcar = await _context.parkings.FindAsync(id);
            if (dbcar == null)
                return BadRequest("Car is not found");
            _context.parkings.Remove(dbcar);
            await _context.SaveChangesAsync();
            return Ok(await _context.parkings.ToListAsync());
        }
    }
}
