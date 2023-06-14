using FluentAssertions;
using PointOfSaleAPI.Utilities;

namespace PointOfSaleClient_Test
{
    [TestClass]
    public class AuthenticationTests
    {
        private AuthenticationToken? authToken = null;

        [TestCleanup]
        public void CleanUp()
        {
            authToken?.Dispose();
        }

        [TestMethod]
        public void SHA3_Password_IsValid()
        {
            var pinKey = "123456789";
            var positiveHash = "e1e44d20556e97a180b6dd3ed7ae5c465cafd553fa8747dca038fb95635b77a3" +
                               "7318f7ddf7aec1f6c3c14bb160ba2497007decf38dd361cab199e3b8c8fe1f5c";

            authToken = new AuthenticationToken(pinKey);

            var builtToken = authToken.BuildToken();

            builtToken.Should().Be(positiveHash);
        }

        [TestMethod]
        public void SHA3_Password_IsInvalid()
        {
            var pinKey = "987654321";
            var positiveHash = "e1e44d20556e97a180b6dd3ed7ae5c465cafd553fa8747dca038fb95635b77a3" +
                               "7318f7ddf7aec1f6c3c14bb160ba2497007decf38dd361cab199e3b8c8fe1f5c";

            authToken = new AuthenticationToken(pinKey);

            var builtToken = authToken.BuildToken();

            builtToken.Should().NotBe(positiveHash);
        }
    }
}