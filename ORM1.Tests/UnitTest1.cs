using Xunit;

namespace ORM1.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_SamplePass()
        {
            int expected = 2;
            int actual = 1 + 1;
            Assert.Equal(expected, actual);
        }
    }
}
