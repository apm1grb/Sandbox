using FluentAssertions;
using Xunit;

namespace ComponentOne.Tests
{
    public class MyClassOneTests
    {
        public class MethodOne
        {
            private readonly MyClass _sut = new MyClass();

            [Fact]
            [Trait("TestCase", "TC1")]
            public void ShouldReturn1()
            {
                // assert
                var actual = _sut.MethodOne();
                actual.Should().Be(1);
            }
        }

        public class MethodTwo
        {
            private readonly MyClass _sut = new MyClass();

            [Fact]
            [Trait("TestCase", "TC1")]
            [Trait("TestCase", "TC2")]
            public void ShouldReturnTwo()
            {
                var actual = _sut.MethodTwo();
                actual.Should().Be("two");
            }
        }
    }
}
