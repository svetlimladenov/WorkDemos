using System;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void FirstTests()
        {
            Assert.Equal(4, Add(2, 2));
        }

        public int Add(int x, int y)
        {
            return x + y;
        }
    }
}
