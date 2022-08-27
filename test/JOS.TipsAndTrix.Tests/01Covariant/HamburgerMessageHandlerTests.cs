using JOS.TipsAndTrix._01Covariant;
using Shouldly;
using Xunit;

namespace JOS.TipsAndTrix.Tests._01Covariant
{
    public class HamburgerMessageHandlerTests
    {
        private readonly HamburgerMessageHandler _sut;

        public HamburgerMessageHandlerTests()
        {
            _sut = new HamburgerMessageHandler();
        }

        [Fact]
        public void MessageDataShouldBeOfHamburgerMessageBodyType()
        {
            var message = _sut.Poll();

            message.Data.ShouldBeOfType<HamburgerMessageBody>();
            message.Data.Name.ShouldBe("Triple Smash");
        }
    }
}
