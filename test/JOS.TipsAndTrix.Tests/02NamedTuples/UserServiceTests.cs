using JOS.TipsAndTrix._02NamedTuples;
using Shouldly;
using Xunit;

namespace JOS.TipsAndTrix.Tests._02NamedTuples
{
    public class UserServiceTests
    {
        private readonly UserService _sut;

        public UserServiceTests()
        {
            _sut = new UserService();
        }

        [Fact]
        public void ShouldReturnFirstNameAndCountry()
        {
            var result = _sut.GetUser();

            result.FirstName.ShouldBe("Josef");
            result.Country.ShouldBe("Sweden");
        }
    }
}
