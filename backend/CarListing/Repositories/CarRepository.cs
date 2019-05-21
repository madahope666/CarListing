using CarListing.Interfaces;
using CarListing.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarListing.Repositories
{
    public class CarRepository : ICarRepository
    {
        private CarsContext _context;

        public CarRepository(CarsContext context)
        {
            _context = context;
        }

        public async Task<Car> Add(Car car)
        {
            await _context.CarsInfo.AddAsync(car);
            await _context.SaveChangesAsync();
            return (car);
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.CarsInfo.AnyAsync(c => c.Carid == id);
        }

        public async Task<Car> Find(int id)
        {
            return await _context.CarsInfo.SingleOrDefaultAsync(c => c.Carid == id);
        }

        public IEnumerable<Car> GetAll()
        {
            return _context.CarsInfo;
        }

        public async Task<Car> Remove(int id)
        {
            var car = await _context.CarsInfo.SingleAsync(c => c.Carid == id);
            _context.CarsInfo.Remove(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> Update(Car car)
        {
            _context.CarsInfo.Update(car);
            await _context.SaveChangesAsync();
            return car;
        }
    }
}
