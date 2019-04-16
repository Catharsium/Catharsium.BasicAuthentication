using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catharsium.BasicAuthentication.Api.Entities;
using Catharsium.BasicAuthentication.Api.Interfaces;

namespace Catharsium.BasicAuthentication.Api.Services
{
    public class InMemoryUserService : IUserService
    {
        private readonly List<User> users = new List<User> {
            new User {
                Id = 1,
                FirstName = "My first name",
                LastName = "My last name",
                Username = "My username",
                Password = "My password"
            }
        };


        public async Task<User> Authenticate(LoginCredentials credentials)
        {
            var user = await Task.Run(() => this.users.SingleOrDefault(u => u.Username == credentials.Username && u.Password == credentials.Password));

            if (user == null) {
                return null;
            }

            user.Password = null;
            return user;
        }


        public async Task<IEnumerable<User>> GetAll()
        {
            return await Task.Run(() => this.users.Select(x => {
                x.Password = null;
                return x;
            }));
        }
    }
}