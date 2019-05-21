using CarListing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarListing.Interfaces
{
    public interface ICarRepository
    {
        Task<Car> Add(Car car);

        IEnumerable<Car> GetAll();

        Task<Car> Find(int id);

        Task<Car> Update(Car car);

        Task<Car> Remove(int id);

        Task<bool> Exists(int id);
    }
}
