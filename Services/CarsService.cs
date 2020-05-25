using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleAPI.Entities;
using SimpleAPI.Helpers;

namespace SimpleAPI.Services
{
    public interface ICarService
    {
      
        Task<IEnumerable<Cars>> GetAll();
    }

    public class CarsService : ICarService
    {
        private List<Cars> _cars = new List<Cars>
        {
            new Cars {  CarName = "Audi", CarYear = "2017" }
        };
          public async Task<IEnumerable<Cars>> GetAll()
        {
            return await Task.Run(() => _cars.ShowCars());
        }
    }
}