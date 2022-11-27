using System.Net.Http.Json;
using System.Threading.Tasks;
using Api.Models.Security;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Tests.Integration
{
    public class ApiEndpointTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public ApiEndpointTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Security_CreateToken_ReturnsOkResponse()
        {
            const string url = "security/createToken";
            var user = new User { UserName = "sam", Password = "changeme" };
            var client = _factory.CreateClient();

            var response = await client.PostAsJsonAsync(url, user);

            response.Should().HaveStatusCode(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task Security_CreateTokenWithBadCredentials_ReturnsUnauthorizedResponse()
        {
            const string url = "security/createToken";
            var user = new User { UserName = "random", Password = "wrong" };
            var client = _factory.CreateClient();

            var response = await client.PostAsJsonAsync(url, user);

            response.Should().HaveStatusCode(System.Net.HttpStatusCode.Unauthorized);
        }
    }
}
