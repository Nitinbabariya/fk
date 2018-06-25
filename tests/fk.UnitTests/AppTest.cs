using FluentAssertions;
using Xunit;

namespace fk.UnitTests
{
    public class AppTest
    {
        private readonly App _sut;

        protected AppTest()
        {
            _sut = new App();
        }

        public class ProjectToCommand : AppTest
        {
            [Theory]
            [InlineData("git status1 -arg")]
            void ShouldReturnCommand(string input)
            {
                var cmd = _sut.ProjectToCommand(input);

                cmd.Program.Should().NotBeNull();
                cmd.Program.Should().Be("git");
                cmd.Action.Should().Be("status1");
                cmd.Arguments.Should().Be("-arg");
            }
        }

        public class GetBestMachedCommand : AppTest
        {
            [Theory]
            [InlineData("git status1 -arg")]
            void ShouldReturnBestMatchedCommand(string input)
            {
                var cmd = _sut.GetBestMachedCommand(input);
                cmd.Program.Should().Be("git");
                cmd.Action.Should().Be("status");
            }
        }
    }
}
