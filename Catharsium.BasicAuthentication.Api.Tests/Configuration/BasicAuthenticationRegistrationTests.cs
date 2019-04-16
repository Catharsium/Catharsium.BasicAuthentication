using Catharsium.BasicAuthentication.Api.Configuration;
using Catharsium.BasicAuthentication.Api.Interfaces;
using Catharsium.BasicAuthentication.Api.Services;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.BasicAuthentication.Api.Tests.Configuration
{
    [TestClass]
    public class BasicAuthenticationRegistrationTests
    {
        [TestMethod]
        public void AddIoUtilities_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var config = Substitute.For<IConfiguration>();

            serviceCollection.AddBasicAuthentication(config);
            serviceCollection.ReceivedRegistration<IUserService, InMemoryUserService>();
        }
    }
}