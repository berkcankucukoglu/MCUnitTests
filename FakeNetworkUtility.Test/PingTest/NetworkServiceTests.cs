using FakeNetworkUtility.Ping;
using FluentAssertions;
using FluentAssertions.Extensions;
using System.Net.NetworkInformation;

namespace FakeNetworkUtility.Test.PingTest
{
    public class NetworkServiceTests
    {
        private readonly NetworkService _service;
        public NetworkServiceTests()
        {
            //SUT
            _service = new NetworkService();
        }
        /*https://fluentassertions.com*/
        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            //Arrange - variables, classes, mocks
            /* Since we have ctor makes networkService available, we dont need pingService down below */
            //var pingService = new NetworkService()

            //Act
            /* Also result directly should come from ctor service */
            var result = _service.SendPing();

            //Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping Sent!");
            result.Should().Contain("Success", Exactly.Once());
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        public void NetworkService_pingTimeout_Returnınt(int x, int y, int expected)
        {
            //Arrange
            //var pingService = new NetworkService();

            //Act
            var result = _service.PingTimeout(x, y);

            //Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);
            result.Should().NotBeInRange(-10000, 0);

        }

        [Fact]
        public void NetworkService_LastPingDate_ReturnDate()
        {
            //Arrange - variables, classes, mocks

            //Act
            var result = _service.LastPingDate();

            //Assert
            result.Should().BeAfter(1.January(2023));
            result.Should().BeBefore(1.January(2043));
            //Well...if you are seing this test after 20 years, this is how i started my programming jorney.
        }

        [Fact]
        public void NetworkService_GetPingOptions_ReturnsObject()
        {
            //Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
            //Act
            var result = _service.PingOptions();

            //Assert WARNIN: "Be" careful
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(1);
        }

        [Fact]
        public void NetworkService_MostRecentPings_ReturnsArray()
        {
            //Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
            //Act
            var result = _service.MostRecentPings();

            //Assert
            //result.Should().BeOfType<IEnumerable<PingOptions>>();
            result.Should().ContainEquivalentOf(expected);
            result.Should().Contain(x => x.DontFragment == true);
        }
    }
}
