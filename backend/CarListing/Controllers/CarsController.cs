using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CarListing.Interfaces;
using CarListing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarListing.Controllers
{
    [Produces("application/json")]
    [Route("api/Cars")]
    public class CarsController : Controller
    {
        private readonly ICarRepository _carRepository;

        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        private async Task<bool> CarExists(int id)
        {
            return await _carRepository.Exists(id);
        }

        [Route("getAllCars")]
        [HttpGet]
        [Produces(typeof(DbSet<Car>))]
        [ResponseCache(Duration = 120)]
        public IActionResult GetCars()
        {
            var results = new ObjectResult(_carRepository.GetAll())
            {
                StatusCode = (int)HttpStatusCode.OK
            };

            Request.HttpContext.Response.Headers.Add("X-Total-Count", _carRepository.GetAll().Count().ToString());

            return results;

        }

        [Route("getSingleCar/{id}")]
        [HttpGet(Name = "GetCar")]
        [Produces(typeof(Car))]
        [ResponseCache(Duration = 120)]
        public async Task<IActionResult> GetCar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var car = await _carRepository.Find(id);    

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [Route("addCar")]
        [HttpPost]
        [Produces(typeof(Car))]
        public async Task<IActionResult> PostCar([FromBody] Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _carRepository.Add(car);

            return CreatedAtAction("GetCar", new { id = car.Carid }, car);
        }

        [Route("updateCar/{id}")]
        [HttpPut]
        [Produces(typeof(Car))]
        public async Task<IActionResult> PutCar([FromRoute] int id, [FromBody] Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != car.Carid)
            {
                return BadRequest();
            }

            try
            {
                await _carRepository.Update(car);
                return Ok(car);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        [Route("deleteCar/{id}")]
        [HttpDelete]
        [Produces(typeof(Car))]
        public async Task<IActionResult> DeleteCar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await CarExists(id))
            {
                return NotFound();
            }

            await _carRepository.Remove(id);

            return Ok();
        }
    }
}