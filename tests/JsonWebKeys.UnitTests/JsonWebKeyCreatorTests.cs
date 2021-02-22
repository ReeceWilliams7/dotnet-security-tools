using FluentAssertions;

using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

using Moq;

using RW7.DotNetSecurityTools.JsonWebKeys;
using RW7.DotNetSecurityTools.Pem;
using RW7.DotNetSecurityTools.RsaSecurityKeys;

using Xunit;

namespace JsonWebKeys.UnitTests
{
    public class JsonWebKeyCreatorTests
    {
        private readonly Mock<ILogger<JsonWebKeyCreator>> _loggerMock;

        public JsonWebKeyCreatorTests()
        {
            _loggerMock = new Mock<ILogger<JsonWebKeyCreator>>();
        }

        [Fact]
        public void Create_should_return_key_with_populated_values()
        {
            // Arrange

            // Act
            var sut = new JsonWebKeyCreator(_loggerMock.Object, new RsaSecurityKeyCreator());
            var result = sut.Create();

            // Assert
            result.JsonWebKey.Should().NotBeNull();
            result.JsonWebKey.KeySize.Should().Be(2048);
            result.JsonWebKey.HasPrivateKey.Should().BeTrue();
            result.JsonWebKey.Alg.Should().Be(SecurityAlgorithms.RsaSha256);

            result.JsonWebKeyString.Should().NotBeNullOrEmpty();

            result.Base64JsonWebKey.Should().NotBeNullOrEmpty();

            result.RsaPublicKey.Should().NotBeNullOrEmpty();
            result.RsaPublicKey.Should().Contain(PemEncodingLabels.RsaPublicKey);

            result.RsaPrivateKey.Should().NotBeNullOrEmpty();
            result.RsaPrivateKey.Should().Contain(PemEncodingLabels.RsaPrivateKey);
        }

        // TODO: Add tests that use JsonWebKey to generate (and then validate) JWTs
    }
}