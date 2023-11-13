using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Extensions;
using MockNetworkUtility.FakeDNS;
using MockNetworkUtility.MockPing;
using System.Net.NetworkInformation;

namespace MockNetworkUtility.Test.MockPingTest
{
    public class MockNetworkServiceTests
    {
        private readonly MockNetworkService _service;
        private readonly InterfaceDNS _dNS;
        public MockNetworkServiceTests()
        {
            //Dependency
            _dNS = A.Fake<InterfaceDNS>();
            //SUT
            _service = new MockNetworkService(_dNS);
        }
        [Fact]
        public void MockNetworkService_SendPing_ReturnString()
        {
            //Arrange - variables, classes, mocks
            A.CallTo(() => _dNS.SendDNS()).Returns(true);
            //Act
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
            //Arrange

            //Act
            var result = _service.LastPingDate();

            //Assert
            result.Should().BeAfter(1.January(2023));
            result.Should().BeBefore(1.January(2043));
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

            //Assert
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
            result.Should().ContainEquivalentOf(expected);
            result.Should().Contain(x => x.DontFragment == true);
        }
    }
}
