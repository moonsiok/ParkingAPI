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

        [HttpGet] 
        public async Task<ActionResult<List<Parking>>> Get()
        {
            
            return Ok(await _context.parkings.ToListAsync());
        }

        [HttpGet("(id)")]
        //public async Task<ActionResult<Parking>> Get(int id)
        //{
        //    var car = await _context.parkings.FindAsync(id);
        //    if (car == null)
        //        return BadRequest("Car is not found");
        //    return Ok(car);
        //}

        public async Task<ActionResult<List<Parking>>> Get(int ownerId)
        {
            var parkings = await _context.parkings
                .Where(p => p.OwnerId == ownerId)
                .Include(c=>c.Number)
                .ToListAsync();
            return parkings;
        }
        //, Authorize(Roles = "Admin")
        [HttpPost]
        public async Task<ActionResult<List<Parking>>> AddCars(CreateParking request)
        {
            //_context.parkings.Add(car);
            //await _context.SaveChangesAsync();
            //return Ok(await _context.parkings.ToListAsync());
            var owner = await _context.Owners.FindAsync(request.OwnerId);
            if (owner == null)
                return NotFound();
            var newParking = new Parking
            {
                Name = request.Name,
                Place = request.Place,
                Owner = owner
            };
            _context.parkings.Add(newParking);
            await _context.SaveChangesAsync();
            return await Get(newParking.OwnerId);

        }

        [HttpPut]
        public async Task<ActionResult<List<Parking>>> UpdateCar(Parking request)
        {
            var dbcar = await _context.parkings.FindAsync(request.Id);
            if (dbcar == null)
                return BadRequest("Car is not found");
            dbcar.Name = request.Name;
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
        [HttpPost("weapon")]
        public async Task<ActionResult<Parking>> AddNumber(Addnumber request)
        {

            var parking = await _context.parkings.FindAsync(request.ParkingId);
            if (parking == null)
                return NotFound();
            var newnumber = new Number
            {
                fines = request.fines,
                Parking = parking
            };
            _context.Number.Add(newnumber);
            await _context.SaveChangesAsync();
            return parking;
        }
    }
}
