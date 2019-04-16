using System.Threading.Tasks;
using Catharsium.BasicAuthentication.Api.Controllers;
using Catharsium.BasicAuthentication.Api.Entities;
using Catharsium.BasicAuthentication.Api.Interfaces;
using Catharsium.Util.Testing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.BasicAuthentication.Api.Tests.Controllers
{
    [TestClass]
    public class UsersControllerTests : TestFixture<UsersController>
    {
        [TestMethod]
        public async Task Authenticate_ValidUser_ReturnsOk()
        {
            var credentials = new LoginCredentials {
                Username = "My username",
                Password = "My password"
            };
            var expected = new User();
            this.GetDependency<IUserService>().Authenticate(credentials).Returns(expected);

            var actual = await this.Target.Authenticate(credentials) as OkObjectResult;
            Assert.IsNotNull(actual);
            var actualValue = actual.Value as User;
            Assert.AreEqual(expected, actualValue);
        }


        [TestMethod]
        public async Task Authenticate_InvalidUser_ReturnsUnauthorized()
        {
            var credentials = new LoginCredentials {
                Username = "My username",
                Password = "My password"
            };
            this.GetDependency<IUserService>().Authenticate(credentials).Returns(null as User);

            var actual = await this.Target.Authenticate(credentials) as UnauthorizedObjectResult;
            Assert.IsNotNull(actual);
        }
    }
}