using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleAPI.Entities;
using SimpleAPI.Helpers;

namespace SimpleAPI.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
    }

    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = new List<User>
        {
            new User {  Username = "test1", Password = "test" }
        };

        private List<Cars> _cars = new List<Cars>
        {
            new Cars {  CarName = "Audi", CarYear = "2017" }
        };

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _users.SingleOrDefault(x => x.Username == username && x.Password == password));

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so return user details without password
            return user.WithoutPassword();
            //return  
            // return await Task.Run(() => _cars.ShowCars());
           
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await Task.Run(() => _users.WithoutPasswords());
       }
    }

   
}