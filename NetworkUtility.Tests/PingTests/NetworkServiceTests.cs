
using NetworkUtility.Ping;
using FluentAssertions;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServiceTests
    {
        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            // Arrange
            var networkService = new NetworkService();
            
            // Act
            var result = networkService.SendPing();
            
            // Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping Sent!");
            result.Should().Contain("Success", Exactly.Once());
        }

        [Theory]
        [InlineData(2,2,4)]
        [InlineData(6,4,10)]
        public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected)
        {
            // Arrange
            var networkService = new NetworkService();
            
            // Act
            var result = networkService.PingTimeout(a, b);
            
            // Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(3);
            result.Should().BeInRange(0,100);

        }
    }
}
