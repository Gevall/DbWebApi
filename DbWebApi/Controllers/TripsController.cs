using DbWebApi.Context;
using DbWebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using NuGet.Protocol;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ItemsDBContext _dbContext; // обьявление класса контекста

        // Инициализация контекста
        public TripsController(ItemsDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        /// <summary>
        /// Метод возвращающий все записи из БД 
        /// </summary>
        /// <returns>Все записи из БД в виде List</returns>
        [HttpGet]
        public async Task<List<TripsModel>> GetTrips()
        {
            //if (_dbContext.Trips == null)
            //{
            //    return NotFound();
            //}
            var test = _dbContext.Trips.Select(x => new TripsModel
            {
                Manager = x.Manager,
                Docs = x.Docs,
                LoadCrm = x.LoadCrm,
                ReadySort = x.ReadySort,
                DateTrip = x.DateTrip,
                Specialist = $"{x.Employes.Lastname} {x.Employes.Firstname} {x.Employes.Patronymic}"
            });
            return await test.ToListAsync();
        }

        /// <summary>
        /// Возвращает запись согласно запросу к БД по id записи
        /// </summary>
        /// <param name="id">ID Записи в БД</param>
        /// <returns>Возвращает экзмепляр класса trip</returns>
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

        /// <summary>
        /// Метод добавления записи в БД
        /// </summary>
        /// <param name="trip">Экземпляр класса trip</param>
        /// <returns>Возвращает 201 статус код, если вставка в БД удачна</returns>
        [HttpPost]
        public async Task<ActionResult<Trip>> PostTrips(Trip trip)
        {
            if (_dbContext.Trips == null)
            {
                return Problem("Entity set 'ItemsDBContext.Trips'  is null.");
            }
            _dbContext.Trips.Add(trip);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTrips), new { id = trip.Id }, trip);
        }

        /// <summary>
        /// Изминение данных в заданой записи в БД по ID записи
        /// </summary>
        /// <param name="id">Id записи в БД</param>
        /// <param name="trip">Измененный экземляр класса trip</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrip(int id, Trip trip)
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


        /// <summary>
        /// Удаление записи по ID из БД
        /// </summary>
        /// <param name="id">Id записи в БД</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrip(int id)
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

            _dbContext.Trips.Remove(trip);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Поиск записи в context БД
        /// </summary>
        /// <param name="id">Id записи</param>
        /// <returns>true если запись найдена, false если запись не найдена</returns>
        private bool TripExists(int id)
        {
            return (_dbContext.Trips?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
