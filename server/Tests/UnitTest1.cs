using System;
using Xunit;

namespace server.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            bool faketest = true;
            Assert.Equal(faketest, true);
        }
    }
}
