
using NetworkUtility.Ping;
using FluentAssertions;
using FluentAssertions.Extensions;
using System.Net.NetworkInformation;
using NetworkUtility.DNS;
using FakeItEasy;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServiceTests
    {
        private readonly NetworkService _networkService;

        private readonly IDNS _dns;

        public NetworkServiceTests()
        {
            //SUT
            //_networkService = new NetworkService();

            //DI
            _dns = A.Fake<IDNS>(); //FakeItEasy
            //SUT
            _networkService = new NetworkService(_dns);
        }

        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            // Arrange
            A.CallTo(() => _dns.SendDNS()).Returns(true); //Mocking

            
            // Act
            var result = _networkService.SendPing();
            
            // Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping Sent!");
            result.Should().Contain("Success", Exactly.Once());
        }

        [Fact]
        public void NetworkService_LastPingDate_ReturnDateTime()
        {
            // Arrange

            
            // Act
            var result = _networkService.LastPingDate();
            
            // Assert
            result.Should().BeAfter(1.January(2010));
            result.Should().BeBefore(1.January(2040));
        }

        [Fact]
        public void NetworkService_GetPingOptions_ReturnPingOptions()
        {
            // Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 128
            };
            
            // Act
            var result = _networkService.GetPingOptions();
            
            // Assert 
            result.Should().BeOfType<PingOptions>();
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(128);
        }

        [Fact]
        public void NetworkService_MostRecentPings_ReturnIEnumerablePingOptions()
        {
            // Arrange
            var expected =
      
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1
                }
            ;
            
            // Act
            var result = _networkService.MostRecentPings();

            // Assert
            //result.Should().BeOfType<IEnumerable<PingOptions>>();
            result.Should().BeAssignableTo<IEnumerable<PingOptions>>();
            result.Should().ContainEquivalentOf(expected);
            result.Should().Contain(x=>x.DontFragment == true);

        }


        [Theory]
        [InlineData(2,2,4)]
        [InlineData(6,4,10)]
        public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected)
        {
            // Arrange

            
            // Act
            var result = _networkService.PingTimeout(a, b);
            
            // Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(3);
            result.Should().BeInRange(0,100);

        }
    }
}
