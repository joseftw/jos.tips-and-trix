using JOS.TipsAndTrix._02NamedTuples.Old;
using Shouldly;
using Xunit;

namespace JOS.TipsAndTrix.Tests._02NamedTuples.Old
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

            result.Item1.ShouldBe("Josef");
            result.Item2.ShouldBe("Sweden");
        }
    }
}
