using DbWebApi.Context;
using DbWebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ItemsDBContext _dbContext;

        public TripsController(ItemsDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/<TripsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trip>>> GetTrips()
        {
            if (_dbContext.Trips == null)
            {
                return NotFound();
            }
            return await _dbContext.Trips.ToListAsync();
        }

        // GET api/<TripsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trip>> GetTrips(int id)
        {
            if (_dbContext.Trips == null)
            {
                return NotFound();
            }
            var trip = await _dbContext.Trips.FindAsync(id);

            if (trip == null)
            {
                return NotFound();
            }

            return trip;
        }

        // POST api/<TripsController>
        [HttpPost]
        public async Task<ActionResult<Trip>> PostPhonebook(Trip trip)
        {
            if (_dbContext.Trips == null)
            {
                return Problem("Entity set 'PhonebookContext.Phonebooks'  is null.");
            }
            _dbContext.Trips.Add(trip);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTrips), new { id = trip.Id }, trip);
        }

        // PUT api/<TripsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhonebook(int id, Trip trip)
        {
            if (id != trip.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(trip).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }


        // DELETE api/<TripsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private bool TripExists(int id)
        {
            return (_dbContext.Trips?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
