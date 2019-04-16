using System.Collections.Generic;
using System.Threading.Tasks;
using Catharsium.BasicAuthentication.Api.Entities;

namespace Catharsium.BasicAuthentication.Api.Interfaces
{
    public interface IUserService
    {
        Task<User> Authenticate(LoginCredentials credentials);
        Task<IEnumerable<User>> GetAll();
    }
}