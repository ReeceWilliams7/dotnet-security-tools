using FluentAssertions;

using Microsoft.IdentityModel.Tokens;

using RW7.DotNetSecurityTools.RsaSecurityKeys;

using Xunit;

namespace RsaSecurityKeys.UnitTests
{
    public class RsaSecurityKeyCreatorTests
    {
        [Fact]
        public void Create_should_return_key_with_expected_values()
        {
            // Arrange
            var expectedKeyIdLength = 16*2;
            var expectedKeySize = 2048;
            var expectedKeyAlgorithm = "RSA";

            // Act
            var sut = new RsaSecurityKeyCreator();
            var result = sut.Create();

            // Assert
            result.KeyId.Length.Should().Be(expectedKeyIdLength);
            result.KeySize.Should().Be(expectedKeySize);
            result.Rsa.KeyExchangeAlgorithm.Should().Be(expectedKeyAlgorithm);
            result.PrivateKeyStatus.Should().Be(PrivateKeyStatus.Exists);
        }
    }
}