using JOS.TipsAndTrix._01Covariant.Old;
using Shouldly;
using Xunit;

namespace JOS.TipsAndTrix.Tests._01Covariant.Old
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
            var hamburgerMessageBody = (HamburgerMessageBody)message.Data;
            hamburgerMessageBody.Name.ShouldBe("Triple Smash");
        }
    }
}
