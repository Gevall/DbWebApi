using DbWebApi.Context;
using DbWebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeController : ControllerBase
    {
        private readonly ItemsDBContext _dbContext; // обьявление класса контекста

        // Инициализация контекста
        public EmployeController(ItemsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Метод возвращающий все записи из БД
        /// </summary>
        /// <returns>Все записи из БД в виде List</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employe>>> GetTrips()
        {
            if (_dbContext.Trips == null)
            {
                return NotFound();
            }
            return await _dbContext.Employes.ToListAsync();
        }

        //// GET: EmployeController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: EmployeController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        /// <summary>
        /// Метод добавления записи в БД
        /// </summary>
        /// <param name="trip">Экземпляр класса trip</param>
        /// <returns>Возвращает 201 статус код, если вставка в БД удачна</returns>
        [HttpPost]
        public async Task<ActionResult<Trip>> PostEmploye(Employe employe)
        {
            if (_dbContext.Employes == null)
            {
                return Problem("Entity set 'ItemsDBContext.Trips'  is null.");
            }
            _dbContext.Employes.Add(employe);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTrips), new { id = employe.Id }, employe);
        }

        // GET: EmployeController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: EmployeController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: EmployeController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: EmployeController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
